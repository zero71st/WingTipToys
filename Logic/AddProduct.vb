Public Class AddProduct
    Public Function AddProducts(name As String, descripton As String, price As String, category As String, imagePath As String) As Boolean
        Dim product As New Product
        product.ProductName = name
        product.Description = descripton
        product.UnitPrice = Convert.ToDecimal(price)
        product.ImagePath = imagePath
        product.CategoryID = Convert.ToInt32(category)

        Dim db As New ProductContext
        db.Products.Add(product)
        Dim success As Integer = db.SaveChanges()
        If success > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
