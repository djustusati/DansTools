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

Partial Public Class ItemProgramPhysicalCountSchedule
    Public Property Id As Integer
    Public Property ItemId As Integer
    Public Property ProgramId As Integer
    Public Property PhysicalCountScheduleId As Integer
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property Version As Nullable(Of Integer)

    Public Overridable Property Item As Item
    Public Overridable Property PhysicalCountSchedule As PhysicalCountSchedule

End Class