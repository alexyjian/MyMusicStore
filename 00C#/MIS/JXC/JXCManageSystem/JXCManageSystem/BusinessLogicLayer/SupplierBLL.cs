using DataAccessLayer;
using Enity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class SupplierBLL : ICRUD<Supplier>
    {
        private SqlCommand _cmd;
        public SupplierBLL()
        {
            _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
        }

        public bool Add(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public List<Supplier> GetAll()
        {
            _cmd.CommandText = "GetAllSuppliers";
            _cmd.Parameters.Clear();
            var list = new List<Supplier>();
            var data = DBAccess.ReadData(_cmd);
            while (data.Read())
            {
                var item = new Supplier();
                item .SupplierID= Convert.ToInt32(data["SupplierID"]);
                item.SupplierName = data["SupplierName"].ToString();
                item.Phone = data["Phone"].ToString();
                list.Add(item);
            }
            data.Close();
            return list;
        }

        public Supplier GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
