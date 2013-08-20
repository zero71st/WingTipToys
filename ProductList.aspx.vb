﻿Imports System.Web.ModelBinding

Public Class ProductList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ''พิศดาร เรียก Querystring ด้วย Attribute พึงเคยเห็น
    'Public Function GetProducts(<QueryString("id")> categoryId As Nullable(Of Integer), <RouteData> categoryName As String) As IQueryable(Of Product)
    '    Dim db = New ProductContext()
    '    Dim query As IQueryable(Of Product) = db.Products
    '    'Find by category ID
    '    If categoryId.HasValue AndAlso categoryId > 0 Then
    '        query = query.Where(Function(p) p.CategoryID = categoryId)
    '        '        query = query.Where(CType(Function(p) p.CategoryID = categoryID, Func(Of Product, Boolean)))
    '    End If

    '    'Find by category Name
    '    If Not (String.IsNullOrEmpty(categoryName)) Then
    '        query = query.Where(Function(p) String.Compare(p.Category.CategoryName, categoryName) = 0)
    '    End If

    '    Return query
    'End Function
    Public Function GetProducts(<QueryString("id")> categoryId As Nullable(Of Integer), <RouteData> categoryName As String) As IQueryable(Of Product)
        Dim db = New ProductContext()
        Dim query As IQueryable(Of Product) = db.Products

        If categoryId.HasValue AndAlso categoryId > 0 Then
            query = query.Where(CType(Function(p) p.CategoryID = categoryId, Func(Of Product, Boolean)))
        End If

        If Not String.IsNullOrEmpty(categoryName) Then
            query = query.Where(Function(p) String.Compare(p.Category.CategoryName, categoryName) = 0)
        End If

        Return query
    End Function
End Class