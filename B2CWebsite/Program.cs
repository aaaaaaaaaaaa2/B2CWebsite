using B2CWebsite.Models;
using Microsoft.EntityFrameworkCore;
using AspNetCoreHero.ToastNotification;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<DrugStoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbB2CWebsite")));
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 3;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
});
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(p =>
    {
        //p.Cookie.Name = "UserLoginCookie";
        //p.ExpireTimeSpan = TimeSpan.FromDays(1);
        p.LoginPath = "/login.html";
        //p.LogoutPath = "/dang-xuat/html";
        p.AccessDeniedPath = "/not-found.html";
    });



var stringConnectdb = builder.Configuration.GetConnectionString("dbB2CWebsite");
builder.Services.AddDbContext<DrugStoreContext>(option => option.UseSqlServer(stringConnectdb));
builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));





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
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
