using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Maui.Auth
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private string _accessToken;
        private string _refreshToken;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AuthResponse> Register(RegisterModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("", model);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<AuthResponse>();
        }

        public async Task<AuthResponse> LoginAsync(LoginModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("", model);
            response.EnsureSuccessStatusCode();

            var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();
            _accessToken = authResponse.Token;
            _refreshToken = authResponse.RefreshToken;
            return authResponse;
        }
    }
}
