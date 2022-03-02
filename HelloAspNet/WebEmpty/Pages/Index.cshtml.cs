using HelloEmpty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloEmpty.Pages
{
    public class IndexModel : PageModel
    {
        // Controller 부분부터 만들기
        // 모델 바인딩 참가 암시
        [BindProperty]
        public HelloMessage HelloMsg { get; set; }

        public string Noti { get; set; }

        // 처음은 이것
        // return view 안해줘도 됨 - Index Model 자체가 view랑 엮여있음
        public void OnGet()
        {
            this.HelloMsg = new HelloMessage()
            { Message = "Hello Razor Pages" };
        }

        // 버튼 클릭하면 여기로 오도록
        public void OnPost()
        {
            this.Noti = "Message Changed";
        }
    }
}
