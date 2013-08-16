Imports System.ComponentModel.DataAnnotations

Public Class Category
    <ScaffoldColumn(False)>
    Public Property CategoryID As Integer
    Public Property CategoryName As String
    Public Property Description As String

    'Navigation Properties
    Public Overridable Property Products As ICollection(Of Product)
End Class
