Imports System.Collections.Specialized

Public Class ShoppingCart
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim userShoppingCart As New ShoppingCartActions()
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
        Dim action = New ShoppingCartActions()
        Return action.GetCartItems()
    End Function

    Public Function UpdateCartItem() As List(Of CartItem)
        Dim userShoppingCart As ShoppingCartActions = New ShoppingCartActions()

        Dim cartId = userShoppingCart.GetCartID()

        Dim cartUpdates As ShoppingCartActions.ShoppingCartUpdate() = New ShoppingCartActions.ShoppingCartUpdate(CartList.Rows.Count - 1) {}
        For i As Integer = 0 To CartList.Rows.Count - 1
            Dim rowValues As IOrderedDictionary = New OrderedDictionary()

            rowValues = GetValues(CartList.Rows(i)) 'Reriveve value from GridView
            cartUpdates(i).ProductID = Convert.ToInt32(rowValues("ProductID"))

            Dim quantityTextBox As TextBox = New TextBox()
            quantityTextBox = DirectCast(CartList.Rows(i).FindControl("txtPurchaseQuantity"), TextBox)
            cartUpdates(i).PurchaseQuantity = Convert.ToInt16(quantityTextBox.Text.ToString())

            Dim removeCheckBox As CheckBox = New CheckBox()
            removeCheckBox = DirectCast(CartList.Rows(i).FindControl("chkRemove"), CheckBox)
            cartUpdates(i).RemoveItem = removeCheckBox.Checked
        Next

        userShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates)
        CartList.DataBind()
        lblTotal.Text = String.Format("{0:c}", userShoppingCart.GetTotal())

        Return userShoppingCart.GetCartItems()
    End Function

    'Public Shared Function GetValues(row As GridViewRow) As IOrderedDictionary() 'Method ห้ามใส่ () เพราะจะกลายเป็น Array
    Public Shared Function GetValues(row As GridViewRow) As IOrderedDictionary
        Dim values As IOrderedDictionary = New OrderedDictionary()
        For Each cell As DataControlFieldCell In row.Cells
            If cell.Visible Then
                ' Extract value from cell
                ' TODO มันคืออะไรหว่า
                cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, True)
            End If
        Next
        Return values
    End Function

    Protected Sub UpdateBtn_Click(sender As Object, e As EventArgs) Handles UpdateBtn.Click
        UpdateCartItem()
    End Sub
End Class