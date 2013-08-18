Imports System.Web.ModelBinding
Public Class ProductList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'พิศดาร เรียก Querystring ด้วย Attribute พึงเคยเห็น
    Public Function GetProducts(<QueryString("id")> categoryID As Nullable(Of Integer)) As IQueryable(Of Product)
        Dim db = New ProductContext()
        Dim query As IQueryable(Of Product) = db.Products

        If categoryID.HasValue AndAlso categoryID > 0 Then
            query = query.Where(Function(p) p.CategoryID = categoryID)
            '        query = query.Where(CType(Function(p) p.CategoryID = categoryID, Func(Of Product, Boolean)))
        End If

        Return query
    End Function
End Class