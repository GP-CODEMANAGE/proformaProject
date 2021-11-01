<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Proforma.aspx.cs" Inherits="Proforma" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Proforma Form</title>
    <link id="style1" href="./common/gresham.css" rel="stylesheet" type="text/css" />
    <link href="./common/Calendar.css" rel="stylesheet" type="text/css" />
    <script src="./common/Calendar.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            width: 1329px;
            height: 65px;
            margin-bottom: 0px;
        }
        .auto-style2 {
            width: 1335px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="3">
                        <img src="images/Gresham_Logo__.jpg" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="Titlebig">Gresham Partners, LLC
                    </td>
                </tr>

                <tr>
                    <td>Proforma Form</td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblError" runat="server" ForeColor="Red" ></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td><br /></td>
                    <td><br /></td>
                </tr>
                <tr>
                <asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="update1" runat="server">
                        <ContentTemplate>
                    <td style="width: 25%; height: 25px;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblHousehold" runat="server" Text="Household:" Font-Names="Verdana"></asp:Label></td>
                    <td style="height: 25px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList Font-Names="Verdana" ID="ddlHousehold" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlHousehold_SelectedIndexChanged" Width="300px">
                        </asp:DropDownList>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlHousehold" ErrorMessage="Select Household">*</asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 4px; height: 25px"></td>
                        </ContentTemplate>
                  </asp:UpdatePanel>
                </tr>
                <tr>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                    <td style="width: 25%; height: 25px;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblAllocationGroup" runat="server" Text="Allocation Group:" Font-Names="Verdana"></asp:Label></td>
                    <td style="height: 25px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList Font-Names="Verdana" ID="ddlAllocationGroup" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlAllocationGroup_SelectedIndexChanged" Width="300px">
                        </asp:DropDownList>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlAllocationGroup" ErrorMessage="Select Allocation Group">*</asp:RequiredFieldValidator>
                        </td>
                    <td style="width: 4px; height: 25px"></td>
                    </ContentTemplate>
                  </asp:UpdatePanel>
                </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblasOfDate" runat="server" Text="As Of Date"></asp:Label>
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtasOfDate" runat="server" Width="100px" AutoPostBack="true" TabIndex="4" OnTextChanged="txtasOfDate_TextChanged"></asp:TextBox>
                        &nbsp;<a onclick="showCalendarControl(txtasOfDate)"><img id="img1" alt="" border="0" src="images/calander.png" /></a>
                    </td>

                </tr>
                <tr>
                    <td style="width: 25%">

                    </td>
                    <td style="height: 40px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" OnClick="btnsubmit_Click" />
                    </td>
                </tr>
            </table>
            </div>
        </form>
</body>
</html>
