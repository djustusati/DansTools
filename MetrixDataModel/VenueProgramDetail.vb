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

Partial Public Class VenueProgramDetail
    Public Property Id As Integer
    Public Property VenueId As Integer
    Public Property ProgramId As Nullable(Of Integer)
    Public Property MarketId As Nullable(Of Integer)
    Public Property IsActive As Nullable(Of Boolean)
    Public Property ContractStatus As Nullable(Of Integer)
    Public Property AmendmentStatus As Nullable(Of Integer)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property Version As Nullable(Of Integer)

    Public Overridable Property Contract As ICollection(Of Contract) = New HashSet(Of Contract)
    Public Overridable Property ContractRequest As ICollection(Of ContractRequest) = New HashSet(Of ContractRequest)
    Public Overridable Property Market As Market
    Public Overridable Property Venue As Venue
    Public Overridable Property VenueProgramDetailAttribute As ICollection(Of VenueProgramDetailAttribute) = New HashSet(Of VenueProgramDetailAttribute)
    Public Overridable Property VenueProgramDetailConfirmationStatus As ICollection(Of VenueProgramDetailConfirmationStatus) = New HashSet(Of VenueProgramDetailConfirmationStatus)
    Public Overridable Property VenueProgramDetailSchedule As ICollection(Of VenueProgramDetailSchedule) = New HashSet(Of VenueProgramDetailSchedule)
    Public Overridable Property DemographicType As ICollection(Of DemographicType) = New HashSet(Of DemographicType)
    Public Overridable Property DistinctionType As ICollection(Of DistinctionType) = New HashSet(Of DistinctionType)
    Public Overridable Property LocationType As ICollection(Of LocationType) = New HashSet(Of LocationType)
    Public Overridable Property MusicType As ICollection(Of MusicType) = New HashSet(Of MusicType)
    Public Overridable Property SeasonalityType As ICollection(Of SeasonalityType) = New HashSet(Of SeasonalityType)

End Class
