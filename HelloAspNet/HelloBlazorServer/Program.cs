using HelloBlazorServer.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// ���������� ��� ����ϰ� ������ �ݵ�� �߰������ UI������ �����Ͽ� ����� �� �ִ�.
// Singleton �������� �߰��Ȱ��̱� ������ � Client�� ������ ��� ����
// ������� �������� �ʰ� User���� �ٸ��� ������ �� �ִ�.
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// Routing�κ� : � �ּҸ� ��� �˰� � URL�� ������������
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
