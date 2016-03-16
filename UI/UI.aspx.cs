using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace UI
{
    public partial class UI : System.Web.UI.Page
    {
        protected string _strConn;

        PurchaseOrder poService = new PurchaseOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            _strConn = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnStr"].ConnectionString;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
#if DEBUG
            string d = "2010-01-01";
            txtDate1.Text = Convert.ToDateTime(d).ToString();
#endif

            this.GridView1.DataSource = GetPurchaseOrder();
            this.GridView1.DataBind();
        }

        protected DataTable GetPurchaseOrder()
        {
            DateTime d1 = Convert.ToDateTime(txtDate1.Text);
            DateTime d2 = Convert.ToDateTime(txtDate2.Text);
            return poService.GetPurchaseOrder(d1, d2);
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.LocalReport.ReportPath ="Report1.rdlc";
            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", GetPurchaseOrder()));
            this.ReportViewer1.DataBind();
        }
    }
}