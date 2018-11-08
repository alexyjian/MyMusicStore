using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst1108.Migrations
{
    internal sealed class Configuration: DbMigrationsConfiguration<CodeFirst1108.DataContext.StuDBcontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CodeFirst1108.DataContext.StuDBcontext context)
        {
            DepartmentSeed.Seed(context);
        }
    }
}
