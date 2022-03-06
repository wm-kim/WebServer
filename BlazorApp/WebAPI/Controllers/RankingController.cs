using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedData.Models;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    // REST 공식적인 표준 스펙은 아님
    // 원래 있던 HTTP 통신에서 기능을 '재사용'해서 데이터 송수신 규칙을 만든 것

    // ApiController 특징 

    // [controller]은 Controller 앞에있는 이름을 따서 넣어줌
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        // DB에 접근할 수 있게끔 Dpendency Injection
        ApplicationDbContext _context;

        public RankingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        // Create, Body에 있는 정보를 추출하기 위해서 gameresult로 받아줌
        // json으로 보내줬는데도 알아서 parsing해서 받아줌
        public GameResult AddGameResult([FromBody] GameResult gameresult)
        {
            _context.GameResults.Add(gameresult);
            _context.SaveChanges();

            return gameresult;
        }

        // Read
        [HttpGet] // 모든 item을 주세요, 함수 이름은 자유
        public List<GameResult> GetGameResult()
        {
            List<GameResult> results = _context.GameResults
                    .OrderByDescending(item => item.Score)
                    .ToList();

            return results;
        }

        // 어떤 요청이 왔을 때 어떤걸 사용해야하는지 구분하기 위해 {id} 추가적인 정보
        [HttpGet("{id}")]
        public GameResult GetGameResult(int id)
        {
            GameResult result = _context.GameResults
                    .Where(item => item.Id == id)
                    .FirstOrDefault();

            return result;
        }

        // Update gameResult : 무엇을 갱신할 건지
        [HttpPut]
        public bool UpdateGameResult([FromBody] GameResult gameResult)
        {
            // 없는지 확인
            var findResult = _context.GameResults
                .Where(x => x.Id == gameResult.Id)
                .FirstOrDefault();

            if (findResult == null) return false;

            findResult.UserName = gameResult.UserName;
            findResult.Score = gameResult.Score;
            _context.SaveChanges();

            return true;
        }

        // Delete
        [HttpDelete("{id}")]
        public bool DeleteGameResult(int id)
        {
            var findResult = _context.GameResults
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (findResult == null) return false;

            _context.GameResults.Remove(findResult);
            _context.SaveChanges();

            return true;
        }
    }
}
