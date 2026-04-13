# SharpRoad

Коллекция учебных мини-проектов на C#, .NET и WPF. Репозиторий собран как набор небольших экспериментов: от TCP-чата и `HttpClient` до аутентификации в ASP.NET Core, Entity Framework, Redis-кэша и генерации PDF.

## Что лежит в репозитории

- `SharpBasics/` - консольные, сетевые и web-мини-проекты на .NET 9.
- `WPF_projects/` - desktop- и PDF-эксперименты, включая старый проект на .NET Framework 4.8.1.
- `NET Roadmap.png` - отдельный справочный материал по направлению изучения .NET.

## Мини-проекты в `SharpBasics`

| Проект | Тип | Что демонстрирует | Стек / зависимости | Статус |
| --- | --- | --- | --- | --- |
| [`SharpBasics`](SharpBasics/SharpBasics) | Console | Простейший пример `HttpClient`: GET-запрос к `https://www.google.com` и вывод ответа в консоль | .NET 9, `HttpClient` | Рабочий учебный пример |
| [`Server`](SharpBasics/Server) | Console / TCP | TCP-сервер чата на `TcpListener` с подключением нескольких клиентов и широковещательной рассылкой сообщений | .NET 9, `System.Net.Sockets` | Рабочий учебный пример |
| [`Client`](SharpBasics/Client) | Console / TCP | Консольный TCP-клиент для чата: подключение к `127.0.0.1:8888`, отправка и приём сообщений | .NET 9, `System.Net.Sockets` | Рабочая пара к `Server` |
| [`ASP_Server`](SharpBasics/ASP_Server) | ASP.NET Core | Minimal API с CRUD по пользователям в памяти и простым HTML/JS-интерфейсом | ASP.NET Core, Minimal API, static files | Рабочий демо-проект |
| [`ASP_Client`](SharpBasics/ASP_Client) | ASP.NET Core | Минимальная web-заготовка; в `Program.cs` сейчас только `Hello World`, при этом в проекте лежит HTML-страница, похожая на CRUD-клиент | ASP.NET Core | Скорее заготовка / черновик |
| [`CookieAuthentication`](SharpBasics/CookieAuthentication) | ASP.NET Core | Cookie-аутентификация с ролями `admin` и `user`, HTML-форма входа и защищённые маршруты | ASP.NET Core Auth, Cookies, Claims | Рабочий демо-проект |
| [`EntityFramework`](SharpBasics/EntityFramework) | ASP.NET Core | CRUD API по пользователям через Entity Framework Core и SQL Server LocalDB, плюс web-страница для управления данными | ASP.NET Core, EF Core, SQL Server LocalDB | Рабочий демо-проект |
| [`OutputCaching`](SharpBasics/OutputCaching) | ASP.NET Core | Пример `OutputCache`: кэширование ответа и вариативность по query-параметру | ASP.NET Core Output Caching | Рабочий учебный пример |
| [`RedisServer`](SharpBasics/RedisServer) | ASP.NET Core | Получение пользователя сначала из Redis-кэша, затем из SQLite через EF Core, с записью результата в кэш | ASP.NET Core, EF Core, SQLite, Redis, `IDistributedCache` | Рабочий демо-проект |
| [`TokenAuthentication`](SharpBasics/TokenAuthentication) | ASP.NET Core | Выдача JWT по логину/паролю, защищённый endpoint `/data` и простая HTML-страница, которая хранит токен в `sessionStorage` | ASP.NET Core, JWT Bearer | Рабочий демо-проект |
| [`FitipInternship`](SharpBasics/FitipInternship) | Console | Задача на поиск наибольшего общего префикса для массива строк | .NET 9 | Рабочий алгоритмический мини-проект |
| [`TestProject`](SharpBasics/TestProject) | WPF | Небольшой desktop-пример с `RadioButton` и обработчиком выбора | WPF, .NET 9 | Рабочий UI-прототип |
| [`WebApplication3`](SharpBasics/WebApplication3) | ASP.NET Core / Networking | Незавершённый эксперимент с UDP-сокетом: `Program.cs` обрывается на этапе создания `IPEndPoint` | ASP.NET Core, `Socket` | Незаполненная заготовка, в текущем виде не собирается |

## Мини-проекты в `WPF_projects`

| Проект | Тип | Что демонстрирует | Стек / зависимости | Статус |
| --- | --- | --- | --- | --- |
| [`ConsoleApp1`](WPF_projects/ConsoleApp1) | Console | Генерация простого PDF-файла `helloworld-pdf.pdf` через iText | .NET 9, iText 9 | Рабочий учебный пример |
| [`iTestPdf`](WPF_projects/iTestPdf) | Console | Почти тот же сценарий генерации PDF, но в старом формате проекта с `packages.config` и target `net481` | .NET Framework 4.8.1, iText 9, NuGet packages.config | Рабочий legacy-пример |
| [`WpfTestApplication`](WPF_projects/WpfTestApplication) | WPF | Прототип окна с редактируемым `ComboBox` | WPF, .NET 9 | Рабочий UI-прототип |

## Что здесь можно изучить

- Базовое сетевое программирование на TCP и начатый UDP-эксперимент.
- Minimal API и простые CRUD-интерфейсы без MVC.
- Cookie- и token-based аутентификацию в ASP.NET Core.
- Подключение Entity Framework Core к SQL Server и SQLite.
- Использование `OutputCache` и Redis-кэширования.
- WPF-основы: `RadioButton`, `ComboBox`, code-behind.
- Генерацию PDF в консольных приложениях.

## Как запускать

### Базовые требования

- .NET 9 SDK для большинства проектов.
- Windows и desktop workload для WPF-проектов.
- SQL Server LocalDB для [`EntityFramework`](SharpBasics/EntityFramework).
- Redis на `localhost` для [`RedisServer`](SharpBasics/RedisServer).
- Восстановление NuGet-пакетов для [`iTestPdf`](WPF_projects/iTestPdf), так как это старый проект под .NET Framework.

### Примеры запуска

```powershell
dotnet run --project SharpBasics/Server/Server/Server.csproj
dotnet run --project SharpBasics/Client/Client/Client.csproj
dotnet run --project SharpBasics/OutputCaching/OutputCaching/OutputCaching.csproj
dotnet run --project SharpBasics/FitipInternship/FitipInternship/FitipInternship.csproj
dotnet run --project WPF_projects/ConsoleApp1/ConsoleApp1/ConsoleApp1.csproj
```

Для web-проектов можно запускать соответствующий `.csproj` через `dotnet run` или открывать `.sln` в Visual Studio / Rider.

## Замечания по содержимому

- Это именно коллекция учебных мини-проектов, а не одна цельная система.
- Описания выше составлены по фактическому коду в репозитории, а не по названиям каталогов.
- В части старых файлов есть комментарии с нарушенной кодировкой, но логика проектов при этом читается.
- [`WebApplication3`](SharpBasics/WebApplication3) выглядит как недописанный черновик и выделен отдельно, чтобы не создавать ложное впечатление о готовности.

## Материалы

- [NET Roadmap](NET%20Roadmap.png)
