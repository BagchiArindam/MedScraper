using System;
using System.Collections.Concurrent;
using System.IO.Compression;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


using (HttpClient client = new HttpClient())
{
    Uri uri = new Uri("https://www.medplusmart.com/mart-catalog-api/getCompositionProductDetails");

    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/114.0");
    client.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
    client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
    client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
    client.DefaultRequestHeaders.Add("Referer", "https://www.medplusmart.com/compositionProducts/Alpha-GPC-250-MG+Piracetam-800-MG/21109");
    client.DefaultRequestHeaders.Add("x-requested-with", "XMLHttpRequest");
    client.DefaultRequestHeaders.Add("Origin", "https://www.medplusmart.com");
    client.DefaultRequestHeaders.Add("DNT", "1");
    client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
    client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
    client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
    client.DefaultRequestHeaders.Add("Connection", "keep-alive");
    client.DefaultRequestHeaders.Add("Cookie", "ROUTEID=.jvm0; _abck=20FC213699EF04D0CB6D21A772DF59EC~0~YAAQ5YdkX1aMc72IAQAANL8hwAqF8lb9ow+N4I8ktWmL33xzCL4pvCo3hkdWJqztqMzW07BW7jwvWfaNwWn8igTRqgH1RwphUV+P4gWedrZ7YgPh3MW1pyAmT7ssqD0ushJpXDH6hNOMvGg2tklwihPrCs7+tErquIE0vMXvsyfv3SGho8r7Z/qFaXSMMV4V2qA0QxppqumtA7aqtb6U4epbKBykvu/sGxs5pypgtfnQURAHZMtvKwzn3KxTaP1dwWcUrm4fFgwe2y+3kuifJLBm5kMvotL3iQtWYLN6O5CwfFTPcf76AfeFd0kKzPGaYspZN8IqqKeD8+jqm4C3WYkgw9+0kEbZXnDUWBYTTRW/juFZbbKHgsYlDROzktdVKkVIcNyXV3mWGN3o+GUTfXR7zqfOQrdWJGUJdx/B~-1~-1~-1; tokenId=8C222E6E9B31B8114D3661F5379F4E94; latLong=\"12.832188,77.663269\"; pincode=560100; customerId=25141239; s_token=DtVUuw6eFXmvqTj6yg%2B81DpfXvXM0qanpJ0TTv28TPNCuCcsubUbxzCJSDnbSvzgmMXb37f8mp3ZZDOx38N1WOZ3NYYyEyDz4%2FXNK8oa0Cs%3D; cartProductIdString=\"{\\\"PIRA0037\\\":\\\"1\\\",\\\"NIMO0001\\\":\\\"3\\\",\\\"STAB0009\\\":\\\"1\\\",\\\"MEGA0434\\\":\\\"1\\\",\\\"RINO0005\\\":\\\"3\\\",\\\"COGN0117\\\":\\\"3\\\"}\"; terminal_id=eyJ0YWJJZCI6ImxoNXN4MG5qcGhzejl1eWNsem4iLCJjdXN0b21lcklkIjoiMjUxNDEyMzkiLCJzZXNzaW9uVG9rZW4iOiJEdFZVdXc2ZUZYbXZxVGo2eWcrODFEcGZYdlhNMHFhbnBKMFRUdjI4VFBOQ3VDY3N1YlVieHpDSlNEbmJTdnpnbU1YYjM3ZjhtcDNaWkRPeDM4TjFXT1ozTllZeUV5RHo0L1hOSzhvYTBDcz0iLCJyZWZJZCI6MjQxMjM0MzMsInJlZlR5cGUiOiJPUkRFUiIsInRpbWVzdGFtcCI6MTY4MzAwMzY0NjM1MX0=; JSESSIONID=ABF13714668144AE475B9B51AB394415; bm_sz=3E25B61A2A5EDA0002C5F94A417C965A~YAAQ5YdkX0Uxc72IAQAAzgqIvxSYC2Au7nLDmOHYMMpx6ry5svVZJtEdCK7LSLg3xIvYJlY0N+XD4RvmZ2SLDYocADZ9kiPoXMKnevDKuEbOWk9gU7zVrjQYVG1Ib4Zmo0nynPgv3VDJ0OKHrG74wbjG7UT1CGjvaDU4HoV7fNbF5AhECT9CUw3IuiSGQxA580BpUJSmGkOo2bAu1Ekc6OMJ7gzZ+U6NQE0BCPSoM17n0/L2YWsuqnKQ1EWi0JKhl8eG6KlbkGXXH3CRJILt+DHLP88wJilgbSBw3xniSHz2k37PAQLajw==~4473653~4539206; b_token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiIyNTE0MTIzOSIsImlzcyI6Ind3dy5tZWRwbHVzbWFydC5jb20iLCJleHAiOjE2ODY5MjY5NjV9.1cIKeXuiBJmK-4wsq7ZfyyP3U-ojN7Mm7pkNb5algBQ; ak_bmsc=81CDE70240F1224483D2E2919889B623~000000000000000000000000000000~YAAQ5YdkX7B5c72IAQAAYKcFwBSoD9ZuRDUYbEdovm/N3dV146yM695ItRX+Vx2wgpEFpfR3lDkoTfkrGe0ihfFzmQaA7OGmTCIC8iTbKmUOls4MbJGUDnjpRvmhmLwpUY0V+RfKYHh55F0okwryHxuesLioebQLKkvpVtN6fo6eJFNWOGfnWUk7LsoudRmSbJl7KV0UvxANog8bMP5CiXtEYtC/EWYS0gySnpDy2kkhpqSXcYnZB3TFrrdrQov/Oc0nds9AMOpqWJHZB5ZW5ytN1HK6l1ni0T3hDvsPL6GS25wtgYLtmT3VMSQ4ZZ9URPmJf7Wps1lBAMFVfzE04H9wPtMrL2Zbt160DczrekYppVkY/hcDZ+iBeyBWKXGDa0DCYZGYYMaJu0cCokiCWtM964YnMrtuaEg3CdDEcZk6VHzPiefVRcbVW5Fgg5qdfh4ICtjz0uXS47sVRTeCnK0eVDBvw3ofS/cgVB+KHNDAi5oE; bm_sv=9F12437573041D621406B63FC22FEA8B~YAAQBwEQAhWr+ZeIAQAAcm4FwBSBQlZTluZ0vc7EvZOlOxplOXLohwO0ad6rFaEyoDnAK3pd0XPuc5hHAHI3BvWVzDFRVywnSJ3qgugvPrBIwqlp5M4sA/+OUPKWJnwfd7uPZ9jJfhikn/S/GTggq6Vntzklc8WFT2gZrwdFmbC7jxadOrjIUhaVACuQAt2nLgVJ24KZZgPI5eJ+XD+gD88dWnIQ/EVaRAhthYqoRY0HeiYFwOPHdonD2K9jvvexZ9V76ADg~1; bm_mi=1FEA833A3B9BC8568EF1426C3827EA64~YAAQBwEQAmOq+ZeIAQAA2FkFwBQIRrfU38W+Elbm1ObOeRmAtXMQEuJZQ2D1M2vGRGLsWBY4wwQ056NC/CeP53nVVd0rjqaqIRVeh2AQD8E32ZNh8STRj7j6zdYhz/Pk2QxITzIJ5IRudOhNlmW+oWqM7URpeCXz/sp13VPfMNRwvlzJ0frAF5wKkeLYVSRTB9F8gf2sz1mtyjBs2icYJ/dI5X66VukBNu3Yba+PfLbq8UKqrHkDXtdG3IoE/8rVyFmVR4iYRpv0HnMfIBGvnNxLcYYJctVEnKB9WA4D/2gt8UQc6VIcNZqq4IKwEFg+IpN5tVEkYSddpy8WifyMO50ckKwXdlIYjVUqsoVmb5jmPUUBnsGyX+aZBza1iizWbIQ=~1");

    ConcurrentBag<string> compositionNames = new ConcurrentBag<string>();
    // Set request body
    Parallel.For(1, 100000, async compositionId =>
    {
        // Set request body
        var requestBody = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("compositionId", compositionId.ToString()),
            new KeyValuePair<string, string>("pageNo", "1"),
            new KeyValuePair<string, string>("recordsPerPage", "30"),
            new KeyValuePair<string, string>("maxRecords", "800"),
            new KeyValuePair<string, string>("productIdString", "[]"),
            new KeyValuePair<string, string>("tokenId", "B5138B17C6C392832F74E5E0614CC2A1"),
            new KeyValuePair<string, string>("customerId", "25141239"),
            new KeyValuePair<string, string>("timeStapm", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")),
            // Add more key-value pairs as needed
        });

        // Set content type header on the request itself
        requestBody.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

        // Send the request
        HttpResponseMessage response = await client.PostAsync(uri, requestBody);

        // Check if the response is gzipped
        if (response.Content.Headers.ContentEncoding.Contains("gzip"))
        {
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            using (var gzipStream = new GZipStream(responseStream, CompressionMode.Decompress))
            using (var reader = new StreamReader(gzipStream, Encoding.UTF8))
            {
                // Read response content
                string responseContent = await reader.ReadToEndAsync();
                // Process the response
                ProcessResponse(responseContent, compositionNames);
            }
        }
        else
        {
            // Read response content as usual
            string responseContent = await response.Content.ReadAsStringAsync();
            // Process the response
            ProcessResponse(responseContent, compositionNames);
        }
    });
    SaveCompositionNamesToFile(compositionNames, "composition_names.txt");
}
//static void ProcessResponse(string responseContent)
//{
//    // Parse the JSON response
//    var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseContent);

