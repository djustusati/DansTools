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

Partial Public Class AlertRecipientDefinition
    Public Property Id As Integer
    Public Property AlertDefinitionId As Integer
    Public Property TargetRecipient As String
    Public Property Message As String
    Public Property EmailMessage As String
    Public Property ActionName As String
    Public Property ActionLink As String
    Public Property CreatedDateTime As Date
    Public Property CreatedByUserId As System.Guid
    Public Property ModifiedDateTime As Date
    Public Property ModifiedByUserId As System.Guid
    Public Property Version As Integer

    Public Overridable Property Alert As ICollection(Of Alert) = New HashSet(Of Alert)
    Public Overridable Property AlertDefinition As AlertDefinition

End Class