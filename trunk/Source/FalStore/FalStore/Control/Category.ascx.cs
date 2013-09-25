using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BIZ;
using Entity;
using System.Data;
namespace FalStore.Control
{
    public partial class Category : System.Web.UI.UserControl
    {
        #region .Property
        CategoryBIZ categoryBIZ = new CategoryBIZ();
        string id = string.Empty;
        string name = string.Empty;
        private int pageSize;
        int stt = 1;
        #endregion

        #region  Viewstate
        protected int currentPageIndex
        {
            get
            {
                if (ViewState["CurrentPageIndex"] != null)
                    return int.Parse(ViewState["CurrentPageIndex"].ToString());
                else
                    return 1;
            }
            set
            {
                ViewState["CurrentPageIndex"] = value;
            }
        }
        #endregion

        #region .Event
        /// <summary>
        /// page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
        }

        /// <summary>
        /// initial page
        /// </summary>
        protected void InitPage()
        {
            try
            {
                int count;
                pageSize = int.Parse(drpSelect.SelectedItem.ToString());
                //this.pager.ItemCount = 21;
                List<objCategory> tbl = new List<objCategory>();
                tbl = categoryBIZ.ShowByPaging(currentPageIndex, pageSize, out count);
                this.pager.ItemCount = count;
                if (tbl != null)
                {
                    rptResult.DataSource = tbl;
                    rptResult.DataBind();
                }

                if (txtCategoryID.Text != string.Empty)
                {
                    btnAdd.Text = "Chỉnh sửa";
                }
                else
                {
                    btnAdd.Text = "Tạo mới";
                }

            }
            catch (Exception)
            {
                
                throw;
            }
          
        }

        /// <summary>
        /// Literal map data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    objCategory data = e.Item.DataItem as objCategory;

                    Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    ltrStt.Text = stt.ToString();
                    stt++;

                    Literal ltrCategoryName = e.Item.FindControl("ltrCategoryName") as Literal;
                    ltrCategoryName.Text = data.CategoryName.ToString();

                    //LinkButton lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;
                    //lnkDelete.CommandArgument = data.CategoryID.ToString();

                }
            }
            catch (Exception)
            {
                
                throw;
            }
          
        }

        /// <summary>
        /// item command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptResult_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Edit":
                        LoadDataUpdate(int.Parse(e.CommandArgument.ToString()));
                        break;
                    case "Delete":
                        DeleteCategory(int.Parse(e.CommandArgument.ToString()));
                        break;

                }
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        /// <summary>
        /// Add new & update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                stt = 1;
                string categoryID = txtCategoryID.Text;
                int result;

                bool flag = categoryBIZ.CheckCategoryName(txtCategoryName.Text);

                if (flag)
                {
                    objCategory obj = new objCategory();
                    obj.CategoryName = txtCategoryName.Text;

                    if (string.Empty.Equals(categoryID))
                    {
                        SetUpdateInfo(obj, 0);
                        result = categoryBIZ.Insert(obj);
                    }
                    else
                    {
                        obj.CategoryID = int.Parse(txtCategoryID.Text);
                        SetUpdateInfo(obj, 1);
                        result = categoryBIZ.Update(obj);
                    }

                    if (result == 1)
                    {
                        lblMessage.Text = "Thực thi thành công";
                    }
                    else
                    {
                        lblMessage.Text = "Thực thi thất bại";
                    }
                    clear();
                    InitPage();
                }
                else
                {

                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Tên danh mục đã tồn tại\"); <" + "/script>"));
                 
                }
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        /// <summary>
        /// clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        /// <summary>
        /// paging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void pager_Command(object sender, CommandEventArgs e)
        {
            this.currentPageIndex = Convert.ToInt32(e.CommandArgument);
            pager.CurrentIndex = this.currentPageIndex;
            InitPage();
        }

        /// <summary>
        /// select record number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drpSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitPage();
        }

        /// <summary>
        /// Delete record
        /// </summary>
        /// <param name="CategoryID"></param>
        private void DeleteCategory(int CategoryID)
        {
            DateTime updateDate = DateTime.Now;
            string updateUser = "";
            categoryBIZ.Delete(CategoryID, updateDate, updateUser);
            InitPage();
        }

        /// <summary>
        /// Load info to update
        /// </summary>
        /// <param name="CategoryID"></param>
        private void LoadDataUpdate(int CategoryID)
        {
            objCategory obj = new objCategory();
            obj = categoryBIZ.ShowByCategoryID(CategoryID);
            txtCategoryID.Text = obj.CategoryID.ToString();
            txtCategoryName.Text = obj.CategoryName;
            InitPage();
        }

        #endregion

        #region .Method
        //Set info for Create and Update
        //Type 0: Create    Type 1: Update
        private static void SetUpdateInfo(objCategory obj, int type)
        {
            if (type == 0)
            {
                obj.CreateDate = System.DateTime.Now;
                obj.CreateUser = "";
                obj.UpdateDate = System.DateTime.Now;
                obj.UpdateUser = "";
            }
            else
            {
                obj.UpdateDate = System.DateTime.Now;
                obj.UpdateUser = "";
            }
        }

        private void clear()
        {
            txtCategoryID.Text = string.Empty;
            txtCategoryName.Text = string.Empty;

        }
        #endregion

    }
}