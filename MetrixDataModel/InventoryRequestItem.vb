'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class InventoryRequestItem
    Public Property Id As Integer
    Public Property InventoryRequestId As Integer
    Public Property ItemId As Nullable(Of Integer)
    Public Property ItemInventoryId As Nullable(Of Integer)
    Public Property ItemNumber As Integer
    Public Property Status As Integer
    Public Property DateNeeded As Date
    Public Property Quantity As Integer
    Public Property ShippingAddressType As Nullable(Of Integer)
    Public Property CarrierName As String
    Public Property ShipmentId As Nullable(Of Integer)
    Public Property ShippingLocationName As String
    Public Property ShippingLocationCustomerNumber As String
    Public Property ShippingLocationAddressAddressLine1 As String
    Public Property ShippingLocationAddressAddressLine2 As String
    Public Property ShippingLocationAddressCity As String
    Public Property ShippingLocationAddressState As String
    Public Property ShippingLocationAddressPostalCode As String
    Public Property ShippingLocationPhoneNumberNumber As String
    Public Property ShippingLocationPhoneNumberPhoneNumberType As Nullable(Of Integer)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property Version As Nullable(Of Integer)
    Public Property ShippingLocationPhoneNumberMobileProviderType As Nullable(Of Integer)
    Public Property ShippingLocationPhoneNumberIsPrimary As Nullable(Of Integer)

    Public Overridable Property InventoryRequest As InventoryRequest
    Public Overridable Property ItemInventory As ItemInventory
    Public Overridable Property Item As Item

End Class
