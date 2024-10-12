using ApiIntegrationTest.Base;
using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.General;
using Domain.DataTransferObjects.User.SignIn;
using NLog.Targets;
using System.Text;
using System.Text.Json;


namespace ApiIntegrationTest.Controllers.v1
{
    public class AccountControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public AccountControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CaptchaTest()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/v1/Account/Captcha");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            CollectionResult<CaptchaDTO>? result = JsonSerializer.Deserialize<CollectionResult<CaptchaDTO>>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.NotNull(result);
            Assert.IsType<CollectionResult<CaptchaDTO>>(result);
            Assert.NotNull(result.Status);
            Assert.Equal(result.Status.Success, true);
            Assert.NotNull(result.Result);
            Assert.IsType<CaptchaDTO>(result.Result);
            Assert.NotEmpty(result.Result.CaptchaImage);
            Assert.NotEmpty(result.Result.CaptchaCode);
        }

        [Fact]
        public async Task SignInTest()
        {
            var client = _factory.GetAnonymousClient();

            SignInDTO request = new SignInDTO
            {
                Username = "hossein",
                Password = "12345",
                Captcha = new CaptchaDTO
                {
                    CaptchaImage = "test",
                    CaptchaCode = "test",
                    Captcha = "test",
                    CaptchaTime = 1
                }
            };


            var response = await client.PostAsync("/api/v1/Account/SignIn", new StringContent(
            JsonSerializer.Serialize(request),
            Encoding.UTF8,
            "application/json"));

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            CollectionResult<SignInResponseDTO>? result = JsonSerializer.Deserialize<CollectionResult<SignInResponseDTO>>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.NotNull(result);
            Assert.IsType<CollectionResult<SignInResponseDTO>>(result);

        }
    }
}
