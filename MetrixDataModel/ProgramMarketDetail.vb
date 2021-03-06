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

Partial Public Class ProgramMarketDetail
    Public Property Id As Integer
    Public Property ProgramId As Integer
    Public Property MarketId As Integer
    Public Property RegionId As Nullable(Of Integer)
    Public Property MarketSizeId As Nullable(Of Integer)
    Public Property MarketManagerId As Nullable(Of Integer)
    Public Property DestinationMarket As Nullable(Of Boolean)
    Public Property SalesMarketFlag As Nullable(Of Boolean)
    Public Property RetailMarketFlag As Nullable(Of Boolean)
    Public Property ActiveDate As Nullable(Of Date)
    Public Property InactiveDate As Nullable(Of Date)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property AdaptMarketName As String
    Public Property Version As Nullable(Of Integer)

    Public Overridable Property Market As Market
    Public Overridable Property MarketSize As MarketSize
    Public Overridable Property Program As Program

End Class
