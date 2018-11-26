namespace CodeFirstDemo.Migrations
{
    using CodeFirstModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstDemo.CodeFirstModels.CourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        //种子方法
        protected override void Seed(CodeFirstDemo.CodeFirstModels.CourseContext context)
        {
            ////初始化数据库
            ////删除该表之前的数据，先外后主
            //context.Database.ExecuteSqlCommand("delete courses");
            //context.Database.ExecuteSqlCommand("delete students");
            //context.Database.ExecuteSqlCommand("delete departments");
            ////创建顺序，先主后外
            //DepartmentSeed.Seed(context);
            //CourseSeed.Seed(context);
            //StudentSeed.Seed(context);
        }
    }
}
