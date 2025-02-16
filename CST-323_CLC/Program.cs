using CST_323_CLC.Services.Business;
using CST_323_CLC.Services.Data_Access;
using CST_323_CLC.Services.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<UserDatabaseSettings>(builder.Configuration.GetSection("UserDatabase"));
builder.Services.Configure<PetDatabaseSettings>(builder.Configuration.GetSection("PetDatabase"));

// Dependency Injection

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserDAO, UserDAO>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IPetDAO, PetDAO>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddControllersWithViews();

// Create session
builder.Services.AddSession(options =>
{
    // Logout after 5 minutes of idle time
    options.IdleTimeout = TimeSpan.FromMinutes(5);
});

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

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
