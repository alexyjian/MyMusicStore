namespace _11_5.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_11_5.CourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(_11_5.CourseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Database.ExecuteSqlCommand("delete students");
            context.Database.ExecuteSqlCommand("delete courses");
            context.Database.ExecuteSqlCommand("delete departments");

            StudentSeed.Seed(context);
            //��ʼ��ѧԺ����
            var d1 = new Department()
            {
                Name = "������Ϣ����ѧԺ",
                SortCode="001",
                Description="��һ��ѧԺ"
            };

            var d2 = new Department()
            {
                Name = "���繤��ѧԺ",
                SortCode = "002",
                Description = "�ڶ���ѧԺ"
            };

            var d3 = new Department()
            {
                Name = "��������ѧԺ",
                SortCode = "003",
                Description = "������ѧԺ"
            };
            var d4 = new Department()
            {
                Name = "�ƾ�������ѧԺ",
                SortCode = "004",
                Description = "���Ĵ�ѧԺ"
            };
            context.Departments.Add(d1);
            context.Departments.Add(d2);
            context.Departments.Add(d3);
            context.Departments.Add(d4);
            context.SaveChanges();

            
            var c1 = new Course()
            {
                Title = "MISʵս����",
                Credit= 17,
                Department=context.Departments.SingleOrDefault(x=>x.Name == "������Ϣ����ѧԺ")
            };

            var c2 = new Course()
            {
                Title = "��������",
                Credit = 13,
                Department = context.Departments.SingleOrDefault(x => x.Name == "�ճ�ѧԺ")
            };

            var c3 = new Course()
            {
                Title = "webʵս����",
                Credit = 17,
                Department = context.Departments.SingleOrDefault(x => x.Name == "������Ϣ����ѧԺ")
            };

            var c4 = new Course()
            {
                Title = "��ҵ��ͼ",
                Credit = 17,
                Department = context.Departments.SingleOrDefault(x => x.Name == "����ѧԺ")
            };

            var c5 = new Course()
            {
                Title = "���������",
                Credit = 17,
                Department = context.Departments.SingleOrDefault(x => x.Name == "����ѧԺ")
            };

            var c6 = new Course()
            {
                Title = "����Ӫ��",
                Credit = 7,
                Department = context.Departments.SingleOrDefault(x => x.Name == "�ƾ�ѧԺ")
            };

            context.Course.Add(c1);
            context.Course.Add(c2);
            context.Course.Add(c3);
            context.Course.Add(c4);
            context.Course.Add(c5);
            context.Course.Add(c6);
            context.SaveChanges();
        }
    }
}
