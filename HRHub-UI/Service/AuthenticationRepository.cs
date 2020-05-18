using Blazored.LocalStorage;
using HRHub_UI.Contracts;
using HRHub_UI.Models;
using HRHub_UI.Providers;
using HRHub_UI.Static;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HRHub_UI.Service
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IHttpClientFactory _client;
        private readonly ILocalStorageService _localStorageService;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public AuthenticationRepository(IHttpClientFactory client,
            ILocalStorageService localStorageService,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _client = client;
            _localStorageService = localStorageService;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> Login(LoginModel user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post
              , EndPoints.LoginEndpoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(user)
                , Encoding.UTF8, "application/json");

            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            var content = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<TokenResponse>(content);

            //Store Token
            await _localStorageService.SetItemAsync("authToken", token.Token);

            //Change auth state of app
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider)
                .LoggedIn();

            //client.DefaultRequestHeaders.Authorization =
            //    new AuthenticationHeaderValue("bearer", token.Token);

            return true;

        }

        public async Task Logout()
        {
            await _localStorageService.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider)
                .LoggedOut();
        }

        public async Task<bool> Register(RegisterModel user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post
                , EndPoints.RegisterEndpoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(user)
                , Encoding.UTF8, "application/json");

            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

    }
    }

