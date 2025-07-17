using System.Text.RegularExpressions;

List<Person> users = new List<Person>
{
    new() { Id = Guid.NewGuid().ToString(), Name = "Tom", Age = 37 },
    new() { Id = Guid.NewGuid().ToString(), Name = "Shon", Age = 27 },
    new() { Id = Guid.NewGuid().ToString(), Name = "Chris", Age = 14 }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    var path = request.Path;
    
    string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";
    if (path == "/api/users" && request.Method == "GET")
    {
        await GetAllPeople(response);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "GET")
    {
        string? id = path.Value?.Split("/")[3];
        await GetPerson(id, response);
    }
    else if (path == "/api/users" && request.Method == "POST")
    {
        await CreatePerson(response, request);
    }
    else if (path == "/api/users" && request.Method == "PUT")
    {
        await UpdatePerson(response, request);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "DELETE")
    {
        string? id = path.Value?.Split("/")[3];
        await DeletePerson(id, response);
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }
});

app.Run();

async Task GetAllPeople(HttpResponse response)
{
    await response.WriteAsJsonAsync(users);
}

async Task GetPerson(string? id, HttpResponse response)
{
    Person? user = users.FirstOrDefault(x => x.Id == id);
    if (user != null)
        await response.WriteAsJsonAsync(user);
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new {message = "User not found"});
    }
}

async Task CreatePerson(HttpResponse response, HttpRequest request)
{
    try
    {
        var user = await request.ReadFromJsonAsync<Person>();
        if (user != null)
        {
            if (users.FirstOrDefault((x) => x.Name == user.Name
                                            && x.Age == user.Age) != null)
                throw new ApplicationException("User already exists");
            user.Id = Guid.NewGuid().ToString();
            users.Add(user);
            await response.WriteAsJsonAsync(user);
        }
        else
        {
            throw new ApplicationException("User not found");
        }
    }
    catch (ApplicationException ex)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
    }
}

async Task UpdatePerson(HttpResponse response, HttpRequest request)
{
    try
    {
        var userData = await request.ReadFromJsonAsync<Person>();
        if (userData != null)
        {
            var user = users.FirstOrDefault(x => x.Id == userData.Id);
            if (user != null)
            {
                user.Age = userData.Age;
                user.Name = userData.Name;
                await response.WriteAsJsonAsync(userData);
            }
            else
            {
                response.StatusCode = 400;
                await response.WriteAsJsonAsync(new { message = "User not found" });
            }
        }
        else
        {
            throw new ApplicationException("Corrupted data");
        }
    }
    catch (ApplicationException ex)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new {message = "corrupted data"});
    }
}

async Task DeletePerson(string? id, HttpResponse response)
{
    Person? user = users.FirstOrDefault(x => x.Id == id);
    if (user != null)
    {
        users.Remove(user);
        await response.WriteAsJsonAsync(user);
    }
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new {message = "User not found"});
    }
}

public class Person
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public int Age { get; set; }
}