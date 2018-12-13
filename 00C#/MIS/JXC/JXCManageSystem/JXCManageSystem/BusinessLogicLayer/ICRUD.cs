using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    /// <summary>
    /// 数据维护统一接口
    /// </summary>
    public interface ICRUD<T>
    {
        bool Add(T entity);   //增加记录
        bool Delete(T entity);  //删除记录
        bool Edit(T entity);  //修改记录
        List<T> GetAll();   //查询所有记录
        T GetByID(int id);  //按主键查询单条记录
    }
}
