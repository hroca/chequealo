Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("delay")>
Partial Public Class delay
    <Key>
    Public Property delay_id As Integer

    Public Property created_at As Date

    Public Property marking_id As Integer

    Public Property deleted_at As Date?

    Public Overridable Property marking As marking
End Class
