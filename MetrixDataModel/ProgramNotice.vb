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

Partial Public Class ProgramNotice
    Public Property Id As Integer
    Public Property Name As String
    Public Property ValidFrom As Nullable(Of Date)
    Public Property ValidTo As Nullable(Of Date)
    Public Property Text As String
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property Version As Nullable(Of Integer)
    Public Property Priority As Nullable(Of Integer)

    Public Overridable Property ProgramNoticeProgram As ICollection(Of ProgramNoticeProgram) = New HashSet(Of ProgramNoticeProgram)

End Class
