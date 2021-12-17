using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AssessmentPaper.WebApi.Areas.Data;

public class IdentityDatabaseContext : IdentityDbContext {
    public IdentityDatabaseContext(DbContextOptions<IdentityDatabaseContext> options) : base(options){}
}