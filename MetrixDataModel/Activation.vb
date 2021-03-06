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

Partial Public Class Activation
    Public Property Id As Integer
    Public Property Version As Integer
    Public Property Name As String
    Public Property MarketId As Nullable(Of Integer)
    Public Property ProgramId As Nullable(Of Integer)
    Public Property Status As Nullable(Of Integer)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property DefaultSecondaryTimesheetApproverId As Nullable(Of Integer)
    Public Property PrimaryManagerId As Nullable(Of Integer)
    Public Property TeamId As Nullable(Of Integer)
    Public Property DefaultBudgetCodeId As Nullable(Of Integer)

    Public Overridable Property BudgetCode As BudgetCode
    Public Overridable Property Employee As Employee
    Public Overridable Property Employee1 As Employee
    Public Overridable Property Team As Team
    Public Overridable Property ActivationStatusChange As ICollection(Of ActivationStatusChange) = New HashSet(Of ActivationStatusChange)
    Public Overridable Property Activity As ICollection(Of Activity) = New HashSet(Of Activity)
    Public Overridable Property Employee2 As ICollection(Of Employee) = New HashSet(Of Employee)
    Public Overridable Property Employee3 As ICollection(Of Employee) = New HashSet(Of Employee)

End Class
