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

Partial Public Class RecapNonReimbursableItem
    Public Property Id As Integer
    Public Property RecapId As Integer
    Public Property StorageUnitAccountItemInventoryId As Integer
    Public Property StartingInventory As Nullable(Of Integer)
    Public Property EndingInventory As Nullable(Of Integer)
    Public Property VouchersDistributed As Nullable(Of Integer)
    Public Property QuantitySold As Nullable(Of Integer)
    Public Property VouchersCollected As Nullable(Of Integer)
    Public Property CreatedDateTime As Date
    Public Property CreatedByUserId As System.Guid
    Public Property ModifiedByUserId As System.Guid
    Public Property ModifiedDateTime As Date
    Public Property Version As Integer
    Public Property IsRemoved As Nullable(Of Boolean)

End Class
