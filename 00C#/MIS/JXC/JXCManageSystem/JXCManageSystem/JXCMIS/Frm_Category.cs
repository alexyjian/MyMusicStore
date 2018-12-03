using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer;
using Enity;
using System.Linq;

namespace JXCMIS
{
    public partial class Frm_Category : JXCMIS.CommonForm.BaseInfoForm
    {
        private CategoryBLL _categoryBll;   //数据访问的对象
        private List<Category> _list;             //临时保存的数据集合
        private Category _categoryObj;       //临时保存的单个数据
        public Frm_Category()
        {
            InitializeComponent();

            //对象初始化
            _categoryBll = new CategoryBLL();

            //数据显示
            QueryData();
        }

        //查询数据，并在DGV上显示
        private void QueryData()
        {
            _list = _categoryBll.GetAll();
            dgvCategory.DataSource = _list;
        }
        //刷新数据后定位到此行
        private void LocationNewRow(int id)
        {
            int i;
            for( i = 0;i<_list.Count;i++)
            {
                if (_list[i].CategoryID == id)
                    break;
            }
            dgvCategory.Rows[i].Selected = true;  //选定下标为i的行
            dgvCategory.CurrentCell = dgvCategory.Rows[i].Cells[0];
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //初始化
            txtCategoryName.Text = string.Empty;
            txtCategoryName.Enabled = true;   //因为删除时 此控件为只读，新增和更新时启用
        }

        //新增、更新和删除时，存盘的工作
        private void btnSave_Click(object sender, EventArgs e)
        {
            switch(op)
            {
                case EnumOperation.Insert:
                    _categoryObj = new Category()
                    {
                        CategoryName = txtCategoryName.Text.Trim()
                    };
                    //检测是否有重复的分类
                    if(_list.FirstOrDefault(x=>x.CategoryName == _categoryObj.CategoryName)!=null)
                    {
                        MessageBox.Show("不能添加重复的分类");
                        return;
                    }
                    if(_categoryBll.Add(_categoryObj))
                    {
                        //重新查询数据，并对正处理的数据记录进行定位
                        QueryData();
                        var id = _list.FirstOrDefault(x => x.CategoryName == _categoryObj.CategoryName).CategoryID;
                        LocationNewRow(id);
                    }
                    break;

                case EnumOperation.Update:
                    if(_categoryObj!=null)
                    {
                        _categoryObj.CategoryName = txtCategoryName.Text.Trim();
                        if(_categoryBll.Edit(_categoryObj))
                        {
                            //重新查询数据，并对正处理的数据记录进行定位
                            QueryData();
                            var id = _list.FirstOrDefault(x => x.CategoryName == _categoryObj.CategoryName).CategoryID;
                            LocationNewRow(id);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请先选择一条分类记录");
                        return;
                    }
                    break;

                case EnumOperation.Delete:
                    if (_categoryObj != null)
                    {
                        if (_categoryBll.Delete(_categoryObj))
                        {
                            MessageBox.Show("删除成功");
                            QueryData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("请先选择一条分类记录");
                        return;
                    }
                    break;

                case EnumOperation.None:
                default:
                    break;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //初始化
            txtCategoryName.Text = string.Empty;
            txtCategoryName.Enabled = true;   //因为删除时 此控件为只读，新增和更新时启用

            //将用户所选放到下区的文本框
            if (_categoryObj != null)
                txtCategoryName.Text = _categoryObj.CategoryName;
        }

        //处理用户选定一条记录
        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //选定该行
            dgvCategory.CurrentRow.Selected = true;
            try
            {
                _categoryObj = _list[e.RowIndex];
                if(op== EnumOperation.Update || op == EnumOperation.Delete)
                {
                    txtCategoryName.Text = _categoryObj.CategoryName;
                }
            }
            catch { }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            txtCategoryName.Text = string.Empty;
            //删除时，不允许用户编辑
            txtCategoryName.Enabled = false;
            if (_categoryObj != null)
            {
                txtCategoryName.Text = _categoryObj.CategoryName;
            }
        }
    }
}
