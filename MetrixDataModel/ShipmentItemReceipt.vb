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

Partial Public Class ShipmentItemReceipt
    Public Property Id As Integer
    Public Property ShipmentItemId As Integer
    Public Property ReceiptQuantity As Integer
    Public Property ReceiptDate As Nullable(Of Date)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property Version As Nullable(Of Integer)
    Public Property VendorReceiptQuantity As Nullable(Of Integer)
    Public Property VendorReceiptDate As Nullable(Of Date)

    Public Overridable Property ItemInventoryTransaction As ICollection(Of ItemInventoryTransaction) = New HashSet(Of ItemInventoryTransaction)
    Public Overridable Property ShipmentItem As ShipmentItem
    Public Overridable Property ShipmentProblemReport As ICollection(Of ShipmentProblemReport) = New HashSet(Of ShipmentProblemReport)

End Class