//    // Check if the response contains the keys "message" and "statusCode" with the value "Success"
//    if (responseObject.message == "Success" && responseObject.statusCode == "SUCCESS")
//    {
//        // Fetch the composition name from the dataObject
//        string compositionName = responseObject.dataObject.compositionName;

//        // Save the composition name to a text file
//        string filePath = "composition_names.txt";

//        // Append the composition name to the file
//        File.AppendAllText(filePath, compositionName + Environment.NewLine);
//    }
//    else if (responseObject.message != "Composition Products not found") {
//        string filePath = "composition_fails.txt";

//        // Append the composition name to the file
//        File.AppendAllText(filePath, responseObject.message + Environment.NewLine);
//    }
//}
static void ProcessResponse(string responseContent, ConcurrentBag<string> compositionNames)
{
    // Parse the JSON response
    try
    {
        var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseContent);
        if (responseObject.message == "Success" && responseObject.statusCode == "SUCCESS")
        {
            // Fetch the composition name from the dataObject
            string compositionName = responseObject.dataObject.compositionName;

            // Add the composition name to the concurrent bag
            compositionNames.Add(compositionName);
        }
    }
    catch(Exception ex) 
    {
        Console.WriteLine(responseContent);
    }
}

static void SaveCompositionNamesToFile(ConcurrentBag<string> compositionNames, string filePath)
{
    // Save the composition names to a file
    using (StreamWriter writer = new StreamWriter(filePath))
    {
        foreach (string compositionName in compositionNames)
        {
            writer.WriteLine(compositionName);
        }
    }
}

