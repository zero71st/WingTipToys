Public Class ShoppingCart
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim userShoppingCart As New ShopingCartActions()
        Dim cartTotal As Decimal = userShoppingCart.GetTotal()
        If cartTotal > 0 Then
            lblTotal.Text = String.Format("{0:c}", cartTotal)
        Else
            LabelTotalText.Text = ""
            lblTotal.Text = ""
            UpdateBtn.Visible = False
        End If
    End Sub
    Public Function GetShoppingCartItems() As List(Of CartItem)
        Dim action = New ShopingCartActions()
        Return action.GetCartItems()
    End Function

End Class