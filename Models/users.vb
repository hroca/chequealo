Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class users
    Public Sub New()
        profile = New HashSet(Of profile)()
    End Sub

    <Key>
    Public Property user_id As Integer

    <Required>
    <StringLength(25)>
    Public Property username As String

    <Required>
    <StringLength(15)>
    Public Property role As String

    <Required>
    <StringLength(50)>
    Public Property password As String

    <Required>
    <StringLength(35)>
    Public Property email As String

    <Required>
    <StringLength(100)>
    Public Property apikey As String

    Public Property enabled As Boolean

    Public Property created_at As Date

    Public Property updated_at As Date

    Public Property deleted_at As Date?

    Public Overridable Property profile As ICollection(Of profile)
End Class
