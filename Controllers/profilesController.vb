Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports chequealo

Namespace Controllers
    Public Class profilesController
        Inherits System.Web.Http.ApiController

        Private db As New Model1

        ' GET: api/profiles
        Function Getprofile() As IQueryable(Of profile)
            Return db.profile
        End Function

        ' GET: api/profiles/5
        <ResponseType(GetType(profile))>
        Function Getprofile(ByVal id As Integer) As IHttpActionResult
            Dim profile As profile = db.profile.Find(id)
            If IsNothing(profile) Then
                Return NotFound()
            End If

            Return Ok(profile)
        End Function

        ' PUT: api/profiles/5
        <ResponseType(GetType(Void))>
        Function Putprofile(ByVal id As Integer, ByVal profile As profile) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = profile.profile_id Then
                Return BadRequest()
            End If

            db.Entry(profile).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (profileExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/profiles
        <ResponseType(GetType(profile))>
        Function Postprofile(ByVal profile As profile) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.profile.Add(profile)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = profile.profile_id}, profile)
        End Function

        ' DELETE: api/profiles/5
        <ResponseType(GetType(profile))>
        Function Deleteprofile(ByVal id As Integer) As IHttpActionResult
            Dim profile As profile = db.profile.Find(id)
            If IsNothing(profile) Then
                Return NotFound()
            End If

            db.profile.Remove(profile)
            db.SaveChanges()

            Return Ok(profile)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function profileExists(ByVal id As Integer) As Boolean
            Return db.profile.Count(Function(e) e.profile_id = id) > 0
        End Function
    End Class
End Namespace