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

Partial Public Class Contract
    Public Property Id As Integer
    Public Property ContractDefinitionId As Integer
    Public Property VenueProgramDetailId As Integer
    Public Property ContractRequestId As Nullable(Of Integer)
    Public Property Status As Nullable(Of Integer)
    Public Property ContractNumber As String
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property Version As Nullable(Of Integer)
    Public Property TerminatedDateTime As Nullable(Of Date)
    Public Property EffectiveStartDateTime As Nullable(Of Date)
    Public Property EffectiveEndDateTime As Nullable(Of Date)
    Public Property ApprovedDateTime As Nullable(Of Date)
    Public Property ApprovedById As Nullable(Of Integer)

    Public Overridable Property ContractDefinition As ContractDefinition
    Public Overridable Property Employee As Employee
    Public Overridable Property VenueProgramDetail As VenueProgramDetail
    Public Overridable Property ContractAmendment As ICollection(Of ContractAmendment) = New HashSet(Of ContractAmendment)
    Public Overridable Property ContractPayment As ICollection(Of ContractPayment) = New HashSet(Of ContractPayment)

End Class
