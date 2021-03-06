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

Partial Public Class TrainingDate
    Public Property Id As Integer
    Public Property TrainingId As Integer
    Public Property ProgramId As Integer
    Public Property MarketId As Integer
    Public Property TrainingDateTime As Nullable(Of Date)
    Public Property TrainerId As Nullable(Of Integer)
    Public Property Duration As Nullable(Of Double)
    Public Property Completed As Nullable(Of Boolean)
    Public Property CompletedDateTime As Nullable(Of Date)
    Public Property Location As String
    Public Property AddressAddressLine1 As String
    Public Property AddressAddressLine2 As String
    Public Property AddressCity As String
    Public Property AddressState As String
    Public Property AddressPostalCode As String
    Public Property Comments As String
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property Version As Nullable(Of Integer)
    Public Property HasDocument As Boolean
    Public Property TrainingLocationType As Nullable(Of Integer)

    Public Overridable Property Program As Program
    Public Overridable Property Training As Training
    Public Overridable Property TrainingDateAttendee As ICollection(Of TrainingDateAttendee) = New HashSet(Of TrainingDateAttendee)
    Public Overridable Property TrainingDateDocument As ICollection(Of TrainingDateDocument) = New HashSet(Of TrainingDateDocument)

End Class
