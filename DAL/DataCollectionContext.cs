using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DAL.ENTITY;
namespace DAL
{
    public class DataCollectionContext : DbContext
    {
        public DataCollectionContext() : base("DataCollectionContext")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRequestStatus> UserRequestStatus { get; set; }
        public DbSet<HouseListing> HouseListings { get; set; }
        public DbSet<PopulationRegistration> PopulationRegistrations { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
          
        }
    }
}
