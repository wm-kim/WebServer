using Microsoft.AspNetCore.Mvc;
using HelloEmpty.Models;

namespace HelloEmpty.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // 어떤 화면을 보여줄 것인가, 어떤 정보를 연동시켜줄 것인가
            HelloMessage msg = new HelloMessage() { Message = "Wecolome to Asp.Net MVC!" };

            // 미리 정의된 데이터 구조로 넘겨도 되고 viewBag을 이용해서 데이터를 넘길 수 있음
            // View에게 데이터를 넘길 수 있는 바구니, Dynamic time
            ViewBag.Noti = "Input message and click submit";

            return View(msg);
        }

        // POST를 처리하는 Index
        [HttpPost]
        public IActionResult Index(HelloMessage obj)
        {
            ViewBag.Noti = "Message Changed";
            return View(obj);
        }
    }

}

// MVC같은 경우 파일이름을 멋대로 만들 수 없고. 이름을 Convention에 맞춰서 똑같이 View를 맞춰야함