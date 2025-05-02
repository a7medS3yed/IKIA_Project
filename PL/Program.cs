using BLL.Service.Departments;
using DAL;
using PL.Extention;

var builder = WebApplication.CreateBuilder(args);

#region Configure Service

// Add services to the container.
builder.Services.AddControllersWithViews(); 

builder.Services.AddPersistanceService(builder.Configuration);
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

#endregion

var app = builder.Build();

#region InitializeDatabase

app.InitializeDatabase();

#endregion

#region Configure

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets(); 

#endregion


app.Run();
