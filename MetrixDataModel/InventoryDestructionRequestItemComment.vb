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

Partial Public Class InventoryDestructionRequestItemComment
    Public Property Id As Integer
    Public Property InventoryDestructionRequestItemId As Integer
    Public Property CommentName As String
    Public Property CommentText As String
    Public Property CommentDate As Nullable(Of Date)
    Public Property CreatedDateTime As Date
    Public Property CreatedByUserId As System.Guid
    Public Property ModifiedDateTime As Date
    Public Property ModifiedByUserId As System.Guid
    Public Property Version As Integer

    Public Overridable Property InventoryDestructionRequestItem As InventoryDestructionRequestItem

End Class
