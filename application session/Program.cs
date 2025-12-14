using application_session.Filters;
using Serilog;


var builder = WebApplication.CreateBuilder(args);


// 🔹 Configurer Serilog pour écrire dans un fichier
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information() // niveau minimal des logs
    .WriteTo.File(
        "Logs/log-.txt",             // chemin du fichier (sera créé automatiquement)
        rollingInterval: RollingInterval.Day, // un fichier par jour
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message}{NewLine}{Exception}"
    )
    .CreateLogger();

// Utiliser Serilog comme logger principal
builder.Host.UseSerilog();




//Active le système MVC dans ASP.NET Core
builder.Services.AddControllersWithViews();
//Active la gestion des sessions dans l’application.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // durée de vie session
    options.Cookie.HttpOnly = true;                 // sécurité côté client
    options.Cookie.IsEssential = true;             // obligatoire pour GDPR
    options.Cookie.SameSite = SameSiteMode.Strict; // pour éviter la réutilisation
});

//Enregistre ton filtre RequireLoginFilter dans le conteneur d’injection de dépendances (DI).
builder.Services.AddScoped<RequireLoginFilter>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
