<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="Parcial1.Compras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Menu.aspx">Atras</asp:HyperLink>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#006600" Text="Gestionar Compras:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Fecha: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" Width="154px"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Monto Gravado: "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Width="91px"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="IVA: "></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" Width="166px"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Nro. Factura: "></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Number" Width="109px"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Punto de Venta: "></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" TextMode="Number" Width="93px"></asp:TextBox>
            <br />
            Proveedor:
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="razonSocial" DataValueField="id" Height="20px" Width="132px">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="LabelAviso" runat="server"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Agregar" Width="95px" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Modificar" Width="104px" OnClick="Button2_Click" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Filtrar: "></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="razonSocial" DataValueField="id" Width="164px">
            </asp:DropDownList>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Filtrar" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Cancelar" />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" />
                    <asp:BoundField DataField="montoGravado" HeaderText="Monto Gravado" SortExpression="montoGravado" />
                    <asp:BoundField DataField="iva" HeaderText="IVA" SortExpression="iva" />
                    <asp:BoundField DataField="numeroFactura" HeaderText="Nro. Factura" SortExpression="numeroFactura" />
                    <asp:BoundField DataField="puntoVenta" HeaderText="Punto de Venta" SortExpression="puntoVenta" />
                    <asp:BoundField DataField="idProveedor" SortExpression="idProveedor" />
                    <asp:BoundField DataField="razonSocial" HeaderText="Proveedor" SortExpression="razonSocial" />
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowSelectButton="True" />
                </Columns>
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
            <br />
            <br />
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cadena %>" DeleteCommand="DELETE FROM [Compras] WHERE [id] = @id" InsertCommand="INSERT INTO [Compras] ([fecha], [montoGravado], [iva], [numeroFactura], [puntoVenta], [idProveedor]) VALUES (@fecha, @montoGravado, @iva, @numeroFactura, @puntoVenta, @idProveedor)" SelectCommand="SELECT Compras.id, Compras.fecha, Compras.montoGravado, Compras.iva, Compras.numeroFactura, Compras.puntoVenta, Compras.idProveedor, Proveedores.razonSocial FROM Compras INNER JOIN Proveedores ON Compras.idProveedor = Proveedores.id" UpdateCommand="UPDATE [Compras] SET [fecha] = @fecha, [montoGravado] = @montoGravado, [iva] = @iva, [numeroFactura] = @numeroFactura, [puntoVenta] = @puntoVenta, [idProveedor] = @idProveedor WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:ControlParameter ControlID="TextBox1" DbType="Date" Name="fecha" PropertyName="Text" />
                <asp:ControlParameter ControlID="TextBox2" Name="montoGravado" PropertyName="Text" Type="Decimal" />
                <asp:ControlParameter ControlID="TextBox3" Name="iva" PropertyName="Text" Type="Decimal" />
                <asp:ControlParameter ControlID="TextBox4" Name="numeroFactura" PropertyName="Text" Type="Int32" />
                <asp:ControlParameter ControlID="TextBox5" Name="puntoVenta" PropertyName="Text" Type="Int32" />
                <asp:ControlParameter ControlID="DropDownList1" Name="idProveedor" PropertyName="SelectedValue" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:ControlParameter ControlID="TextBox1" DbType="Date" Name="fecha" PropertyName="Text" />
                <asp:ControlParameter ControlID="TextBox2" Name="montoGravado" PropertyName="Text" Type="Decimal" />
                <asp:ControlParameter ControlID="TextBox3" Name="iva" PropertyName="Text" Type="Decimal" />
                <asp:ControlParameter ControlID="TextBox4" Name="numeroFactura" PropertyName="Text" Type="Int32" />
                <asp:ControlParameter ControlID="TextBox5" Name="puntoVenta" PropertyName="Text" Type="Int32" />
                <asp:ControlParameter ControlID="DropDownList1" Name="idProveedor" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="GridView1" Name="id" PropertyName="SelectedValue" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:cadena %>" SelectCommand="SELECT * FROM [Proveedores]"></asp:SqlDataSource>
        <br />
    </form>
</body>
</html>
