using Microsoft.EntityFrameworkCore;
using MusicLib.BLL.Interfaces;
using MusicLib.BLL.Services;
using MusicLib.BLL.Infrastructure;

// Microsoft.EntityFrameworkCore.Design пакет необходим для миграций
var builder = WebApplication.CreateBuilder(args);

// Получаем строку подключения из файла конфигурации
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMusicLibContext(connection);
builder.Services.AddUnitOfWorkService();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IPlayerService, PlayerService>();

// Добавляем сервисы MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles(); // обрабатывает запросы к файлам в папке wwwroot

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Genres}/{action=Index}/{id?}");

app.Run();
