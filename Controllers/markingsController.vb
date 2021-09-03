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
    Public Class markingsController
        Inherits System.Web.Http.ApiController

        Private db As New Model1

        ' GET: api/markings
        Function Getmarking() As IQueryable(Of marking)
            Return db.marking
        End Function

        ' GET: api/markings/5
        <ResponseType(GetType(marking))>
        Function Getmarking(ByVal id As Integer) As IHttpActionResult
            Dim marking As marking = db.marking.Find(id)
            If IsNothing(marking) Then
                Return NotFound()
            End If

            Return Ok(marking)
        End Function

        ' PUT: api/markings/5
        <ResponseType(GetType(Void))>
        Function Putmarking(ByVal id As Integer, ByVal marking As marking) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = marking.marking_id Then
                Return BadRequest()
            End If

            db.Entry(marking).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (markingExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/markings
        <ResponseType(GetType(marking))>
        Function Postmarking(ByVal marking As marking) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.marking.Add(marking)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = marking.marking_id}, marking)
        End Function

        ' DELETE: api/markings/5
        <ResponseType(GetType(marking))>
        Function Deletemarking(ByVal id As Integer) As IHttpActionResult
            Dim marking As marking = db.marking.Find(id)
            If IsNothing(marking) Then
                Return NotFound()
            End If

            db.marking.Remove(marking)
            db.SaveChanges()

            Return Ok(marking)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function markingExists(ByVal id As Integer) As Boolean
            Return db.marking.Count(Function(e) e.marking_id = id) > 0
        End Function
    End Class
End Namespace