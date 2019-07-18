namespace ConsoleApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConsoleApplication1.Migrations.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ConsoleApplication1.Migrations.StudentContext context)
        {
            DepartmentSeed.Seed(context, "电子信息工程学院", "第一大学院", "001");
            DepartmentSeed.Seed(context, "汽车工程学院", "第二大学院", "002");
            DepartmentSeed.Seed(context, "机电工程学院", "第三大学院", "003");
            context.SaveChanges();
            StudentSeed.Seed(context);
            context.SaveChanges();
            StudentSeed._GarbageClear();
            context.SaveChanges();
        }
    }
}
