using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using MyFirstAPI.Models;

namespace MyFirstAPI.Models
{
    public class MyFirstAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public MyFirstAPIDBContext(DbContextOptions<MyFirstAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("CharDataService");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        //vector<character> 
        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<House> House { get; set; } = null!;
    }
}





//using Microsoft.EntityFrameworkCore;
//using System.Diagnostics.CodeAnalysis;
//using MyFirstAPI.Models;

//namespace MyFirstAPI.Models
//{
//    public class MyFirstAPIDBContext : DbContext
//    {
//        protected readonly IConfiguration Configuration;

//        public MyFirstAPIDBContext(DbContextOptions<MyFirstAPIDBContext> options, IConfiguration configuration)
//            : base(options)
//        {
//            Configuration = configuration;
//        }

//        protected override void OnConfiguring(DbContextOptionsBuilder options)
//        {
//            var connectionString = Configuration.GetConnectionString("CustomerDataService");
//            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
//        }

//        //vector<customer> 
//        public DbSet<Customer> Customers { get; set; } = null!;
//        public DbSet<Email> Emails { get; set; } = null!;
//    }
//}

