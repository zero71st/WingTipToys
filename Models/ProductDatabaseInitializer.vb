Imports System.Data.Entity
Public Class ProductDatabaseInitializer : Inherits DropCreateDatabaseIfModelChanges(Of ProductContext)
    Protected Overrides Sub Seed(context As ProductContext)
        MyBase.Seed(context)
    End Sub

    Private Shared Function GetCategories() As List(Of Category)
        Dim categories = New List(Of Category)
        categories.Add(New Category With {.CategoryID = 1, .CategoryName = "Cars"})
        categories.Add(New Category With {.CategoryID = 2, .CategoryName = "Planes"})
        categories.Add(New Category With {.CategoryID = 3, .CategoryName = "Trucks"})
        categories.Add(New Category With {.CategoryID = 4, .CategoryName = "Boats"})
        categories.Add(New Category With {.CategoryID = 5, .CategoryName = "Rockets"})

        Return categories
    End Function

    Private Shared Function GetProducts() As List(Of Product)
        Dim products = New List(Of Product)
        products.Add(New Product With {.ProductID = 1,
                                        .ProductName = "Convertible Car",
                    .Description = "This convertible car is fast! The engine is powered by a neutrino based battery (not included)." +
                                  "Power it up and let it go!",
                    .ImagePath = "carconvert.png",
                    .UnitPrice = 22.5,
                    .CategoryID = 1})
        products.Add(New Product With {.ProductID = 2,
                                        .ProductName = "Old-time Car",
                    .Description = "There's nothing old about this toy car, except it's looks.",
                    .ImagePath = "carearly.png",
                    .UnitPrice = 19.5,
                    .CategoryID = 1})
        Return products
    End Function

End Class
