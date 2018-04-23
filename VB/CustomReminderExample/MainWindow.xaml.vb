Imports DevExpress.Xpf.Scheduling
Imports DevExpress.XtraScheduler
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace CustomReminderExample
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub
        #Region "#RemindersWindowShowing"
        Private Sub Scheduler_RemindersWindowShowing(ByVal sender As Object, ByVal e As DevExpress.Xpf.Scheduling.RemindersWindowShowingEventArgs)
            If e.TriggeredReminders.Any(Function(r) r.Appointment.Subject.Contains("test")) Then
                Dim reminderWindow As New DevExpress.Xpf.Scheduling.Visual.RemindersWindow()
                reminderWindow.DataContext = New DevExpress.Xpf.Scheduling.VisualData.RemindersWindowViewModel(scheduler)
                e.Window = reminderWindow
            End If
        End Sub
        #End Region ' #RemindersWindowShowing

        Private Sub Scheduler_InitNewAppointment(ByVal sender As Object, ByVal e As DevExpress.Xpf.Scheduling.AppointmentItemEventArgs)
            AddAppointmentReminders(e.Appointment)
        End Sub

        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim apt As New AppointmentItem(AppointmentType.Normal) With { _
                .Start = Date.Today.AddHours(Date.Now.Hour), _
                .End = Date.Today.AddHours(Date.Now.Hour + 1), _
                .Subject = "Reminder Test" _
            }
            AddAppointmentReminders(apt)
            scheduler.AppointmentItems.Add(apt)
        End Sub

        Private Shared Sub AddAppointmentReminders(ByVal appointment As AppointmentItem)
'            #Region "#AddAppointmentReminders"
            ' Remove previous reminders
            appointment.Reminders.Clear()
            ' Set multiple reminders for an appointment
            Dim reminder1 As ReminderItem = appointment.CreateNewReminder()
            Dim reminder2 As ReminderItem = appointment.CreateNewReminder()
            reminder1.AlertTime = Date.Now.AddMinutes(15)
            reminder2.TimeBeforeStart = New TimeSpan(0, 30, 0)

            appointment.Reminders.Add(reminder1)
            appointment.Reminders.Add(reminder2)
'            #End Region ' #AddAppointmentReminders
        End Sub
    End Class
End Namespace
