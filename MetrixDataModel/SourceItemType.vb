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

Partial Public Class SourceItemType
    Public Property Id As Integer
    Public Property SourceId As Integer
    Public Property ItemTypeId As Integer
    Public Property Description As String
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property Version As Nullable(Of Integer)

    Public Overridable Property ItemType As ItemType
    Public Overridable Property Source As Source

End Class
