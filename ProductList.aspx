<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ProductList.aspx.vb" Inherits="WingTipToys.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Page.Title%></h1>
            </hgroup>
            <section class="featured">
                <ul>
                    <asp:ListView ID="productList" runat="server" DataKeyNames="ProductID" GroupItemCount="3" ItemType="WingTipToys.Product" SelectMethod="GetProduct">
                        <EmptyDataTemplate>
                            <table id="Table1" runat="server">
                                <td>No data was returned.</td>
                            </table>
                        </EmptyDataTemplate>
                        <EmptyItemTemplate>
                            <td></td>
                        </EmptyItemTemplate>
                        <GroupTemplate>
                            <tr id="itemPlaceholderContainer" runat="server">
                                <td id="itemPlaceholder" runat="server"></td>
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td id="Td2" runat="server"> <%--ปรับ Layout ให้แสดงแนวนอน--%>
                            <Table>
                                <tr>
                                    <td>
                                        <%--ระวังเรื่องการทำส่ง Query string แบบนี้เนื่องจากใส่เครื่องหมายคำพูดผิดที่ประจำ ""--%>
                                        <a href="<%#: GetRouteUrl("ProductByNameRoute", New With {.productName = Item.ProductName})%>">
                                            <img src="/Images/Catalog/Images/Thumbs/<%#:Item.ImagePath%>"
                                                width="100" height="75"   />
                                        </a>
                                        <a href="<%#: GetRouteUrl("ProductByNameRoute", New With {.productName = Item.ProductName})%>">
                                            <%#:Item.ProductName%>
                                        </a>
                                        <br />
                                        <span class="ProductPrice">
                                            <b> Price: <%#:String.Format("{0:c}", Item.UnitPrice)%></b>
                                        </span>
                                        <br />
                                        <a href="AddToCart.aspx?productID=<%#:Item.ProductID%>">
                                            <b>Add To Cart</b>
                                        </a>
                                    </td>
                                </tr>
                            </Table>
                                </td>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table id="Table2" runat="server">
                                <tr id="Tr1" runat="server">
                                    <td id="Td3" runat="server">
                                        <table id="groupPlaceholderContainer" runat="server">
                                            <tr id="groupPlaceholder"></tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="Tr2" runat="server"><td id="Td4" runat="server"></td></tr>   
                            </table>
                        </LayoutTemplate>
                    </asp:ListView>
                </ul>
            </section>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
