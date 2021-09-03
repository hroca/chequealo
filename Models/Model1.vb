Imports System
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Linq

Partial Public Class Model1
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=GeneralModel")
    End Sub

    Public Overridable Property delay As DbSet(Of delay)
    Public Overridable Property marking As DbSet(Of marking)
    Public Overridable Property profile As DbSet(Of profile)
    Public Overridable Property schedule As DbSet(Of schedule)
    Public Overridable Property users As DbSet(Of users)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of marking)() _
            .HasMany(Function(e) e.delay) _
            .WithRequired(Function(e) e.marking) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of profile)() _
            .Property(Function(e) e.first_name) _
            .IsUnicode(False)

        modelBuilder.Entity(Of profile)() _
            .Property(Function(e) e.last_name) _
            .IsUnicode(False)

        modelBuilder.Entity(Of profile)() _
            .Property(Function(e) e.address) _
            .IsUnicode(False)

        modelBuilder.Entity(Of profile)() _
            .Property(Function(e) e.job_position) _
            .IsUnicode(False)

        modelBuilder.Entity(Of profile)() _
            .HasMany(Function(e) e.marking) _
            .WithRequired(Function(e) e.profile) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of schedule)() _
            .HasMany(Function(e) e.profile) _
            .WithRequired(Function(e) e.schedule) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of users)() _
            .Property(Function(e) e.username) _
            .IsUnicode(False)

        modelBuilder.Entity(Of users)() _
            .Property(Function(e) e.role) _
            .IsUnicode(False)

        modelBuilder.Entity(Of users)() _
            .Property(Function(e) e.password) _
            .IsUnicode(False)

        modelBuilder.Entity(Of users)() _
            .Property(Function(e) e.email) _
            .IsUnicode(False)

        modelBuilder.Entity(Of users)() _
            .Property(Function(e) e.apikey) _
            .IsUnicode(False)

        modelBuilder.Entity(Of users)() _
            .HasMany(Function(e) e.profile) _
            .WithRequired(Function(e) e.users) _
            .WillCascadeOnDelete(False)
    End Sub
End Class
