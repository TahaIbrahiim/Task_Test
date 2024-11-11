using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Task_ANAS_Academy;
using Task_ANAS_Academy.Models;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Task_ANAS_Academy.Tests
{
    [TestFixture]
    public class AuthControllerTests
    {
        private HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            var appFactory = new WebApplicationFactory<Program>(); // Assuming Program.cs is your main entry
            _client = appFactory.CreateClient();
        }

        [Test]
        public async Task Login_Successful_ShouldReturnToken()
        {
            // Arrange
            var loginData = new LoginModel { Username = "testuser", Password = "password123" };

            // Act
            var response = await _client.PostAsJsonAsync("/api/auth/login", loginData);
            var content = await response.Content.ReadFromJsonAsync<dynamic>();

            // Assert
            Assert.Equals(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task Login_Unsuccessful_ShouldReturnUnauthorized()
        {
            // Arrange
            var loginData = new LoginModel { Username = "invaliduser", Password = "wrongpassword" };

            // Act
            var response = await _client.PostAsJsonAsync("/api/auth/login", loginData);

            // Assert
            Assert.Equals(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
