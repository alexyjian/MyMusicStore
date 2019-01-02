using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer;
using Enity;

namespace JXCMIS
{
    public partial class Frm_Employee : JXCMIS.CommonForm.BaseInfoForm
    {
        private EmployeeBLL _employeeBLL;   //数据访问的对象
        private List<Employee> _list;             //临时保存的数据集合
        private Employee _employeeObj;       //临时保存的单个数据
        
        public Frm_Employee()
        {
            InitializeComponent();
            
            //对象初始化
            _employeeBLL = new EmployeeBLL();
            QueryData();
        }


        //查询数据，并在DGV上显示
        private void QueryData()
        {
            _list = _employeeBLL.GetAll();
            dgvEmployee.DataSource = _list;

            dgvEmployee.AutoGenerateColumns = false;
            dgvEmployee.Columns["PassWord"].Visible = false;
            dgvEmployee.Columns["BaseFunction"].Visible = false;
            dgvEmployee.Columns["PurchaseFunction"].Visible = false;
            dgvEmployee.Columns["EmployeeFunction"].Visible = false;
        }

        private void dgvEmployee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvEmployee.Columns[e.ColumnIndex].Name == "sex")
            {
                if (Convert.ToBoolean(e.Value))
                    e.Value = "男";
                else
                    e.Value = "女";

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
