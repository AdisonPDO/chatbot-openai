using System.Net.Http.Headers;
using System.Text.Json;

// Création du client 
using HttpClient client = new();
// Ajout du token 
client.DefaultRequestHeaders.Add("Authorization", "Bearer ****");

await ProcessOpenAiAsync(client);

static async Task ProcessOpenAiAsync(HttpClient client)
{
    // Création du body
    var jsonPayload = @"
        {
            ""model"": ""gpt-3.5-turbo"",
            ""messages"": [{""role"": ""user"", ""content"": ""Dites que ceci est un test !""}],
            ""temperature"": 0.7
        }";

    // Encodage de la payload
    var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

    // Call
    var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

    // Récuperation de la response 
    var responseContent = await response.Content.ReadAsStringAsync();

    // Log
    Console.WriteLine(responseContent);
}


