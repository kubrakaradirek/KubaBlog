using KubaBlog.DataAccessLayer.Concrete;
using KubaBlog.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.Password.RequireUppercase = false;
    x.Password.RequireNonAlphanumeric = false;

})
    .AddEntityFrameworkStores<Context>();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddMvc(config =>
{
    // Yetkilendirme politikas�n� uygulamak i�in filtre ekleme
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();
builder.Services.AddAuthentication(
       CookieAuthenticationDefaults.AuthenticationScheme)
      .AddCookie(x =>
      {
          x.LoginPath = "/Login/Index";
      }
    );
builder.Services.ConfigureApplicationCookie(options =>
{
    //Cookie Settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromSeconds(100);
    options.AccessDeniedPath = new PathString("/Login/AccessDenied");
    options.LoginPath = "/Login/Index/";
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Hatal� sayfa i�in
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseSession();

app.UseRouting();

// Kimlik do�rulama ve yetkilendirme kullan�m�
app.UseAuthorization();

//Area alan�
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}");


app.Run();
