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
    Public Class schedulesController
        Inherits System.Web.Http.ApiController

        Private db As New Model1

        ' GET: api/schedules
        Function Getschedule() As IQueryable(Of schedule)
            Return db.schedule
        End Function

        ' GET: api/schedules/5
        <ResponseType(GetType(schedule))>
        Function Getschedule(ByVal id As Integer) As IHttpActionResult
            Dim schedule As schedule = db.schedule.Find(id)
            If IsNothing(schedule) Then
                Return NotFound()
            End If

            Return Ok(schedule)
        End Function

        ' PUT: api/schedules/5
        <ResponseType(GetType(Void))>
        Function Putschedule(ByVal id As Integer, ByVal schedule As schedule) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = schedule.schedule_id Then
                Return BadRequest()
            End If

            db.Entry(schedule).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (scheduleExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/schedules
        <ResponseType(GetType(schedule))>
        Function Postschedule(ByVal schedule As schedule) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.schedule.Add(schedule)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = schedule.schedule_id}, schedule)
        End Function

        ' DELETE: api/schedules/5
        <ResponseType(GetType(schedule))>
        Function Deleteschedule(ByVal id As Integer) As IHttpActionResult
            Dim schedule As schedule = db.schedule.Find(id)
            If IsNothing(schedule) Then
                Return NotFound()
            End If

            db.schedule.Remove(schedule)
            db.SaveChanges()

            Return Ok(schedule)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function scheduleExists(ByVal id As Integer) As Boolean
            Return db.schedule.Count(Function(e) e.schedule_id = id) > 0
        End Function
    End Class
End Namespace