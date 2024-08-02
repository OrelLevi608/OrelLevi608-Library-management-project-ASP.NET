using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspSemiProject.Views.AdminMaster
{
    public partial class LoanAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string LoanId = Request["LoanId"] + "";
                if (string.IsNullOrEmpty(LoanId))
                {
                    LoanId = "-1";
                }
                BtnDelete.Visible = LoanId != "-1";
                FillData(LoanId);
            }
        }
        public void FillData(string LoanId)
        {
            Loan Tmp = null;
            if (string.IsNullOrEmpty(LoanId))
            {
                LoanId = "-1";
            }
            else
            {
                Tmp = Loan.GetById(int.Parse(LoanId));
                if(Tmp == null)
                {
                    LoanId = "-1";
                }
            }
            HidLoanId.Value = LoanId;
            DDLClient.DataSource = Client.GetAll();
            DDLClient.DataTextField = "Email";
            DDLClient.DataValueField = "ClientId";
            DDLClient.DataBind();
            DDLClient.Items.Insert(0, "בחר לקוח");

            DDLBook.DataSource = Book.GetAll();
            DDLBook.DataTextField = "BTitle";
            DDLBook.DataValueField = "BId";
            DDLBook.DataBind();
            DDLBook.Items.Insert(0, "בחר ספר");

            if(Tmp != null)
            {
                DDLClient.SelectedValue = Tmp.ClientId+"";
                DDLBook.SelectedValue = Tmp.BId + "";
                TxtLoanDate.Text = Tmp.LoanDate.ToString("yyyy-MM-dd");
                TxtActualReturnDate.Text = Tmp.ActualReturnDate.HasValue ? Tmp.ActualReturnDate.Value.ToString("yyyy-MM-dd") : ""; // מילוי תאריך החזרה בפועל אם קיים
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            DateTime? actualReturnDate = null;
            if (!string.IsNullOrWhiteSpace(TxtActualReturnDate.Text))
            {
                actualReturnDate = DateTime.Parse(TxtActualReturnDate.Text);
            }

            Loan Tmp = new Loan() 
            {
                LoanId = int.Parse(HidLoanId.Value),
                ClientId = int.Parse(DDLClient.SelectedValue),
                BId = int.Parse(DDLBook.SelectedValue),
                LoanDate = DateTime.Parse(TxtLoanDate.Text),
                ActualReturnDate = actualReturnDate,
            };
            Tmp.Save();
            Application["Loan"] = Loan.GetAll();
            Response.Redirect("LoanList.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int LoanId = int.Parse(HidLoanId.Value);
            Loan.Delete(LoanId);
            Application["Loan"] = Loan.GetAll();
            Response.Redirect("LoanList.aspx");
        }
    }
}