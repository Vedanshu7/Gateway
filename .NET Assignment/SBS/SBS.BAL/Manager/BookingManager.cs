using AutoMapper;
using SBS.BAL.Interface;
using SBS.DAL.Database;
using SBS.DAL.Interface;
using SBS.MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL.Manager
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _BookingRepository;
        public IMapper mapper;
        public MapperConfiguration config;

        public BookingManager(IBookingRepository bookingRepository)
        {
            _BookingRepository = bookingRepository;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MDL.Models.BookAppointment, DAL.Database.Appointment>();
                cfg.CreateMap<DAL.Database.Appointment, MDL.Models.BookAppointment>();
            });
            mapper = config.CreateMapper();
        }
        public bool Booking(MDL.Models.BookAppointment appointment)
        {
            Appointment appointmentfordb = mapper.Map<MDL.Models.BookAppointment, Appointment>(appointment);
            return _BookingRepository.Booking(appointmentfordb);
        }

        public bool DeleteBooking(int id, int customerId)
        {
            return _BookingRepository.DeleteBooking(id, customerId);
        }

        public BookAppointment GetBooking(int id, int customerId)
        {
            Appointment appointmentfromdb = _BookingRepository.GetBooking(id, customerId);
            BookAppointment appointment = mapper.Map<DAL.Database.Appointment, MDL.Models.BookAppointment>(appointmentfromdb);
            appointment.DealerName = appointmentfromdb.Dealers.FirstName;
            appointment.MechanicName = appointmentfromdb.Mechanics.FirstName;
            appointment.ServiceType = appointmentfromdb.Services.Name;
            appointment.VehicleModel = appointmentfromdb.Vehicles.Model;
            return appointment;
        }

        public List<BookAppointment> GetBookingOfDealer(int dealerId)
        {
            List<Appointment> appointmentsfromdb = _BookingRepository.GetBookingOfDealer(dealerId);
            List<BookAppointment> appointments = mapper.Map<List<DAL.Database.Appointment>, List<MDL.Models.BookAppointment>>(appointmentsfromdb);
            for (var i = 0; i < appointments.Count; i++)
            {
                appointments[i].DealerName = appointmentsfromdb[i].Dealers.FirstName;
                appointments[i].MechanicName = appointmentsfromdb[i].Mechanics.FirstName;
                appointments[i].ServiceType = appointmentsfromdb[i].Services.Name;
                appointments[i].VehicleModel = appointmentsfromdb[i].Vehicles.Model;
            }
            return appointments;
        }

        public List<BookAppointment> GetBookings(int customerId)
        {
            List<Appointment> appointments = _BookingRepository.GetBookings(customerId);
            List<BookAppointment> bookAppointments = mapper.Map<List<DAL.Database.Appointment>, List<MDL.Models.BookAppointment>>(appointments);
            for(var i = 0; i < bookAppointments.Count; i++)
            {
                bookAppointments[i].DealerName = appointments[i].Dealers.FirstName;
                bookAppointments[i].MechanicName = appointments[i].Mechanics.FirstName;
                bookAppointments[i].ServiceType = appointments[i].Services.Name;
                bookAppointments[i].VehicleModel = appointments[i].Vehicles.Model;
            }
            return bookAppointments;
        }

        public bool UpdateBooking(BookAppointment appointment)
        {
            Appointment appointmentfordb = mapper.Map<MDL.Models.BookAppointment, Appointment>(appointment);
            return _BookingRepository.UpdateBooking(appointmentfordb);
        }
    }
}
