Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("schedule")>
Partial Public Class schedule
    Public Sub New()
        profile = New HashSet(Of profile)()
    End Sub

    <Key>
    Public Property schedule_id As Integer

    Public Property income As TimeSpan

    Public Property lunch_start As TimeSpan

    Public Property lunch_end As TimeSpan

    Public Property output As TimeSpan

    Public Overridable Property profile As ICollection(Of profile)
End Class
