using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 5: GET Filter by Ingredient
// TheMealDB API: https://themealdb.com/api/json/v1/1/filter.php?i={ingredient}
//
// Your task:
// 1. Use the HttpClient to filter meals by ingredient "chicken_breast"
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the "meals" array has at least 1 item
//
// Response format: { "meals": [{ "strMeal": "...", "strMealThumb": "...", "idMeal": "..." }, ...] }

public static class FilterByIngredient
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Send GET request to https://themealdb.com/api/json/v1/1/filter.php?i=chicken_breast
        var response = await client.GetAsync(
            "https://themealdb.com/api/json/v1/1/filter.php?i=chicken_breast");
        // TODO: Assert status code is 200 OK
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception(
                $"Expected 200 OK, but got {(int)response.StatusCode}");
        }
        // TODO: Parse the response JSON
        string json = await response.Content.ReadAsStringAsync();
        using JsonDocument document = JsonDocument.Parse(json);

        JsonElement meals = document.RootElement.GetProperty("meals");
        // TODO: Assert the "meals" array has at least 1 item
        if (meals.GetArrayLength() < 1)
        {
            throw new Exception("No meals found for chicken_breast.");
        }
    }
}
