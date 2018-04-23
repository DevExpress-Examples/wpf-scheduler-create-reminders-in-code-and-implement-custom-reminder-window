using DevExpress.Xpf.Scheduling;
using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomReminderExample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        #region #RemindersWindowShowing
        private void Scheduler_RemindersWindowShowing(object sender, DevExpress.Xpf.Scheduling.RemindersWindowShowingEventArgs e) {
            if (e.TriggeredReminders.Any(r => r.Appointment.Subject.Contains("test"))) {
                DevExpress.Xpf.Scheduling.Visual.RemindersWindow reminderWindow = new DevExpress.Xpf.Scheduling.Visual.RemindersWindow();
                reminderWindow.DataContext = new DevExpress.Xpf.Scheduling.VisualData.RemindersWindowViewModel(scheduler);
                e.Window = reminderWindow;
            }
        }
        #endregion #RemindersWindowShowing

        private void Scheduler_InitNewAppointment(object sender, DevExpress.Xpf.Scheduling.AppointmentItemEventArgs e) {
            AddAppointmentReminders(e.Appointment);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            AppointmentItem apt = new AppointmentItem(AppointmentType.Normal) 
            { Start = DateTime.Today.AddHours(DateTime.Now.Hour), End = DateTime.Today.AddHours(DateTime.Now.Hour + 1), Subject = "Reminder Test" };
            AddAppointmentReminders(apt);
            scheduler.AppointmentItems.Add(apt);
        }

        private static void AddAppointmentReminders(AppointmentItem appointment) {
            #region #AddAppointmentReminders
            // Remove previous reminders
            appointment.Reminders.Clear();
            // Set multiple reminders for an appointment
            ReminderItem reminder1 = appointment.CreateNewReminder();
            ReminderItem reminder2 = appointment.CreateNewReminder();
            reminder1.AlertTime = DateTime.Now.AddMinutes(15);
            reminder2.TimeBeforeStart = new TimeSpan(0, 30, 0);

            appointment.Reminders.Add(reminder1);
            appointment.Reminders.Add(reminder2);
            #endregion #AddAppointmentReminders
        }
    }
}
