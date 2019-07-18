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
            DepartmentSeed.Seed(context, "������Ϣ����ѧԺ", "��һ��ѧԺ", "001");
            DepartmentSeed.Seed(context, "��������ѧԺ", "�ڶ���ѧԺ", "002");
            DepartmentSeed.Seed(context, "���繤��ѧԺ", "������ѧԺ", "003");
            DepartmentSeed.Seed(context, "ó������ѧԺ", "���Ĵ�ѧԺ", "004");
            context.SaveChanges();
        }
    }
}
