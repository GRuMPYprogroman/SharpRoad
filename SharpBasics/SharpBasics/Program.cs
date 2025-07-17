class Program
{
    static HttpClient httpClient = new HttpClient();
 
    static async Task Main()
    {
        // определяем данные запроса
        using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://www.google.com");
        // выполняем запрос
        using HttpResponseMessage response = await httpClient.SendAsync(request);
        
        Console.WriteLine($"Status: {response.StatusCode}");
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Content:\n {content}");
    }
}