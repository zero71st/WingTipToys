Public Class ShoppingCart
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function GetShoppingCartItems() As List(Of CartItem)
        Dim action = New ShopingCartActions()
        Return action.GetCartItems()
    End Function

End Class