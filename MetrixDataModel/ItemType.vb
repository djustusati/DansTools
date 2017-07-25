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

Partial Public Class ItemType
    Public Property Id As Integer
    Public Property Name As String
    Public Property Description As String
    Public Property Comments As String
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property IsActive As Nullable(Of Boolean)
    Public Property AllowRecap As Nullable(Of Boolean)
    Public Property IsProduct As Boolean
    Public Property Version As Nullable(Of Integer)

    Public Overridable Property Item As ICollection(Of Item) = New HashSet(Of Item)
    Public Overridable Property ItemTypeAtributes As ICollection(Of ItemTypeAtributes) = New HashSet(Of ItemTypeAtributes)
    Public Overridable Property SourceItemType As ICollection(Of SourceItemType) = New HashSet(Of SourceItemType)
    Public Overridable Property VisibilityItemInstallationTypeItemType As ICollection(Of VisibilityItemInstallationTypeItemType) = New HashSet(Of VisibilityItemInstallationTypeItemType)

End Class
