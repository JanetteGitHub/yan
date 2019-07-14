
namespace yan.Domain.Models
{
    using System.Data.Entity;

    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<yan.Common.Models.ServiciosyNegocios> ServiciosyNegocios { get; set; }
    }
}
