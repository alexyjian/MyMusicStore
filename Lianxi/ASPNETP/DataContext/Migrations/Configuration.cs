namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProductDbContext context)
        {
            context.Database.ExecuteSqlCommand("delete products");
            context.Database.ExecuteSqlCommand("delete categories");
            SeedMethod.CategoryandProductSeed(context);
        }
    }
}
