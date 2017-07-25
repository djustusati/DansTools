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

Partial Public Class IncidentReport
    Public Property Id As Integer
    Public Property IncidentTypeId As Integer
    Public Property ProgramId As Integer
    Public Property MarketId As Integer
    Public Property IncidentDateTime As Date
    Public Property GovermentOfficialFirstName As String
    Public Property GovermentOfficialLastName As String
    Public Property PoliceReportNumber As String
    Public Property IncidentLocation As String
    Public Property WeatherFactorDescription As String
    Public Property PersonId As Integer
    Public Property NotifyManagerDateTime As Nullable(Of Date)
    Public Property RiskManagementDateTime As Nullable(Of Date)
    Public Property FirstAidId As Nullable(Of Integer)
    Public Property IncidentSummaryDescription As String
    Public Property Version As Nullable(Of Integer)
    Public Property CreatedByUserId As System.Guid
    Public Property CreatedDateTime As Date
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property IncidentPrimarySubjectType As Nullable(Of Integer)
    Public Property BrandId As Nullable(Of Integer)
    Public Property Status As Nullable(Of Integer)

End Class
