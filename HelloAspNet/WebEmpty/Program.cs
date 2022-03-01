var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
// MVC를 사용하겠다고 선언
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 주소에 home/index라고 치는 것
// 처음 home은 controller로 인식하고, Index는 action으로 인식
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
