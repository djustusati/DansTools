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

Partial Public Class PersonAddress
    Public Property Id As Integer
    Public Property Version As Integer
    Public Property AddressAddressLine1 As String
    Public Property AddressAddressLine2 As String
    Public Property AddressCity As String
    Public Property AddressState As String
    Public Property AddressPostalCode As String
    Public Property Type As Nullable(Of Short)
    Public Property CreatedDateTime As Nullable(Of Date)
    Public Property CreatedByUserId As Nullable(Of System.Guid)
    Public Property ModifiedDateTime As Nullable(Of Date)
    Public Property ModifiedByUserId As Nullable(Of System.Guid)
    Public Property PersonId As Nullable(Of Integer)

    Public Overridable Property Person As Person

End Class
