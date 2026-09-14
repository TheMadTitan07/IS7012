using Microsoft.EntityFrameworkCore;

public class RecruitCatFieldaoContext(DbContextOptions<RecruitCatFieldaoContext> options) : DbContext(options)
{
    public DbSet<RecruitCatFieldao.Models.Candidate> Candidate { get; set; } = default!;
    public DbSet<RecruitCatFieldao.Models.Company> Company { get; set; } = default!;
    public DbSet<RecruitCatFieldao.Models.Industry> Industry { get; set; } = default!;
    public DbSet<RecruitCatFieldao.Models.JobTitle> JobTitle { get; set; } = default!;
}
