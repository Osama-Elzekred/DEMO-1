using DEMO_1.BLL;
using Microsoft.AspNetCore.Mvc;

int uid = 0;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<Istudent,StudentBLL>();
builder.Services.AddSession();
var app = builder.Build();

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("2: HISINBERG" + Environment.NewLine);

//});
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Add your service here
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Use(async (context, next) =>
{
    context.Session.SetString("Uname", $"3amil {uid++}");
    // get the setion value in another page
    //string name = context.Session.GetString("Uname");
    //ViewData = HttpContext.Session.GetString("Uname");
   
    //await context.Response.WriteAsync("1: WHAT IS MY NAME ??" + Environment.NewLine);
    //await next();
    await next.Invoke();
    //await context.Response.WriteAsync("1: UR GOD DAMM RIGHT !");
});

app.Run();
