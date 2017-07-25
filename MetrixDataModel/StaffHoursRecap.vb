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

Partial Public Class StaffHoursRecap
    Public Property Id As Integer
    Public Property ProgramWeekId As Integer
    Public Property TeamId As Integer
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property Version As Integer
    Public Property ApprovedBy As Nullable(Of Integer)
    Public Property Status As Integer
    Public Property ApprovedDateTime As Nullable(Of Date)

    Public Overridable Property Employee As Employee
    Public Overridable Property ProgramWeek As ProgramWeek
    Public Overridable Property Team As Team
    Public Overridable Property StaffHoursRecapItem As ICollection(Of StaffHoursRecapItem) = New HashSet(Of StaffHoursRecapItem)

End Class
