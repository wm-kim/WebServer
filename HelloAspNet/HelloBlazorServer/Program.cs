using HelloBlazorServer.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// 실질적으로 어딘가 사용하고 싶으면 반드시 추가해줘야 UI에서도 접근하여 사용할 수 있다.
// Singleton 전역으로 추가된것이기 때문에 어떤 Client던 들어오면 사용 가능
// 모두한테 열어주지 않고 User별로 다르게 열어줄 수 있다.
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

// Routing부분 : 어떤 주소를 어떻게 알고 어떤 URL과 연동시켜줄지
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
