using BLL.Service.Attachment;
using BLL.Service.Departments;
using BLL.Service.Employees;
using DAL;
using Microsoft.AspNetCore.Mvc;
using PL.Extention;
using PL.Profiles;

var builder = WebApplication.CreateBuilder(args);

#region Configure Service

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
}); 

builder.Services.AddPersistanceService(builder.Configuration);
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAttachement, Attachement>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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
