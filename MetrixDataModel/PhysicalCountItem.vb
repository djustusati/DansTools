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

Partial Public Class PhysicalCountItem
    Public Property Id As Integer
    Public Property StorageUnitAccountItemInventoryId As Nullable(Of Integer)
    Public Property PhysicalCountId As Integer
    Public Property AvailableQuantity As Nullable(Of Integer)
    Public Property Comments As String
    Public Property Status As Nullable(Of Integer)
    Public Property PhysicalCountExtraItemPOSNumber As String
    Public Property PhysicalCountExtraItemName As String
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property Version As Nullable(Of Integer)
    Public Property CurrentInventoryQuantity As Nullable(Of Integer)

    Public Overridable Property ItemInventory As ItemInventory
    Public Overridable Property PhysicalCount As PhysicalCount

End Class