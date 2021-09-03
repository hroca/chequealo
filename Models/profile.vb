Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("profile")>
Partial Public Class profile
    Public Sub New()
        marking = New HashSet(Of marking)()
    End Sub

    <Key>
    Public Property profile_id As Integer

    <Required>
    <StringLength(255)>
    Public Property first_name As String

    <Required>
    <StringLength(255)>
    Public Property last_name As String

    <Required>
    <StringLength(255)>
    Public Property address As String

    <Required>
    <StringLength(255)>
    Public Property job_position As String

    Public Property schedule_id As Integer

    Public Property user_id As Integer

    Public Overridable Property marking As ICollection(Of marking)

    Public Overridable Property schedule As schedule

    Public Overridable Property users As users
End Class
