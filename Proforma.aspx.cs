using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Spire.Xls;
using System.Data.SqlClient;

public partial class Proforma : System.Web.UI.Page
{
    GeneralMethods clsGM = new GeneralMethods();
    DB clsDB = new DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindHousehold(ddlHousehold);
            BindAllocationGroup(ddlAllocationGroup);
        }
    }

    public void BindHousehold(DropDownList ddl)
    {
        ddl.Items.Clear();

        String sqlstr = "SP_S_HouseHoldName";
        clsGM.getListForBindDDL(ddl, sqlstr, "Name", "Accountid");

        if (ddl.Items.Count == 1)
        {
            if (ddl.Items[0].Value == "0")
                ddl.Items.Remove(ddl.Items[0]);
        }
        ddl.Items.Insert(0, "All");
        ddl.Items[0].Value = "0";
        ddl.SelectedIndex = 0;
    }

    public void BindAllocationGroup(DropDownList ddl)
    {
        object OwnerId = "null";
        ddl.Items.Clear();

        string sqlstr = "SP_S_Advent_Allocation_Group  @Householdname ='" + ddlHousehold.SelectedItem.Text.Replace("'", "''") + "'";
        clsGM.getListForBindDDL(ddl, sqlstr, "AllocationGroupName", "AllocationGroupTitle");

        if (ddl.Items.Count == 1)
        {
            if (ddl.Items[0].Value == "0")
                ddl.Items.Remove(ddl.Items[0]);
        }
        ddl.Items.Insert(0, "All");
        ddl.Items[0].Value = "0";
        ddl.SelectedIndex = 0;
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }
    public void generatesExcelsheets()
    {
       

        String lsSQL = "exec [TransactionLoad_DB].[dbo].[SP_EXCEL_FORMULA_TEST]";
        DataSet dataSet = clsDB.getDataSet(lsSQL);

        exportDataSetToExcel(dataSet);
    }
    
    public void exportDataSetToExcel(DataSet dataSet)
    {
        
        #region Spire License Code
        string License = AppLogic.GetParam(AppLogic.ConfigParam.SpireLicense);
        Spire.License.LicenseProvider.SetLicenseKey(License);
        Spire.License.LicenseProvider.LoadLicense();
        #endregion

        Workbook book = new Workbook();
        book.Version = ExcelVersion.Version2016;
        book.LoadFromFile(@"C:\Users\BharathKumar\Desktop\Test\Sample.xlsx");

        DataTable dt = dataSet.Tables[0];
       

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            for (int j = 0; j <= dt.Columns.Count - 1; j++)
            {
                var cell = dt.Rows[i][j];
                
            }
        }


    }
}