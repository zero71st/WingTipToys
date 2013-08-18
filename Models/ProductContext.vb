Imports System.Data.Entity
Public Class ProductContext : Inherits DbContext

    Public Sub New()
        MyBase.New("name=WingTipToys")
    End Sub

    Public Property Products As DbSet(Of Product)

    Public Property Categories As DbSet(Of Category)

    Public Property CartItem As DbSet(Of CartItem)
End Class
