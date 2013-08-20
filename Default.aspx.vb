Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Throw New InvalidOperationException("ตั้งใจโยน InvalidOperationException")
    End Sub
End Class