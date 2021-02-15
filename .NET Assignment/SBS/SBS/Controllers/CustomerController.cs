using SBS.Attributes;
using SBS.BAL.Interface;
using SBS.MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBS.Controllers
{
    [Authenticate]
    public class CustomerController : Controller
    {
        private readonly IVehicleManager _vehicleManager;
        private readonly IServiceManager _ServiceManager;
        private readonly IDealerManager _DealerManager;
        private readonly IBookingManager _BookingManager;

        public CustomerController(IVehicleManager vehicleManager, IServiceManager serviceManager, IDealerManager dealerManager, IBookingManager bookingManager)
        {
            _vehicleManager = vehicleManager;
            _ServiceManager = serviceManager;
            _DealerManager = dealerManager;
            _BookingManager = bookingManager;
        }
        // GET: Customer
        [HttpGet]
        public ActionResult Index()
        {
            var customerid = (int)Session["loginId"];
            List<VehicleViewModel> vehicles = _vehicleManager.GetVehicles(customerid);
            return View(vehicles);
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddVehicle(VehicleViewModel vehicle)
        {
            var customerid = (int)Session["loginId"];
            var result = _vehicleManager.AddVehicle(vehicle, customerid);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult BookAppointment()
        {
            BookAppointmentViewModel appointmentViewModel = new BookAppointmentViewModel();
            appointmentViewModel.VehicleId = _vehicleManager.GetVehiclesForDropDown((int)Session["loginId"]);
            appointmentViewModel.DealerId = _DealerManager.GetDealersForDropDown();
            appointmentViewModel.ServiceId = _ServiceManager.GetServicesForDropDown();
            return View(appointmentViewModel);
        }

        [HttpPost]
        public ActionResult BookAppointment(BookAppointment appointment)
        {
            appointment.CustomerId = (int)Session["loginId"];
            var result = _BookingManager.Booking(appointment);
            if (result)
            {
                return RedirectToAction("BookingList");
            }
            return View();
        }

        [HttpGet]
        public ActionResult BookingList()
        {
            var customerid = (int)Session["loginId"];
            List<BookAppointment> appointments = _BookingManager.GetBookings(customerid);
            return View(appointments);
        }

        [HttpGet]
        public ActionResult EditBooking(int id)
        {
            var customerid = (int)Session["loginId"];
            var booking = _BookingManager.GetBooking(id, customerid);
            BookAppointmentViewModel appointmentViewModel = new BookAppointmentViewModel();
            appointmentViewModel.VehicleId = _vehicleManager.GetVehiclesForDropDown((int)Session["loginId"]);
            appointmentViewModel.DealerId = _DealerManager.GetDealersForDropDown();
            appointmentViewModel.ServiceId = _ServiceManager.GetServicesForDropDown();
            appointmentViewModel.BookingDateTime = booking.BookingDateTime;
            return View(appointmentViewModel);
        }

        [HttpPost]
        public ActionResult EditBooking(BookAppointment appointment)
        {
            appointment.CustomerId = (int)Session["loginId"];
            var result = _BookingManager.UpdateBooking(appointment);
            if (result)
            {
                return RedirectToAction("BookingList");
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteBooking(int id)
        {
            var customerid = (int)Session["loginId"];
            var result = _BookingManager.DeleteBooking(id, customerid);
            return RedirectToAction("BookingList");
        }

        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            var customerid = (int)Session["loginId"];
            VehicleViewModel vehicle = _vehicleManager.GetVehicle(id, customerid);
            return View(vehicle);
        }

        [HttpPost]
        public ActionResult EditVehicle(VehicleViewModel vehicle)
        {
            var result = _vehicleManager.UpdateVehicle(vehicle);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteVehicle(int id)
        {
            var customerid = (int)Session["loginId"];
            var result = _vehicleManager.DeleteVehicle(id,customerid);
            return RedirectToAction("Index");
        }
    }
}