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

Partial Public Class ContractDefinitionRule
    Public Property Id As Integer
    Public Property ContractDefinitionId As Integer
    Public Property PropertyName As String
    Public Property Value As String
    Public Property Priority As Nullable(Of Integer)
    Public Property EvaluationType As Nullable(Of Integer)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property Version As Nullable(Of Integer)
    Public Property HashValue As Nullable(Of Long)
    Public Property ContractRuleTemplateId As Nullable(Of Integer)

    Public Overridable Property ContractDefinition As ContractDefinition
    Public Overridable Property ContractRuleTemplate As ContractRuleTemplate

End Class
