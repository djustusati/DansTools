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

Partial Public Class RecapInventory
    Public Property Id As Integer
    Public Property RecapId As Integer
    Public Property EmployeeId As Nullable(Of Integer)
    Public Property StorageUnitAccountItemInventoryId As Nullable(Of Integer)
    Public Property DemoDistributed As Nullable(Of Integer)
    Public Property EmployeeDistributed As Nullable(Of Integer)
    Public Property QATCDistributed As Nullable(Of Integer)
    Public Property TotalDistributed As Nullable(Of Integer)
    Public Property QuantityDistributed As Nullable(Of Integer)
    Public Property IsRemoved As Nullable(Of Boolean)
    Public Property CreatedDateTime As Date
    Public Property CreatedByUserId As System.Guid
    Public Property ModifiedByUserId As System.Guid
    Public Property ModifiedDateTime As Date
    Public Property Version As Integer
    Public Property DCDItemAlias As String
    Public Property RecapDCDId As Nullable(Of Integer)
    Public Property Status As Nullable(Of Integer)

    Public Overridable Property Employee As Employee
    Public Overridable Property Recap As Recap

End Class