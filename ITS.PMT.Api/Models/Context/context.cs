using Microsoft.EntityFrameworkCore;

namespace ITS.PMT.Api.Models.Context
{
    public class context : DbContext
    {
#pragma warning disable CS1591
        public context(DbContextOptions<context> options)
           : base(options)
        {
            //Database.EnsureCreated();
        }

    }
#pragma warning restore CS1591
}
