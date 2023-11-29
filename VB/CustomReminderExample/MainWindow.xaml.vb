Imports DevExpress.Xpf.Scheduling
Imports DevExpress.XtraScheduler
Imports System
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls

Namespace CustomReminderExample

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

#Region "#RemindersWindowShowing"
        Private Sub Scheduler_RemindersWindowShowing(ByVal sender As Object, ByVal e As RemindersWindowShowingEventArgs)
            If e.TriggeredReminders.Any(Function(r) r.Appointment.Subject.Contains("test")) Then
                Dim reminderWindow As DevExpress.Xpf.Scheduling.Visual.RemindersWindow = New DevExpress.Xpf.Scheduling.Visual.RemindersWindow()
                reminderWindow.DataContext = New VisualData.RemindersWindowViewModel(Me.scheduler)
                e.Window = reminderWindow
            End If
        End Sub

#End Region  ' #RemindersWindowShowing
        Private Sub Scheduler_InitNewAppointment(ByVal sender As Object, ByVal e As AppointmentItemEventArgs)
            Call AddAppointmentReminders(e.Appointment)
        End Sub

        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim apt As AppointmentItem = New AppointmentItem(AppointmentType.Normal) With {.Start = Date.Today.AddHours(Date.Now.Hour), .[End] = Date.Today.AddHours(Date.Now.Hour + 1), .Subject = "Reminder Test"}
            Call AddAppointmentReminders(apt)
            Me.scheduler.AppointmentItems.Add(apt)
        End Sub

        Private Shared Sub AddAppointmentReminders(ByVal appointment As AppointmentItem)
#Region "#AddAppointmentReminders"
            ' Remove previous reminders
            appointment.Reminders.Clear()
            ' Set multiple reminders for an appointment
            Dim reminder1 As ReminderItem = appointment.CreateNewReminder()
            Dim reminder2 As ReminderItem = appointment.CreateNewReminder()
            reminder1.AlertTime = Date.Now.AddMinutes(15)
            reminder2.TimeBeforeStart = New TimeSpan(0, 30, 0)
            appointment.Reminders.Add(reminder1)
            appointment.Reminders.Add(reminder2)
#End Region  ' #AddAppointmentReminders
        End Sub
    End Class
End Namespace
