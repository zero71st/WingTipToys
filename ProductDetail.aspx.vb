Imports System.Web.ModelBinding
Public Class ProductDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function GetProduct(<QueryString("ProductID")> productId As Nullable(Of Integer), <RouteData> productName As String) As IQueryable(Of Product)
        Dim db = New ProductContext()
        Dim query As IQueryable(Of Product) = db.Products
        ' ตอนนี้ใช้ URL Routing การค้นหาด้วย ID จะไม่ทำงาน
        If productId.HasValue AndAlso productId > 0 Then
            query = query.Where(CType(Function(p) p.ProductID = productId, Func(Of Product, Boolean)))
        ElseIf Not String.IsNullOrEmpty(productName) Then
            query = query.Where(Function(p) String.Compare(p.ProductName, productName) = 0)
        Else
            query = Nothing
        End If
        Return query
    End Function

    'Public Function GetProduct(<QueryString("productID")> productId As Nullable(Of Integer), <RouteData> productName As String) As Product
    '    'Dim db = New ProductContext()
    '    'Dim product As Product
    '    'If productId.HasValue AndAlso productId > 0 Then
    '    '    product = db.Products.Where(Function(p) p.ProductID = productId).FirstOrDefault()
    '    'Else
    '    '    product = Nothing
    '    'End If

    '    'If Not (String.IsNullOrEmpty(productName)) Then
    '    '    product = db.Products.Where(Function(p) String.Compare(p.ProductName, productName) = 0).FirstOrDefault()
    '    'End If

    '    'Return product
    'End Function
End Class