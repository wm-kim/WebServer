var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
// MVC�� ����ϰڴٰ� ����
builder.Services.AddControllersWithViews();

var app = builder.Build();

// �ּҿ� home/index��� ġ�� ��
// ó�� home�� controller�� �ν��ϰ�, Index�� action���� �ν�
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
