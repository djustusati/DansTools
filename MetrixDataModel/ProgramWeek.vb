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

Partial Public Class ProgramWeek
    Public Property Id As Integer
    Public Property StartDate As Nullable(Of Date)
    Public Property WeekNumber As String
    Public Property ProgramId As Nullable(Of Integer)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property Version As Nullable(Of Integer)

    Public Overridable Property Program As Program
    Public Overridable Property StaffHoursRecap As ICollection(Of StaffHoursRecap) = New HashSet(Of StaffHoursRecap)
    Public Overridable Property TeamWeekDetail As ICollection(Of TeamWeekDetail) = New HashSet(Of TeamWeekDetail)

End Class