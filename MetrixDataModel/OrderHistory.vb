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

Partial Public Class OrderHistory
    Public Property Id As Integer
    Public Property CityTaxPercentage As Nullable(Of Double)
    Public Property CountyTaxPercentage As Nullable(Of Double)
    Public Property StateTaxPercentage As Nullable(Of Double)
    Public Property Version As Integer
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property OrderId As Nullable(Of Integer)
    Public Property SpecialTaxPercentage As Nullable(Of Double)
    Public Property LocalTaxPercentage As Nullable(Of Double)

    Public Overridable Property Orders As Orders
    Public Overridable Property OrderHistoryItem As ICollection(Of OrderHistoryItem) = New HashSet(Of OrderHistoryItem)

End Class
