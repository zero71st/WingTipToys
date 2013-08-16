Imports System.ComponentModel.DataAnnotations

Public Class Product
    <ScaffoldColumn(False)>
    Public Property ProductID As Integer

    '<Required, StringLength(100), Display(Name = "Name")> Name ไม่ได้
    Public Property ProductName As String

    Public Property Description As String

    Public Property ImagePath As String

    Public Property UnitPrice As Nullable(Of Decimal)
    Public Property CategoryID As Nullable(Of Integer)

    'Navigation
    Overridable Property Product As Product

End Class
