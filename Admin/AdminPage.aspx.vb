Public Class AdminPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim productAction As String = Request.QueryString("ProductAction")
        If productAction = "Add" Then
            lblAddStatus.Text = "Product Added!"
        End If
    End Sub

    Public Function GetCategories() As IQueryable(Of Category)
        Dim db As New ProductContext()
        Dim query = db.Categories
        Return query
    End Function

    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        Dim fileOk As Boolean = False
        Dim path As String = Server.MapPath("~/Images/Catalog/Images/")

        'Verify file extention
        If txtProductImage.HasFile Then
            Dim fileExtension As String = System.IO.Path.GetExtension(txtProductImage.FileName).ToLower
            Dim allowedExtension As String() = {".gif", ".png", ".jpeg", ".jpg"}
            For i As Integer = 0 To allowedExtension.Length - 1
                If fileExtension = allowedExtension(i) Then
                    fileOk = True
                End If
            Next
        End If

        If fileOk Then
            Try
                'Save Image folder
                txtProductImage.SaveAs(path & txtProductImage.FileName)
                'Save to Image/Thumbs folder
                txtProductImage.PostedFile.SaveAs(path & "Thumbs/" & txtProductImage.FileName)

                Dim addProduct As New AddProduct

                Dim addSuccess As Boolean = addProduct.AddProducts(txtProductName.Text, txtDescription.Text, txtPrice.Text, ddlCategory.SelectedValue, txtProductImage.FileName)

                If addSuccess Then
                    ' TODO: ทำเพื่อ ? เพราะปกติกด Post มัน Postback กลับหน้าเดิมอยู่แล้ว
                    Dim pageUrl As String = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count())
                    Response.Redirect(pageUrl & "?ProdutAction=Add")
                Else
                    lblAddStatus.Text = "ไม่สามารถเพิ่มสินค้าในฐานข้อมูลได้"
                End If

            Catch ex As Exception
                lblAddStatus.Text = ex.Message.ToString
            End Try
        Else
            lblAddStatus.Text = "ประเภทของไฟล์ไม่ถูกต้อง"
        End If
    End Sub
End Class