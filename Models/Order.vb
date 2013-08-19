Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel

Public Class Order
    Public Property OrderID As Integer
    Public Property OrderDate As DateTime
    Public Property Username As String

    <Required(ErrorMessage:="First name is required.")>
    <DisplayName("First Name")>
    <StringLength(160)>
    Public Property FirstName As String

    <Required(ErrorMessage:="Last name is required.")>
    <DisplayName("Last Name")>
    <StringLength(160)>
    Public Property LastName As String
    Public Property Address As String
    Public Property City As String
    Public Property State As String
    Public Property PostalCode As String
    Public Property Country As String
    Public Property Phone As String

    <Required(ErrorMessage:="Email Address is required.")>
    <DisplayName("Email Address")>
    <RegularExpression("[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage:="Email is not valid")>
    <DataType(DataType.EmailAddress)>
    Public Property Email As String
    Public Property Total As Decimal
    Public Property PaymentTransactionID As String
    Public Property HasBeenShipped As Boolean

    'Naviagate Property
    Overridable Property OrderDetails As List(Of OrderDetail)

End Class
