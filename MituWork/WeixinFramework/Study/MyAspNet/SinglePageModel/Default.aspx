<%@ Page Language="C#" %>
<%@ Import Namespace = "AutoLotConnectedLayer" %>
<%@ Assembly Name ="AutoLotDAL" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
        <script runat="server">
        protected void btnFillData_Click(Object sender, EventArgs args)
        {
            InventoryDAL dal = new InventoryDAL();
            dal.OpenConnection(@"Data Source=(local);" +
            "Initial Catalog=AutoLot;Integrated Security=True");
            carsGridView.DataSource = dal.GetAllInventoryAsList();
            carsGridView.DataBind();
            dal.CloseConnection();
        }
        </script>
<meta charset="utf-8" />
    <title></title>    
</head>
<body>
    <form id="form1" runat="server">
        <div>   
        <asp:Label ID="lblInfo" runat="server" Text="Click on the Button to Fill the Grid"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="carsGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        <br />
        <asp:Button ID="btnFillData" runat="server" Text="Fill Grid" OnClick="btnFillData_Click" />
        </div>
    </form>
</body>
</html>
