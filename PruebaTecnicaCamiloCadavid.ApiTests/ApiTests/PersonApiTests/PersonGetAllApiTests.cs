using System.Net;
using System.Text.Json;

namespace PruebaTecnicaCamiloCadavid.ApiTests.ApiTests.PersonApiTests
{
    public class PersonGetAllApiTests(ApiApp apiApp) : IClassFixture<ApiApp>
    {
        private readonly HttpClient _client = apiApp.CreateClient();

        [Fact]
        public async Task GetAllPersons_ReturnsOkResponse()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, $"{apiApp.PathPersonApi}/get-all");
            // Act
            var response = await _client.SendAsync(request);
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();
            var persons = JsonSerializer.Deserialize<List<dynamic>>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            Assert.NotNull(persons);
            Assert.True(persons.Count >= 2); // At least the two seeded persons should be present
        }
    }
}
