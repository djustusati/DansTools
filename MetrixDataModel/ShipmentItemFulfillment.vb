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

Partial Public Class ShipmentItemFulfillment
    Public Property Id As Integer
    Public Property ShipmentItemId As Integer
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property Version As Nullable(Of Integer)
    Public Property ProductUnitCost As Nullable(Of Decimal)
    Public Property MinimumMarkup As Nullable(Of Double)
    Public Property MinimumMarkupType As Nullable(Of Integer)

    Public Overridable Property ShipmentItem As ShipmentItem
    Public Overridable Property ShipmentItemBox As ICollection(Of ShipmentItemBox) = New HashSet(Of ShipmentItemBox)
    Public Overridable Property ShipmentProblemReport As ICollection(Of ShipmentProblemReport) = New HashSet(Of ShipmentProblemReport)

End Class