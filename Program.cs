var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseEndpoints(endpoints =>
{
    // 1. Route cho Student/Index -> Admin/Student/List
    // (Mục đích: Mặc dù URL là Admin/Student/List, nó ánh xạ tới Action List)
    endpoints.MapControllerRoute(
        name: "student_list_route",
        pattern: "Admin/Student/List",
        defaults: new { controller = "Student", action = "Index" }); // Map /Admin/Student/List -> StudentController.Index

    // 2. Route cho Student/Create -> Admin/Student/Add
    endpoints.MapControllerRoute(
        name: "student_add_route",
        pattern: "Admin/Student/Add",
        defaults: new { controller = "Student", action = "Create" });

    // 3. Route Mặc định phải luôn được đặt cuối cùng
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
