using Journey.Model.Requests;
using Journey.Model.Responses;
using Journy.Model;
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

            //  var token = accessor.HttpContext.Session.GetString("Token");
            accessor.HttpContext.Request.Cookies.TryGetValue("Token", out string token);
            _api.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<PostResponse>> GetRandomPost(int countryId = 0)
        {
            var response = await _api
                .GetFromJsonAsync<List<PostResponse>>($"api/Post/randomposts/");

            var response2 = await _api.GetAsync($"api/Post/randomposts/");
            var outputJson = await response2.Content.ReadAsStringAsync();
            return response;
        }
        public async Task<List<PostResponse>> GetPinnedPost()
        {
            var response = await _api
                .GetFromJsonAsync<List<PostResponse>>($"api/Post/pinnedposts");

            var response2 = await _api.GetAsync($"api/Post/pinnedposts");
            var outputJson = await response2.Content.ReadAsStringAsync();
            return response;
        }
        public async Task<List<PostResponse>> GetMyPosts(int countryId = 0)
        {
            var response = await _api.GetFromJsonAsync<List<PostResponse>>("api/Post/myposts");
            return response;
        }


        public async Task CreatePost(CreatePostRequest form)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7005/api/post/create");
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(form.ImagePath.OpenReadStream()), form.ImagePath.Name, form.ImagePath.FileName);
            content.Add(new StringContent(form.Texts), "Texts");
            content.Add(new StringContent(form.Title), "Title");
            content.Add(new StringContent(form.CountryId.ToString()), "CountryId");
            request.Content = content;
            var response = await _api.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
        public async Task EditProfile(EditProfileRequest form)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7005/api/Auth/Profile");
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(form.Image.OpenReadStream()), form.Image.Name, form.Image.FileName);
            content.Add(new StringContent(form.Email), "Email");
            content.Add(new StringContent(form.Name), "Name");
            request.Content = content;
            var response = await _api.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task<ProfileResponse> GetProfilet()
        {
            var response = await _api
                .GetFromJsonAsync<ProfileResponse>($"api/Auth/Profile/");

          
            return response;
        }

        public async Task<List<Country>> GetCountries()
        {
            var response = await _api
                .GetFromJsonAsync<List<Country>>($"api/Post/countries");


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
        public async Task<bool> Pin(int postId )
        {
            var response = await _api.PostAsync($"api/post/pin/{postId}", null);
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
