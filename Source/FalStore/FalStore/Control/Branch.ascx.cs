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
    public partial class Branch : System.Web.UI.UserControl
    {
        #region .Property
        BranchBIZ branchBIZ = new BranchBIZ();
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
                List<objBranch> tbl = new List<objBranch>();
                tbl = branchBIZ.ShowByPaging(currentPageIndex, pageSize, out count);
                this.pager.ItemCount = count;
                if (tbl != null)
                {
                    rptResult.DataSource = tbl;
                    rptResult.DataBind();
                }

                if (txtBranchID.Text != string.Empty)
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

                    objBranch data = e.Item.DataItem as objBranch;

                    Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    ltrStt.Text = stt.ToString();
                    stt++;

                    Literal ltrBranchID = e.Item.FindControl("ltrBranchID") as Literal;
                    ltrBranchID.Text = data.BranchID.ToString();

                    Literal ltrBranchName = e.Item.FindControl("ltrBranchName") as Literal;
                    ltrBranchName.Text = data.BranchName.ToString();

                    Literal ltrAddress = e.Item.FindControl("ltrAddress") as Literal;
                    ltrAddress.Text = data.Address.ToString();

                    Literal ltrDescription = e.Item.FindControl("ltrDescription") as Literal;
                    ltrDescription.Text = data.Description.ToString();
                  
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
                        DeleteBranch(int.Parse(e.CommandArgument.ToString()));
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
                string branchID = txtBranchID.Text;
                int result;
                objBranch obj = new objBranch();
                obj.BranchName = txtBranchName.Text;
                obj.Description = txtDescription.Text;
                obj.Address = txtAddress.Text;
                if (string.Empty.Equals(branchID))
                {
                    SetUpdateInfo(obj, 0);
                    result = branchBIZ.Insert(obj);
                }
                else
                {
                    obj.BranchID = int.Parse(txtBranchID.Text);
                    SetUpdateInfo(obj, 1);
                    result = branchBIZ.Update(obj);
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
        /// <param name="BranchID"></param>
        private void DeleteBranch(int BranchID)
        {
            DateTime updateDate = DateTime.Now;
            string updateUser = "";
            branchBIZ.Delete(BranchID, updateDate, updateUser);
            InitPage();
        }

        /// <summary>
        /// Load info to update
        /// </summary>
        /// <param name="BranchID"></param>
        private void LoadDataUpdate(int BranchID)
        {
            objBranch obj = new objBranch();
            obj = branchBIZ.ShowByBranchID(BranchID);
            txtBranchID.Text = obj.BranchID.ToString();
            txtBranchName.Text = obj.BranchName;
            txtDescription.Text = obj.Description;
            txtAddress.Text = obj.Address;
            InitPage();
        }
        #endregion

        #region .Method
        //Set info for Create and Update
        //Type 0: Create    Type 1: Update
        private static void SetUpdateInfo(objBranch obj, int type)
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
            txtBranchID.Text = string.Empty;
            txtBranchName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtAddress.Text = string.Empty;
            lblMessage.Text = string.Empty;
        }
        #endregion

    }
}