namespace BlazorRankingApp.Data.Models
{
    public class GameResult
    {
        public int Id { get; set; } // DB에서 각 데이터의 id
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}
