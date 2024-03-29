using ERP_WEB_API.DataAccess;
using Hangfire;
using Microsoft.AspNetCore.Authentication.Cookies;
using PTLRealERP.Configuration;
using RealERPLIB.DapperRepository;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IDbConnection>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new SqlConnection(connectionString);
});

builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfireServer();

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IDapperService, DapperService>();
builder.Services.AddScoped<IProcessAccess, ProcessAccess>();

builder.Services.AddAllRepository();//Register all repository by DependencyInjection

builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout duration
});

builder.Services.AddAuthenticationAndAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHangfireDashboard("/mydashboard");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
// Step 2: Use session middleware
app.UseSession();
// Map API controllers
app.UseEndpoints(endpoints => endpoints.MapControllers());
//app.MapControllers();  // Add this line to enable API routing
//app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});
app.Run();
