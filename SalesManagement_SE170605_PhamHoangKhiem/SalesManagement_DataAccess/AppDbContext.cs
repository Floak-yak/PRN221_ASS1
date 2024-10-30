using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesManagement_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryObject> Categories { get; set; } = null!;
        public virtual DbSet<MemberObject> Members { get; set; } = null!;
        public virtual DbSet<OrderDetailObject> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderObject> Orders { get; set; } = null!;
        public virtual DbSet<ProductObject> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString(), options => options.EnableRetryOnFailure());

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        private string? GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true).Build();
            return configuration["ConnectionStrings:DefaultConnection"];
        }
    }
}
