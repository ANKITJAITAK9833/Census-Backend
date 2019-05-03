namespace DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DAL.ENTITY;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DataCollectionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Seed method for adding dummy data to db
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(DAL.DataCollectionContext context)
        {
            var users = new List<User> {
            new User { EmailId = "approver01@nagarro.com", Password = "approver", FirstName = "Approver", LastName = "Ji", ProfileImage = "‪userImage.jpg", AadharNumber = "012345678911", IsApprover = true },
                new User { EmailId = "approver01@@nagarro.com", Password = "approver", FirstName = "Approver", LastName = "Ji", ProfileImage= "‪userImage.jpg", AadharNumber = "012345678912", IsApprover = true }

                };


            users.ForEach(m => context.Users.AddOrUpdate(m));
            context.SaveChanges();

        }
    }
}
