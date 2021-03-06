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

Partial Public Class PhysicalCount
    Public Property Id As Integer
    Public Property StartDate As Date
    Public Property EndDate As Date
    Public Property Status As Nullable(Of Integer)
    Public Property StorageUnitAccountId As Integer
    Public Property CompletedDateTime As Nullable(Of Date)
    Public Property CompletedUserId As Nullable(Of System.Guid)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property Version As Nullable(Of Integer)

    Public Overridable Property PhysicalCountItem As ICollection(Of PhysicalCountItem) = New HashSet(Of PhysicalCountItem)
    Public Overridable Property PhysicalCountStatusChange As ICollection(Of PhysicalCountStatusChange) = New HashSet(Of PhysicalCountStatusChange)
    Public Overridable Property StorageUnitAccount As StorageUnitAccount

End Class
