Imports System.Web.Optimization
Imports System.Data.Entity

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        AuthConfig.RegisterOpenAuth()
        RouteConfig.RegisterRoutes(RouteTable.Routes)

        Database.SetInitializer(New ProductDatabaseInitializer())

        If Not (Roles.RoleExists("Administrator")) Then
            Roles.CreateRole("Administrator")
        End If
        If Membership.GetUser("Admin") Is Nothing Then
            Membership.CreateUser("Admin", "pa$$word", "Admin@gmail.com")
            Roles.AddUserToRole("Admin", "Administrator")
        End If

        'Add Routes
        RegisterRoutes(RouteTable.Routes)
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs

        ' Trap error that occure anywhere in application.
        ' Get last error from the server
        Dim exc As Exception = Server.GetLastError()
        If TypeOf exc Is HttpUnhandledException Then
            If exc.InnerException IsNot Nothing Then
                exc = New Exception(exc.InnerException.Message)
                Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", True)
            End If
        End If
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

    Private Shared Sub RegisterRoutes(routes As RouteCollection)
        'Static Route
        routes.MapPageRoute("HomeRoute", "Home", "~/Default.aspx")
        routes.MapPageRoute("AboutRoute", "About", "~/About.aspx")
        routes.MapPageRoute("ContactRoute", "Contact", "~/Contact.aspx")
        routes.MapPageRoute("ProductListRoute", "ProductList", "~/ProductList.aspx")
        'Dynamic Route
        routes.MapPageRoute("ProductsByCategoryRoute", "ProductList/{catName}", "~/ProductList.aspx")
        routes.MapPageRoute("ProductByNameRoute", "Product/{productName}", "~/ProductDetails.aspx")
    End Sub
End Class