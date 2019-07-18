namespace ConsoleApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConsoleApplication1.CodeFirstModels.CourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ConsoleApplication1.CodeFirstModels.CourseContext context)
        {
            context.Database.ExecuteSqlCommand("delete Departments");
            DepartmentSeed.Seed(context, "电子信息工程学院", "第一大学院", "001");
            DepartmentSeed.Seed(context, "汽车工程学院", "第二大学院", "002");
            DepartmentSeed.Seed(context, "机电工程学院", "第三大学院", "003");
            DepartmentSeed.Seed(context, "贸易旅游学院", "第四大学院", "004");
            context.SaveChanges();
        }
    }
}
