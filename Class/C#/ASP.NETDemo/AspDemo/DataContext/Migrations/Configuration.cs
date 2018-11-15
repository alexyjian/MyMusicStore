namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext.StuDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext.StuDBContext context)
        {
            //DepartmentSeed.Seed(context, "电子信息工程学院", "", "001");
            //DepartmentSeed.Seed(context, "机电工程学院", "", "002");
            //DepartmentSeed.Seed(context, "汽车工程学院", "", "003");
            //DepartmentSeed.Seed(context, "贸易旅游学院", "", "004");
            //DepartmentSeed.Seed(context, "环境与食品检测学院", "", "005");
            //context.SaveChanges();
            //StudentSeed.Seed(context);
            //context.SaveChanges();
            //StudentSeed.GarbageClear();
            //context.SaveChanges();
        }
    }
}
