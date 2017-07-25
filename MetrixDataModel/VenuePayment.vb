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

Partial Public Class VenuePayment
    Public Property Id As Integer
    Public Property VenueId As Nullable(Of Integer)
    Public Property RecapId As Nullable(Of Integer)
    Public Property Type As Nullable(Of Integer)
    Public Property Status As Nullable(Of Integer)
    Public Property PaymentDefinitionName As String
    Public Property Months As Nullable(Of Decimal)
    Public Property MonthlyBonusAmount As Nullable(Of Decimal)
    Public Property ProductCost As Nullable(Of Decimal)
    Public Property MinimumMarkup As Nullable(Of Decimal)
    Public Property Amount As Decimal
    Public Property CheckFileId As String
    Public Property InvoiceNumber As String
    Public Property CheckNumber As Nullable(Of Integer)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property Version As Nullable(Of Integer)
    Public Property PaymentPeriodStartDateTime As Nullable(Of Date)
    Public Property PaymentPeriodEndDateTime As Nullable(Of Date)
    Public Property VoucherNumber As Nullable(Of Integer)
    Public Property CheckAmount As Nullable(Of Decimal)
    Public Property ContractId As Nullable(Of Integer)
    Public Property CheckDateTime As Nullable(Of Date)
    Public Property ProgramId As Nullable(Of Integer)
    Public Property MarketId As Nullable(Of Integer)
    Public Property VoidCommentName As String
    Public Property VoidCommentText As String
    Public Property VoidCommentDate As Nullable(Of Date)
    Public Property VoidedById As Nullable(Of Integer)
    Public Property VenueNumber As String

    Public Overridable Property Employee As Employee
    Public Overridable Property Market As Market
    Public Overridable Property Program As Program

End Class
