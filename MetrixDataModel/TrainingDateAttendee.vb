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

Partial Public Class TrainingDateAttendee
    Public Property Id As Integer
    Public Property TrainingDateId As Integer
    Public Property EmployeeId As Integer
    Public Property Hours As Nullable(Of Double)
    Public Property ParkingPass As Nullable(Of Boolean)
    Public Property CompletedTraining As Nullable(Of Boolean)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property Version As Nullable(Of Integer)

    Public Overridable Property Employee As Employee
    Public Overridable Property TrainingDate As TrainingDate

End Class
