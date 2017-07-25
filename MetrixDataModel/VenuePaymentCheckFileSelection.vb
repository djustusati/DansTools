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

Partial Public Class VenuePaymentCheckFileSelection
    Public Property Id As Integer
    Public Property RecapId As Integer
    Public Property VenueId As Integer
    Public Property VenueNumber As String
    Public Property VenueName As String
    Public Property ContractId As Integer
    Public Property PaymentAmount As Decimal
    Public Property VenuePaymentType As Integer
    Public Property PaymentDefinitionName As String
    Public Property PaymentDefinitionId As Integer
    Public Property ProductCost As Nullable(Of Decimal)
    Public Property MinimumMarkup As Nullable(Of Decimal)
    Public Property Months As Nullable(Of Decimal)
    Public Property MonthlyBonusAmount As Nullable(Of Decimal)
    Public Property GLCode As String
    Public Property BudgetCode As String
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property Version As Nullable(Of Integer)
    Public Property ProgramId As Nullable(Of Integer)
    Public Property MarketId As Nullable(Of Integer)

    Public Overridable Property VenuePaymentCheckFileSelectionItem As ICollection(Of VenuePaymentCheckFileSelectionItem) = New HashSet(Of VenuePaymentCheckFileSelectionItem)

End Class