using Core.Core.Domain.Auth;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Core.Repository.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly string _BaseUrl = "http://localhost:63986/api/";
        private HttpClient client;
        public AuthRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(_BaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public dynamic Login(User user)
        {
            HttpResponseMessage response = client.PostAsync("User", new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<UserResultViewModel>(json);
            }
            return null;
        }
    }
}
