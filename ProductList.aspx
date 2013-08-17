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

                    <asp:ListView ID="lvProductList" runat="server" DataKeyNames="ProductID" GroupItemCount="3" ItemType="WingTipToys.Product" SelectMethod="GetProducts">
                        <EmptyDataTemplate>
                            <table runat="server">
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
                                        <a href="ProductDetail.aspx?productID=" <%#: Item.ProductID%>>
                                            <img src="Images/Catalog/Images/Thumbs/<%#:Item.ImagePath%>"
                                                width="100" height="75" border="1" />
                                        </a>
                                        <a href="ProductDetail.aspx?ProductID=" <%#: Item.ProductID%>>
                                            <span class="ProductName">
                                                <%#:Item.ProductName%>
                                            </span>
                                        </a>
                                        <br />
                                        <span class="ProductPrice">
                                            <b> Price: <%#:String.Format("{0:c}", Item.UnitPrice)%></b>
                                        </span>
                                        <br />
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
