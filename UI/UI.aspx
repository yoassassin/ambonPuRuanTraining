<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UI.aspx.cs" Inherits="UI.UI" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
            text-align: center;
        }
        .auto-style3 {
            font-size: large;
            margin-left: 200px;
        }
        .auto-style5 {
            margin-left: 520px;
        }
        .auto-style6 {
            text-align: center;
            margin-left: 520px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <strong>采购金额汇总统计（按商品）</strong></div>
        <p class="auto-style3">
            采购时间<asp:TextBox ID="txtDate1" runat="server"></asp:TextBox>
&nbsp;to<asp:TextBox ID="txtDate2" runat="server"></asp:TextBox>
        </p>
        <div class="auto-style6">
            <asp:Button ID="btnSummarizing" runat="server" OnClick="Button1_Click" Text="汇总查询" />
        </div>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1153px">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
&nbsp;&nbsp;&nbsp;
        <div class="auto-style5">
            <asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" Text="报表显示" />
        </div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1149px">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
