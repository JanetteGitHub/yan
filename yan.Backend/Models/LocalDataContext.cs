
namespace yan.Backend.Models
{
    using Domain.Models;
    public class LocalDataContext:DataContext
    {
        public System.Data.Entity.DbSet<yan.Common.Models.ServiciosyNegocios> ServiciosyNegocios { get; set; }
    }
}