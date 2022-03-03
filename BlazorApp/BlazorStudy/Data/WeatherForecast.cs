using System.ComponentModel.DataAnnotations;

namespace BlazorStudy.Data
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        // 정말 중요하고 필수적이라면. 범위도 제한 가능
        [Required(ErrorMessage = "Need TemperatureC")]
        [Range(typeof(int), "-100", "100")]
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        
        [Required(ErrorMessage = "No Summary!")]
        [StringLength(10, MinimumLength =2, ErrorMessage ="2~10")]
        public string? Summary { get; set; }
    }
}