
namespace yan.Backend.Models
{
    using Domain.Models;
    public class LocalDataContext:DataContext
    {
        public new System.Data.Entity.DbSet<yan.Common.Models.ServiciosyNegocios> ServiciosyNegocios { get; set; }
    }
}