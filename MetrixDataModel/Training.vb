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

Partial Public Class Training
    Public Property Id As Integer
    Public Property Name As String
    Public Property Description As String
    Public Property BudgetCode As String
    Public Property AvailableStartDate As Nullable(Of Date)
    Public Property AvailableEndDate As Nullable(Of Date)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property Version As Nullable(Of Integer)

    Public Overridable Property TrainingDate As ICollection(Of TrainingDate) = New HashSet(Of TrainingDate)
    Public Overridable Property TrainingMarket As ICollection(Of TrainingMarket) = New HashSet(Of TrainingMarket)
    Public Overridable Property Program As ICollection(Of Program) = New HashSet(Of Program)
    Public Overridable Property Topic As ICollection(Of Topic) = New HashSet(Of Topic)

End Class
