Public Class AddToCart
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rawID As String = Request.QueryString("ProductID")
        Dim productID As Integer
        If Not String.IsNullOrEmpty(rawID) AndAlso Integer.TryParse(rawID, productID) Then
            Dim userShoppingCart As ShopingCartActions = New ShopingCartActions()
            userShoppingCart.AddToCart(Convert.ToInt16(rawID))
        Else
            ' TODO Do not forget implement
        End If
        Response.Redirect("ShoppingCart.aspx")
    End Sub

End Class