using System;
using System.Data;
using System.Web.UI.WebControls;
using Spire.Xls;

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

    protected void ddlHousehold_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAllocationGroup(ddlAllocationGroup);
    }

    protected void ddlAllocationGroup_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void txtasOfDate_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string sqlstr = "EXEC [SP_R_PROFORMA] @HouseholdName = 'Adams Family',@AsofDate = '30-Jun-2020',@GreshamAdvisedFlagTxt = 'TIA'";
        DataSet ds1=clsDB.getDataSet(sqlstr);
        ExportDataSetToExcel(ds1);
    }

    public void ExportDataSetToExcel(DataSet ds)
    {
        #region Spire License Code
        string License = AppLogic.GetParam(AppLogic.ConfigParam.SpireLicense);
        Spire.License.LicenseProvider.SetLicenseKey(License);
        Spire.License.LicenseProvider.LoadLicense();
        #endregion

        Workbook book = new Workbook();
        book.Version = ExcelVersion.Version2016;
        book.LoadFromFile(@"C:\Users\BharathKumar\Desktop\Test\NEW PROFORMA TEMPLATE TEST.xlsx");
        Worksheet sheet = book.Worksheets[0];


        //Export datatable to excel
        DataTable dt0 = ds.Tables[0];
        DataTable dt1 = ds.Tables[1];

        // Formating date stamp
        sheet.Range["B4"].Text = dt0.Rows[0][0].ToString();
        sheet.Range["B4"].NumberFormat = "mm-dd-yyyy";

        sheet.Range["C14"].Text = dt0.Rows[0][0].ToString();
        sheet.Range["C14"].NumberFormat = "mm-dd-yyyy";

        sheet.Range["F14"].Text = dt0.Rows[0][1].ToString();
        sheet.Range["F14"].NumberFormat = "mm-dd-yyyy";

        sheet.Range["I14"].Text = dt0.Rows[0][2].ToString();
        sheet.Range["I14"].NumberFormat = "mm-dd-yyyy";

        //Dynamically updating the data into the cells
        for (int i = 0;i<dt1.Rows.Count;i++)
        {
            int j = 0;
            string sval = dt1.Rows[i][j].ToString();
            string cellFormat = dt1.Rows[i][2].ToString();
            if (cellFormat=="Currency")
            {
                sheet.Range[sval].NumberValue = double.Parse(dt1.Rows[i][j + 1].ToString());
                sheet.Range[sval].NumberFormat = "$#,##0.00";
            }
            else if(cellFormat=="Number")
            {
                sheet.Range[sval].NumberValue = double.Parse(dt1.Rows[i][j + 1].ToString());
                sheet.Range[sval].NumberFormat = "0.0";
            }
        }
        book.CalculateAllValue();

        book.SaveToFile(@"C:\Users\BharathKumar\Desktop\Test\NEW PROFORMA TEMPLATE TEST RESULT.xlsx", ExcelVersion.Version2016);

       // System.Diagnostics.Process.Start(@"C:\Saurabh\NEW PROFORMA TEMPLATE TEST.xlsx");
    }
}