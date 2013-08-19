Public Class ShoppingCartActions
    Public Property ShopingCartID As String
    Private _db As ProductContext = New ProductContext
    Public Const CartSessionKey As String = "CartID"

    Public Function GetCartID() As String
        If HttpContext.Current.Session(CartSessionKey) Is Nothing Then
            If Not String.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name) Then
                HttpContext.Current.Session(CartSessionKey) = HttpContext.Current.User.Identity.Name
            Else
                Dim tempCartID As Guid = Guid.NewGuid()
                HttpContext.Current.Session(CartSessionKey) = tempCartID.ToString
            End If
        End If
        Return HttpContext.Current.Session(CartSessionKey).ToString
    End Function

    Public Sub AddToCart(id As Integer)
        'Retrive CartID from database
        ShopingCartID = GetCartID()

        Dim cartItem = _db.ShoppingCartItems.SingleOrDefault(Function(s) s.CartID = ShopingCartID AndAlso s.ProductID = id)

        If cartItem Is Nothing Then
            cartItem = New CartItem() With {.ItemID = Guid.NewGuid.ToString,
                                            .ProductID = id,
                                            .CartID = ShopingCartID,
                                            .Product = _db.Products.SingleOrDefault(Function(p) p.ProductID = id),
                                            .Quantity = 1,
                                            .DateCreated = Date.Now}
            _db.ShoppingCartItems.Add(cartItem)
        Else
            cartItem.Quantity += 1
        End If
        _db.SaveChanges()
    End Sub

    Public Function GetCartItems() As List(Of CartItem)
        Dim shoppingCartId = GetCartID()
        Return _db.ShoppingCartItems.Where(Function(s) s.CartID = shoppingCartId).ToList
    End Function

    'TODO ทบทวบ GetTotal งง สุด ๆ
    Public Function GetTotal() As Decimal
        Dim shoppingCartID = GetCartID()

        Dim total As Nullable(Of Decimal) = Decimal.Zero
        total = CType((From cartItems In _db.ShoppingCartItems _
                      Where cartItems.CartID = shoppingCartID _
                      Select CType(cartItems.Quantity, Nullable(Of Integer)) * cartItems.Product.UnitPrice).Sum(), Nullable(Of Integer))

        Return If(total, Decimal.Zero)
    End Function

    'TODO เอาไว้ทำอะไร
    Public Structure ShoppingCartUpdate
        Public ProductID As Integer
        Public PurchaseQuantity As Integer
        Public RemoveItem As Boolean
    End Structure

    Public Sub UpdateShoppingCartDatabase(cartId As String, cartUpdates As ShoppingCartUpdate())
        Using db As ProductContext = New ProductContext
            Try
                Dim cartItemCount As Integer = cartUpdates.Count()
                Dim myCart As List(Of CartItem) = GetCartItems()
                For Each cartItem As CartItem In myCart
                    For i As Integer = 0 To cartItemCount - 1
                        If cartItem.Product.ProductID = cartUpdates(i).ProductID Then
                            UpdateItem(cartId, cartItem.ProductID, cartUpdates(i).PurchaseQuantity)
                        End If
                    Next
                Next
            Catch ex As Exception
                Throw New Exception("ERROR: ไม่สามารถปรับปรุงรายการสินค้าใน Database ได้" & ex.Message.ToString, ex)
            End Try
        End Using
    End Sub

    Private Sub UpdateItem(updateCartId As String, UpdateProductId As Integer, quantity As Integer)
        Using db As ProductContext = New ProductContext
            Try
                Dim myItem = (From c In db.ShoppingCartItems _
                              Where c.CartID = updateCartId AndAlso c.Product.ProductID = UpdateProductId _
                              Select c).FirstOrDefault()
                If Not (myItem Is Nothing) Then
                    myItem.Quantity = quantity
                    db.SaveChanges()
                End If
            Catch ex As Exception
                Throw New Exception("ERROR: ไม่สามารถปรับปรุงรายการสินค้าในตระกร้าได้" & ex.Message.ToString, ex)
            End Try
        End Using
    End Sub
End Class
