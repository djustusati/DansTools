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

Partial Public Class VenueReceipt
    Public Property Id As Integer
    Public Property ReceiptDate As Date
    Public Property VenueId As Integer
    Public Property NotifyOnApproval As Boolean
    Public Property Status As Integer
    Public Property CommentName As String
    Public Property CommentDate As Nullable(Of Date)
    Public Property CommentText As String
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property Version As Nullable(Of Integer)
    Public Property ApprovedById As Nullable(Of Integer)
    Public Property ApprovedDateTime As Nullable(Of Date)
    Public Property RejectedById As Nullable(Of Integer)
    Public Property RejectedDateTime As Nullable(Of Date)

    Public Overridable Property Venue As Venue
    Public Overridable Property VenueReceiptDocument As ICollection(Of VenueReceiptDocument) = New HashSet(Of VenueReceiptDocument)
    Public Overridable Property VenueReceiptItem As ICollection(Of VenueReceiptItem) = New HashSet(Of VenueReceiptItem)

End Class
