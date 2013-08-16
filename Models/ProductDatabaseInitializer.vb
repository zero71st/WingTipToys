Imports System.Data.Entity
Public Class ProductDatabaseInitializer : Inherits DropCreateDatabaseIfModelChanges(Of ProductContext)
    Protected Overrides Sub Seed(context As ProductContext)
        MyBase.Seed(context)
    End Sub

End Class
