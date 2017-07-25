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

Partial Public Class Program
    Public Property Id As Integer
    Public Property Name As String
    Public Property ShortName As String
    Public Property MasterProgramId As Nullable(Of Integer)
    Public Property StartDate As Nullable(Of Date)
    Public Property EndDate As Nullable(Of Date)
    Public Property ContractProgramName As String
    Public Property ContractYear As Nullable(Of Integer)
    Public Property ContractingStartDate As Nullable(Of Date)
    Public Property ContractingEndDate As Nullable(Of Date)
    Public Property ContractVisits As Nullable(Of Integer)
    Public Property IsActive As Nullable(Of Boolean)
    Public Property ProgramCode As String
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property Version As Nullable(Of Integer)
    Public Property ShouldNotifyMarlboroCom As Nullable(Of Boolean)
    Public Property OwnerName As String

    Public Overridable Property Alert As ICollection(Of Alert) = New HashSet(Of Alert)
    Public Overridable Property ContractDefinition As ICollection(Of ContractDefinition) = New HashSet(Of ContractDefinition)
    Public Overridable Property MarketStandardPriceRule As ICollection(Of MarketStandardPriceRule) = New HashSet(Of MarketStandardPriceRule)
    Public Overridable Property ProgramMarketDetail As ICollection(Of ProgramMarketDetail) = New HashSet(Of ProgramMarketDetail)
    Public Overridable Property ProgramSetting As ICollection(Of ProgramSetting) = New HashSet(Of ProgramSetting)
    Public Overridable Property ProgramWeek As ICollection(Of ProgramWeek) = New HashSet(Of ProgramWeek)
    Public Overridable Property Survey As ICollection(Of Survey) = New HashSet(Of Survey)
    Public Overridable Property Task As ICollection(Of Task) = New HashSet(Of Task)
    Public Overridable Property TrainingDate As ICollection(Of TrainingDate) = New HashSet(Of TrainingDate)
    Public Overridable Property VenuePayment As ICollection(Of VenuePayment) = New HashSet(Of VenuePayment)
    Public Overridable Property Training As ICollection(Of Training) = New HashSet(Of Training)

End Class