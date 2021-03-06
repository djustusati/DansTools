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

Partial Public Class ItemInventory
    Public Property Id As Integer
    Public Property ItemId As Integer
    Public Property ProductExpirationDate As Nullable(Of Date)
    Public Property Description As String
    Public Property Comments As String
    Public Property IsActive As Nullable(Of Boolean)
    Public Property Qty As Integer
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property ProductShipToState As String
    Public Property Version As Nullable(Of Integer)
    Public Property ProductUnitCost As Nullable(Of Decimal)
    Public Property MinimumMarkup As Nullable(Of Decimal)
    Public Property MinimumMarkupType As Nullable(Of Integer)
    Public Property DamagedQuantity As Nullable(Of Integer)
    Public Property InTransitQuantity As Nullable(Of Integer)

    Public Overridable Property InventoryRequestItem As ICollection(Of InventoryRequestItem) = New HashSet(Of InventoryRequestItem)
    Public Overridable Property PhysicalCountItem As ICollection(Of PhysicalCountItem) = New HashSet(Of PhysicalCountItem)
    Public Overridable Property ItemInventoryTransaction As ICollection(Of ItemInventoryTransaction) = New HashSet(Of ItemInventoryTransaction)
    Public Overridable Property OrderHistoryItem As ICollection(Of OrderHistoryItem) = New HashSet(Of OrderHistoryItem)
    Public Overridable Property OrderItem As ICollection(Of OrderItem) = New HashSet(Of OrderItem)
    Public Overridable Property ShipmentItem As ICollection(Of ShipmentItem) = New HashSet(Of ShipmentItem)
    Public Overridable Property StorageUnitAccount As ICollection(Of StorageUnitAccount) = New HashSet(Of StorageUnitAccount)

End Class
