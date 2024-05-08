using Journey.Model.Responses;
using Journy.Model.Auth;
using System.Net.Http.Headers;

namespace JourneyItMVC.API
{
    public class JourneyItAPI
    {
        private readonly HttpClient _api;

        public JourneyItAPI(IHttpContextAccessor accessor, IHttpClientFactory factory)
        {
            _api = factory.CreateClient("JourneyIt");

            var token = accessor.HttpContext.Session.GetString("Token");
            _api.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<PostResponse>> GetRandomPost(int countryId = 0)
        {
            var response = await _api
                .GetFromJsonAsync<List<PostResponse>>($"api/Post/randomposts/");
            return response;
        }




        public async Task<bool> SignUp(SignUpRequest request)
        {
            var response = await _api.PostAsJsonAsync("api/auth/signup", request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }


        public async Task<String> Login(string username, string password)
        {
            var response = await _api.PostAsJsonAsync("/api/auth/login",
                new LoginRequest { Username=username,Password=password });

            if(response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadFromJsonAsync<UserLoginResponse>(); //must add loginresponse 
                var token = tokenResponse.Token;
                return token;
            }
            return "";
        }


    }
}
