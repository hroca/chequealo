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
    Public Class delaysController
        Inherits System.Web.Http.ApiController

        Private db As New Model1

        ' GET: api/delays
        Function Getdelay() As IQueryable(Of delay)
            Return db.delay
        End Function

        ' GET: api/delays/5
        <ResponseType(GetType(delay))>
        Function Getdelay(ByVal id As Integer) As IHttpActionResult
            Dim delay As delay = db.delay.Find(id)
            If IsNothing(delay) Then
                Return NotFound()
            End If

            Return Ok(delay)
        End Function

        ' PUT: api/delays/5
        <ResponseType(GetType(Void))>
        Function Putdelay(ByVal id As Integer, ByVal delay As delay) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = delay.delay_id Then
                Return BadRequest()
            End If

            db.Entry(delay).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (delayExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/delays
        <ResponseType(GetType(delay))>
        Function Postdelay(ByVal delay As delay) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.delay.Add(delay)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = delay.delay_id}, delay)
        End Function

        ' DELETE: api/delays/5
        <ResponseType(GetType(delay))>
        Function Deletedelay(ByVal id As Integer) As IHttpActionResult
            Dim delay As delay = db.delay.Find(id)
            If IsNothing(delay) Then
                Return NotFound()
            End If

            db.delay.Remove(delay)
            db.SaveChanges()

            Return Ok(delay)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function delayExists(ByVal id As Integer) As Boolean
            Return db.delay.Count(Function(e) e.delay_id = id) > 0
        End Function
    End Class
End Namespace