using Artist.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Artist;

var builder = WebApplication.CreateBuilder(args);

// ������ ������ �� ����������.
builder.Services.AddControllersWithViews();

// ������ �������� ���� ����� ArtistDbContext
builder.Services.AddDbContext<ArtistDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ArtistDatabase")));

// �������� AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// ������������ HTTP pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ������������ ������������� ��� ����������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Artist}/{action=Index}/{id?}");

// ������ ������� ��� ���������� FavoriteArtists
app.MapControllerRoute(
    name: "favoriteArtists",
    pattern: "{controller=FavoriteArtists}/{action=Index}/{id?}");

app.Run();
