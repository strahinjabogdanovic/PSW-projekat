using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace PswProject.model
{
    public class Appointment : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdA { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationInMinutes { get;  set; }
        public String AppointmentDescription { get;  set; }
        public int UserId { get;  set; }
        public virtual User User { get;  set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public AppointmentStatus Status { get; set; }
        public int SurveyId { get; set; }
        public Boolean isCancelled { get;  set; }
        public Boolean canCancel { get;  set; }
        public Boolean IsDeleted { get;  set; }

        public Appointment() { }

        public Appointment(DateTime startTime, int doctorId)
        {
            StartTime = startTime;
            DoctorId = doctorId;
        }
        public Appointment(DateTime start, int duration, string description, bool isDeleted, int doctorId, int patientId, bool isCancelled, bool canCancel)
        {
            StartTime = start;
            DurationInMinutes = duration;
            AppointmentDescription = description;
            IsDeleted = isDeleted;
            DoctorId = doctorId;
            UserId = patientId;
            this.isCancelled = isCancelled;
            this.canCancel = canCancel;
        }

        public Appointment(int id, DateTime start, int duration, string description, int patientId, int doctorId, AppointmentStatus status, int survId)
        {
            IdA = id;
            StartTime = start;
            DurationInMinutes = duration;
            AppointmentDescription = description;
            DoctorId = doctorId;
            UserId = patientId;
            Status = status;
            SurveyId = survId;
        }

        public bool CheckBeforeDate(DateTime startDate, DateTime minDate)
        {
            if (startDate >= minDate || startDate == DateTime.Now.Date)
                return true;
            return false;
        }


        public bool CheckAfterDate(DateTime afterDate, DateTime maxDate)
        {
            if (afterDate <= maxDate)
                return true;
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public List<Appointment> StatusAppointment(List<Appointment> appointments)
        {
            foreach (Appointment a in appointments)
            {
                if (a.isCancelled)
                    a.Status = AppointmentStatus.CANCELLED;
                else if (a.StartTime < DateTime.Now)
                    a.Status = AppointmentStatus.DONE;
                else if (a.StartTime > DateTime.Now)
                    a.Status = AppointmentStatus.UPCOMING;

                if (a.StartTime.Day < DateTime.Now.Day + 3)
                    a.canCancel = false;
            }
            return appointments;
        }

        public DateTime EndTime
        {
            get
            {
                return StartTime;
            }
        }

        public DateTime BeginTime
        {
            get
            {
                return StartTime;
            }
        }

        public String UserName
        {
            get
            {
                if (User != null)
                    return (User.Name + " " + User.Surname);
                else
                    return "";
            }
        }
        /*public String DoctorName
        {
            get
            {
                if (Doctor != null)
                    return (Doctor.Name + " " + Doctor.Surname);
                else
                    return "";
            }
            set
            {
                OnPropertyChanged("DoctorName");
            }
        }*/


        public bool IsOccupied(DateTime start)
        {
            return DateTime.Compare(StartTime, start) == 0;
        }
    }
}