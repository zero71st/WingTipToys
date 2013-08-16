Imports System.ComponentModel.DataAnnotations

Public Class Category
    <ScaffoldColumn(False)>
    Public Property CategoryID As Integer

    <Required, StringLength(100), Display(Name:="Name")>
    Public Property CategoryName As String

    <Display(Name:="Name")>
    Public Property Description As String

    'Navigation Properties
    Public Overridable Property Products As ICollection(Of Product)
End Class
