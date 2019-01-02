using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SqlConnTest()
        {
            //测试SQLServer的连接环境
            //思想：程序执行的结果与预期的结果是否一致

            //项目的连接串，测试相应的连接环境是否正常
            var sqlConnectionString = "server = 10.88.240.24;database=onelibrary;integrated securiry=true";
            var conn = new SqlConnection(sqlConnectionString);

            //测试SQLServer的连接与预期结果是否一至
            try
            {
                conn.Open();
                //测试语句  断言Assert
                //如果conn不为空，表示与预期结果一样，测试通过
                Assert.IsNotNull(conn);
            }
            catch
            {
                Assert.Fail("数据库连接失败");
            }
        }
    }
}
