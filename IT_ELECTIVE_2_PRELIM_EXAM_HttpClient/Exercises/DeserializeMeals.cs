using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 10: GET Deserialize Multiple Meals
// TheMealDB API: https://themealdb.com/api/json/v1/1/search.php?f=a
//
// This endpoint returns ALL meals starting with the letter "a".
//
// Your task:
// 1. Use the HttpClient to fetch meals starting with letter "a"
// 2. Assert status code is 200 OK
// 3. Parse the JSON and get the "meals" array
// 4. Assert the array has more than 0 items
// 5. Loop through each meal and print its name (strMeal)
//
// Response format:
// {
//   "meals": [
//     { "idMeal": "52772", "strMeal": "Arrabiata", ... },
//     { "idMeal": "52781", "strMeal": "Ayam Percik", ... },
//     ...
//   ]
// }

public static class DeserializeMeals
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Send GET request to https://themealdb.com/api/json/v1/1/search.php?f=a
        var response = await client.GetAsync(
            "https://themealdb.com/api/json/v1/1/search.php?f=a");
        // TODO: Assert status code is 200 OK
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception(
                $"Expected 200 OK, but got {(int)response.StatusCode}");
        }
        // TODO: Parse the response JSON
        string json = await response.Content.ReadAsStringAsync();
        using JsonDocument document = JsonDocument.Parse(json);
        // TODO: Get the "meals" array
        JsonElement meals = document.RootElement.GetProperty("meals");
        // TODO: Assert the array has more than 0 items
        if (meals.GetArrayLength() <= 0)
        {
            throw new Exception("Meals array is empty.");
        }
        // TODO: Loop through and print each meal's strMeal
        foreach (JsonElement meal in meals.EnumerateArray())
        {
            if (meal.TryGetProperty("strMeal", out JsonElement strMealProp))
            {
                Console.WriteLine($"Meal Name: {strMealProp.GetString()}");
            }
        }
    }
}
