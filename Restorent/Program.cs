using System.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restorent;
using Restorent.Models;
using Restorent.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc(x => x.EnableEndpointRouting = false);

builder.Services.AddScoped<IRepository<MasterCategoryMenu>, MasterCategoryMenuRepository>();
builder.Services.AddScoped<IRepository<MasterContactUsInformation>, MasterContactUsInformationRepository>();
builder.Services.AddScoped<IRepository<MasterItemMenu>, MasterItemMenuRepository>();
builder.Services.AddScoped<IRepository<MasterMenu>, MasterMenuRepository>();
builder.Services.AddScoped<IRepository<MasterOffer>, MasterOfferRepository>();
builder.Services.AddScoped<IRepository<MasterPartner>, MasterPartnerRepository>();
builder.Services.AddScoped<IRepository<MasterService>, MasterServiceRepository>();
builder.Services.AddScoped<IRepository<MasterSlider>, MasterSliderRepository>();
builder.Services.AddScoped<IRepository<MasterSocialMedia>, MasterSocialMediaRepository>();
builder.Services.AddScoped<IRepository<MasterWorkingHour>, MasterWorkingHourRepository>();
builder.Services.AddScoped<IRepository<SystemSetting>, SystemSettingRepository>();
builder.Services.AddScoped<IRepository<TransactionBookTable>, TransactionBookTableRepository>();
builder.Services.AddScoped<IRepository<TransactionContactUs>, TransactionContactUsRepository>();
builder.Services.AddScoped<IRepository<TransactionNewsletter>, TransactionNewsletterRepository>();


builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(x =>
{

    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
    
    x.EnableSensitiveDataLogging();
   // x.UseQueryTrackingBehavior();

});



builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Admin/Account/Login";
});




//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//      .AddCookie(options =>
//      {
//          options.LoginPath = "/Admin/Account/Login";
//          options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
//          //options.Cookie.HttpOnly = true;
//          //options.AccessDeniedPath = "/account/accessdenied";
//          //options.SlidingExpiration = true;


//      });



builder.Services.Configure<IdentityOptions>(x =>
{ 

    x.Password.RequireDigit = false;
    x.Password.RequiredLength = 3;
    x.Password.RequireLowercase = false;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;


});



var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseMvc();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(app =>
{

    app.MapControllerRoute(
         name: "areas",
         pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}"
         );

    app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
            );

});
//app.UseRedirectInvalidPathMiddleware();


app.Run();
