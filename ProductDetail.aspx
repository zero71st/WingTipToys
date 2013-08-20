<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ProductDetail.aspx.vb" Inherits="WingTipToys.ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:FormView ID="productDetail" runat="server" ItemType="WingTipToys.Product" SelectMethod="GetProduct" RenderOuterTable="false">
            <ItemTemplate>
            <div>
                <h1><%#:Item.ProductName%></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Images/Catalog/Images/<%#:Item.ImagePath%>" /> <span><b><%#:Item.ProductName%><b></b></span>
                    </td>
                    <td>
                        <b>Description:</b> <%#:Item.Description%>
                        <br />
                        <span><b>Price:</b> <%#:String.Format("{0:c}", Item.UnitPrice)%></span>
                        <br />
                        <b>Product Number:</b><%#:Item.ProductID%>
                        <br />
                        <%--<a href="AddToCart.aspx?productID=<%#Item.ProductID%>">--%>
                        <a href="<%#:GetRouteUrl("ProductByNameRoute", New With {.productName = Item.ProductName})%>"
                            <b>Add To Cart</b>
                        </a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
