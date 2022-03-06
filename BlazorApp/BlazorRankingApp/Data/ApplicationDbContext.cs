using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorRankingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // db와 code를 연결시켜주는 핵심 역할
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}