﻿using Chet.Template.Configurations;
using Chet.Template.ToolKits.Base;
using Chet.Template.ToolKits.Extensions;
using Chet.Template.ToolKits.GitHub;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Chet.Template.Authorize.Impl
{
    public class AuthorizeService : ServiceBase, IAuthorizeService
    {
        private readonly IHttpClientFactory _httpClient;

        public AuthorizeService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        /// <summary>
        /// 获取登录地址(GitHub)
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetLoginAddressAsync()
        {
            var result = new ServiceResult<string>();

            var request = new AuthorizeRequest();
            var address = string.Concat(new string[]
            {
                    GitHubConfig.API_Authorize,
                    "?client_id=", request.Client_ID,
                    "&scope=", request.Scope,
                    "&state=", request.State,
                    "&redirect_uri=", request.Redirect_Uri
            });

            result.IsSuccess(address);
            return await Task.FromResult(result);
        }

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetAccessTokenAsync(string code)
        {
            var result = new ServiceResult<string>();

            if (string.IsNullOrEmpty(code))
            {
                result.IsFailed("code为空");
                return result;
            }

            var request = new AccessTokenRequest();

            var content = new StringContent($"code={code}&client_id={request.Client_ID}&redirect_uri={request.Redirect_Uri}&client_secret={request.Client_Secret}");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            using var client = _httpClient.CreateClient();
            var httpResponse = await client.PostAsync(GitHubConfig.API_AccessToken, content);

            var response = await httpResponse.Content.ReadAsStringAsync();

            if (response.StartsWith("access_token"))
                result.IsSuccess(response.Split("=")[1].Split("&").First());
            else
                result.IsFailed("code不正确");

            return result;
        }

        /// <summary>
        /// 登录成功，生成Token
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GenerateTokenAsync(string access_token)
        {
            var result = new ServiceResult<string>();

            if (string.IsNullOrEmpty(access_token))
            {
                result.IsFailed("access_token为空");
                return result;
            }

            using var client = _httpClient.CreateClient();
            //携带token请求认证
            var authenticationHeaderValue = new AuthenticationHeaderValue("token", access_token);
            client.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
            client.DefaultRequestHeaders.Add("UserAgent", "chet");
            var httpResponse = await client.GetAsync(GitHubConfig.API_User);
            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                result.IsFailed("access_token不正确");
                return result;
            }

            var content = await httpResponse.Content.ReadAsStringAsync();

            var user = content.FromJson<UserResponse>();
            if (user.IsNull())
            {
                result.IsFailed("未获取到用户数据");
                return result;
            }

            if (user.Id != GitHubConfig.UserId)
            {
                result.IsFailed("当前账号未授权");
                return result;
            }

            var claims = new[] {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.Now.AddMinutes(AppSettings.JWT.Expires)).ToUnixTimeSeconds()}"),
                    new Claim(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}")
                };

            var key = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.SerializeUtf8());
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                issuer: AppSettings.JWT.Domain,
                audience: AppSettings.JWT.Domain,
                claims: claims,
                expires: DateTime.Now.AddMinutes(AppSettings.JWT.Expires),
                signingCredentials: creds);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            result.IsSuccess(token);
            return await Task.FromResult(result);
        }
    }
}
