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

Partial Public Class PromotionTypeQuestion
    Public Property Id As Integer
    Public Property PromotionTypeId As Integer
    Public Property QuestionText As String
    Public Property QuestionType As Integer
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property Version As Nullable(Of Integer)
    Public Property SortOrder As Nullable(Of Integer)
    Public Property IsRemoved As Nullable(Of Boolean)

    Public Overridable Property PromotionType As PromotionType
    Public Overridable Property PromotionTypeQuestionAnswer As ICollection(Of PromotionTypeQuestionAnswer) = New HashSet(Of PromotionTypeQuestionAnswer)

End Class