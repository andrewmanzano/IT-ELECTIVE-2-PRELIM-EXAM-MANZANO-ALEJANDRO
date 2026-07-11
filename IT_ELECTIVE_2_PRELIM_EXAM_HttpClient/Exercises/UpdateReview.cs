using System.Text;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 7: PUT Update Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts/{id}
//
// Your task:
// 1. Create a JSON body: { "id": 1, "title": "Updated Review", "body": "Even better than before!", "userId": 1 }
// 2. Wrap it in StringContent with media type "application/json"
// 3. Send a PUT request to update post with ID 1
// 4. Assert status code is 200 OK
// 5. Parse the response JSON and assert the title is "Updated Review"
//
// Hint: Use await client.PutAsync(url, content)

public static class UpdateReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Create JSON string with id, title, body, and userId
        string json = "{\"id\": 1, \"title\": \"Updated Review\", \"body\": \"Even better than before!\", \"userId\": 1}";

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // TODO: Send PUT request to https://jsonplaceholder.typicode.com/posts/1
        string url = "https://jsonplaceholder.typicode.com/posts/1";
        HttpResponseMessage response = await client.PutAsync(url, content);

        // TODO: Assert status code is 200 OK
        response.EnsureSuccessStatusCode();
        // TODO: Parse the response JSON
        string responseString = await response.Content.ReadAsStringAsync();
        using JsonDocument doc = JsonDocument.Parse(responseString);
        string returnedTitle = doc.RootElement.GetProperty("title").GetString();

        // TODO: Assert the title is "Updated Review"
        if (returnedTitle != "Updated Review")
        {
            throw new Exception($"Assertion failed! Expected 'Updated Review' but got '{returnedTitle}'");
        }

        Console.WriteLine("Exercise 7 passed successfully!");
    }
}
