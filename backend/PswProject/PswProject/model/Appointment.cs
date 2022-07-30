using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PswProject.model
{
    public class Appointment : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdA { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationInMinutes { get; private set; }
        public String AppointmentDescription { get; private set; }
        public int UserId { get; private set; }
        public virtual User User { get; private set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public AppointmentStatus Status { get; set; }
        public int SurveyId { get; set; }
        public Boolean isCancelled { get; private set; }
        public Boolean canCancel { get; private set; }
        public Boolean IsDeleted { get; private set; }

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