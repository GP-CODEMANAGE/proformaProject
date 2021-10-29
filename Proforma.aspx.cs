using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

    }
}