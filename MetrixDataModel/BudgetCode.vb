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

Partial Public Class BudgetCode
    Public Property Id As Integer
    Public Property Version As Integer
    Public Property Code As String
    Public Property Name As String
    Public Property ProgramId As Nullable(Of Integer)
    Public Property IsActive As Nullable(Of Boolean)
    Public Property IsPending As Nullable(Of Boolean)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)

    Public Overridable Property Activation As ICollection(Of Activation) = New HashSet(Of Activation)
    Public Overridable Property Activity As ICollection(Of Activity) = New HashSet(Of Activity)
    Public Overridable Property AssignedBrand As ICollection(Of AssignedBrand) = New HashSet(Of AssignedBrand)
    Public Overridable Property [Event] As ICollection(Of [Event]) = New HashSet(Of [Event])

End Class