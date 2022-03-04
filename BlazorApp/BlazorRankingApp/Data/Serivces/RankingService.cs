using BlazorRankingApp.Data.Models;

namespace BlazorRankingApp.Data.Serivces
{
    public class RankingService
    {
        // DB에 관련된 대장을 주입시켜야함
        ApplicationDbContext _context;
        

        // DI에 의해서 자동으로 생성되어 넣어주게 될 것이다.
        public RankingService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create, 없던 id가 나오므로 반환
        public Task<GameResult> AddGameResult(GameResult gameResult)
        {
            // DB에 접근해서 바로 넣는다. data에 ID가 추가가됨
            _context.GameResults.Add(gameResult);
            _context.SaveChanges(); // DB sync

            return Task.FromResult(gameResult);
        }

        // Read, ApplicationDbContext를 통해서 DB를 긁어옴
        public Task<List<GameResult>> GetGameResultAsync()
        {
            // 실제 DB에접근하는 것과 똑같은 효과를 봄
            List<GameResult> results = _context.GameResults
                                    .OrderByDescending(item => item.Score)
                                    .ToList();

            return Task.FromResult(results);
        }

        // Udpate 성공 여부만 반환 
        public Task<bool> UpdateGameResult(GameResult gameResult)
        {
            var findResult = _context.GameResults.Where(x => x.Id == gameResult.Id)
                .FirstOrDefault();

            if(findResult == null)
                return Task.FromResult(false);

            findResult.UserName = gameResult.UserName;
            findResult.Score = gameResult.Score;
            _context.SaveChanges(); // DB 동기화

            return Task.FromResult(true);
        }

        // Delete
        public Task<bool> DeleteGameResult(GameResult gameResult)
        {
            var findResult = _context.GameResults.Where(x => x.Id == gameResult.Id)
                .FirstOrDefault();

            if (findResult == null)
                return Task.FromResult(false);

            _context.GameResults.Remove(gameResult);
            _context.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
