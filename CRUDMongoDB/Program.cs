using CRUDMongoDB.Models;
using CRUDMongoDB.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);




builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
builder.Services.AddSingleton<SubmissionService>();

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//})
//    .AddCookie()
//    .AddOpenIdConnect(options =>
//    {
//        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//        options.RequireHttpsMetadata = true;
//        options.ClientId = ConfigurationPath["Okta:ClientId"];
//    })
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
