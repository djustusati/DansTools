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

Partial Public Class MarketSize
    Public Property Id As Integer
    Public Property Description As String
    Public Property CostPerInteractionGoal As Nullable(Of Double)

    Public Overridable Property ProgramMarketDetail As ICollection(Of ProgramMarketDetail) = New HashSet(Of ProgramMarketDetail)

End Class