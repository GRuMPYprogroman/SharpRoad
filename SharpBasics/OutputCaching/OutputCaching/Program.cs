var users = new List<string> { "Tom", "Bob", "Sam" }; 
 
var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddOutputCache();  // добавляем сервисы
 
var app = builder.Build();
 
app.UseOutputCache();       // добавляем OutputCacheMiddleware
 
// добавляем в список строку, которая передается через параметр маршрута name
app.MapGet("/add/{name}", (string name) => 
{
    users.Add(name);
    return $"{name} has been added";
});

app.MapGet("/", () => users)
    .CacheOutput(t => t.SetVaryByQuery("username"));

app.Run();