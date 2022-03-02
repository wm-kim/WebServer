using HelloEmpty.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloEmpty.Controllers
{
    // 라우팅 자체를 여기서 따로 따로 설정함.
    // 지금껏 홈페이지에서 경로 설정하고 어떤 페이지를 보여줄지 정하고 있었음
    // Razor의 경우 Pages 폴더 산하에서 페이지를 검색함.
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // get put post 다양한 방식이 있음
        [HttpGet]
        public List<HelloMessage> Get()
        {
            List<HelloMessage> messages = new List<HelloMessage>();
            messages.Add(new HelloMessage() { Message = "Hello WEP API 1" });
            messages.Add(new HelloMessage() { Message = "Hello WEP API 2" });
            messages.Add(new HelloMessage() { Message = "Hello WEP API 3" });
            return messages; // MVC에서는 view를 반환했음
        }
    }
}
