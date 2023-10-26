using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VendedoresMVC.Data;
using VendedoresMVC.Services;

var builder = WebApplication.CreateBuilder(args);

var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS }
};

//// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionStringMysql = builder.Configuration.GetConnectionString("VendedoresMVCContext");
builder.Services.AddDbContext<VendedoresMVCContext>(options => options.UseMySql(connectionStringMysql, ServerVersion.Parse("8.0.25-mysql")));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartamentService>();

var app = builder.Build();
app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Abaixo exemplo de como rodar a injeção de dependência, no caso o SeedService adicionado acima: "builder.Services.AddScoped<SeedingService>();",
//no Startup do programa. Apesar de ter uma lógica para não repopular o banco, vou deixar aqui comentado pra
//não ficar rodando sempre que executar o programa.

//app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();