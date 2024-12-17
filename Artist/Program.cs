using Artist.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Identity; // Додано для Identity
using Artist;

var builder = WebApplication.CreateBuilder(args);

// Додаємо сервіси для Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ArtistDbContext>()
    .AddDefaultTokenProviders(); // Додаємо провайдери токенів для реєстрації та скидання пароля

// Додаємо сервіси до контейнера.
builder.Services.AddControllersWithViews();

// Додаємо контекст бази даних ArtistDbContext
builder.Services.AddDbContext<ArtistDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ArtistDatabase")));

// Реєструємо AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Налаштування HTTP pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Додано для Identity: UseAuthentication перед UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

// Налаштування маршрутизації для контролерів
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Artist}/{action=Index}/{id?}");

// Додаємо маршрут для контролера FavoriteArtists
app.MapControllerRoute(
    name: "favoriteArtists",
    pattern: "{controller=FavoriteArtists}/{action=Index}/{id?}");

app.Run();
