Imports System.Data.Entity
Public Class ProductContext : Inherits DbContext

    Public Sub New()
        MyBase.New("name=WingTipToys")
    End Sub

    Public Property Products As IDbSet(Of Product)
    Public Property Categories As IDbSet(Of Category)
End Class
