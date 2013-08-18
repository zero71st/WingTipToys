Imports System.ComponentModel.DataAnnotations

Public Class CartItem
    <Key()>
    Public Property ItemID As String

    Public Property CartID As String

    Public Property Quantity As Integer

    Public Property DateCreated As Date

    Public Property ProductID As Integer

    Overridable Property Product As Product

End Class
