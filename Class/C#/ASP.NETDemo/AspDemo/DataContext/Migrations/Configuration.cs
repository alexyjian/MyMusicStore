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
            //DepartmentSeed.Seed(context, "������Ϣ����ѧԺ", "", "001");
            //DepartmentSeed.Seed(context, "���繤��ѧԺ", "", "002");
            //DepartmentSeed.Seed(context, "��������ѧԺ", "", "003");
            //DepartmentSeed.Seed(context, "ó������ѧԺ", "", "004");
            //DepartmentSeed.Seed(context, "������ʳƷ���ѧԺ", "", "005");
            //context.SaveChanges();
            //StudentSeed.Seed(context);
            //context.SaveChanges();
            //StudentSeed.GarbageClear();
            //context.SaveChanges();
        }
    }
}
