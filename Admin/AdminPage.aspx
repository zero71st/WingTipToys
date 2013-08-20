<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AdminPage.aspx.vb" Inherits="WingTipToys.AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1>Administrator</h1>
    <hr />
    <h3>Add Product:</h3>
    <table>
        <tr>
            <td>Category:</td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server"
                    ItemType="WingTipToys.Category"
                    SelectMethod="GetCategories"
                    DataTextField="CategoryName"
                    DataValueField="CategoryID">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Name:</td>
            <td>
                <asp:TextBox runat="server" ID="txtProductName"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    Text="* Product name required."
                    ControlToValidate="txtProductName"
                    SetFocusOnError="true"
                    Display="Dynamic" EnableClientScript ="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Description:</td>
            <td>
                <asp:TextBox runat="server" ID="txtDescription"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    Text="* Description name required."
                    ControlToValidate="txtDescription"
                    SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Price:</td>
            <td>
                <asp:TextBox runat="server" ID="txtPrice"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    Text="* Price required."
                    ControlToValidate="txtPrice"
                    SetFocusOnError="true"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    Text="* Must be a valid price without $."
                    ControlToValidate="txtPrice"
                    SetFocusOnError="True"
                    Display="Dynamic"
                    ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Image File</td>
            <td>
                <asp:FileUpload ID="txtProductImage" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                    Text="* Image path required."
                    ControlToValidate="txtPrice"
                    SetFocusOnError="true"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <p />
    <p />
    <asp:Button ID="btnAddProduct" runat="server" Text="AddProduct" CausesValidation="true" />
    <asp:Label ID="lblAddStatus" runat="server" Text=""></asp:Label>
    <p />
    <p />
    <h3>Remove Product:</h3>
    <table>
        <tr>
            <td>
                <asp:Label ID="LabelRemoveProduct" runat="server">Product:</asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlRemoveProduct" runat="server" ItemType="WingtipToys.Product"
                    SelectMethod="GetProducts" AppendDataBoundItems="true"
                    DataTextField="ProductName" DataValueField="ProductID">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <p></p>
    <asp:Button ID="btnRemoveProduct" runat="server" Text="Remove Product"  CausesValidation="false" />
    <asp:Label ID="lblRemoveStatus" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
