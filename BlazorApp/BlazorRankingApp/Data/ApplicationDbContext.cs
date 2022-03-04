using BlazorRankingApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorRankingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // GameResults를 DB에서 사용한다는 가정을 한다.
        // 나중에 서버를 띄우면 이부분도 자동으로 DB에 똑같이 모델링을 이용하여 갱신한다.
        public DbSet<GameResult> GameResults { get; set; }
        // db와 code를 연결시켜주는 핵심 역할
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}