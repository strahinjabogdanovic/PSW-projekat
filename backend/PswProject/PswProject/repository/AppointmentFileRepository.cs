﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PswProject.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.repository
{
    public class AppointmentFileRepository : AppointmentRepository
    {

        public String FileName { get; set; }

        public AppointmentFileRepository()
        {
            this.FileName = "../../appointments.json";
        }

        private void WriteToFile(List<Appointment> appointments)
        {
            try
            {
                var appointmentsForSerialization = PrepareForSerialization(appointments);
                var jsonToFile = JsonConvert.SerializeObject(appointmentsForSerialization, Formatting.Indented);

                using (StreamWriter writer = new StreamWriter(this.FileName))
                {
                    writer.Write(jsonToFile);
                }
            }
            catch
            {
            }
        }


        private List<JObject> PrepareForSerialization(List<Appointment> appointments)
        {
            var appointmentsForSerialization = new List<JObject>();
            foreach (var appointment in appointments)
            {
                JObject appointmentForSerialization = JObject.FromObject(appointment);

                appointmentForSerialization.Add("patientId", appointment.User.Jmbg);
                //appointmentForSerialization.Add("roomId", appointment.Room.RoomNumber);
                appointmentForSerialization.Add("doctorId", appointment.Doctor.IdD);

                appointmentsForSerialization.Add(appointmentForSerialization);
            }

            return appointmentsForSerialization;
        }
        public Appointment GetByAppointmentId(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> Get(int doctorId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Create(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public bool Update(Appointment editedObject)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Appointment GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Appointment newObject)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
