Imports System.Web.ModelBinding
Public Class ProductDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'Public Function GetProduct(<QueryString("productID")> productId As Nullable(Of Integer)) As IQueryable(Of Product)
    '    Dim db = New ProductContext()
    '    Dim query As IQueryable(Of Product) = db.Products
    '    If productId.HasValue AndAlso productId > 0 Then
    '        'query = query.Where(CType(Function(p) p. = productId, Func(Of Product, Boolean)))
    '        query = query.Where(CType(Function(p) p.ProductID = productId, Func(Of Product, Boolean)))
    '    Else
    '        query = Nothing
    '    End If
    '    Return query
    'End Function
    Public Function GetProduct(<QueryString("productID")> productId As Nullable(Of Integer)) As Product
        Dim db = New ProductContext()
        Dim product As Product
        If productId.HasValue AndAlso productId > 0 Then
            product = db.Products.Where(Function(p) p.ProductID = productId).FirstOrDefault()
        Else
            product = Nothing
        End If
        Return product
    End Function
End Class