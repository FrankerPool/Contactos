using Microsoft.EntityFrameworkCore;

namespace CRUDNet8MVC.Data
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions <AplicationDBContext> options) : base(options)
        {
            
        }
    }
}
