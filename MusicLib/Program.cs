using Microsoft.EntityFrameworkCore;
using MusicLib.BLL.Interfaces;
using MusicLib.BLL.Services;
using MusicLib.BLL.Infrastructure;

// Microsoft.EntityFrameworkCore.Design ����� ��������� ��� ��������
var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMusicLibContext(connection);
builder.Services.AddUnitOfWorkService();
builder.Services.AddTransient<IVideoService, VideoService>();
builder.Services.AddTransient<IArtistService, ArtistService>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<ISongService, SongService>();

// ��������� ������� MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles(); // ������������ ������� � ������ � ����� wwwroot

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Songs}/{action=Index}/{id?}");

app.Run();
