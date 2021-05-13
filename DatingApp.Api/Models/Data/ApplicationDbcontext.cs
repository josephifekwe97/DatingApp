
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Api.Models.Data
{
    public class ApplicationDbcontext  : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext>options): base(options){}
        
     
         public DbSet<Value> values { get; set; }

    }
}