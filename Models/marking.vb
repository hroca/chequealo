Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("marking")>
Partial Public Class marking
    Public Sub New()
        delay = New HashSet(Of delay)()
    End Sub

    <Key>
    Public Property marking_id As Integer

    Public Property profile_id As Integer

    Public Property entry_at As Date

    Public Property departure_at As Date?

    Public Property deleted_at As Date?

    Public Overridable Property delay As ICollection(Of delay)

    Public Overridable Property profile As profile
End Class
