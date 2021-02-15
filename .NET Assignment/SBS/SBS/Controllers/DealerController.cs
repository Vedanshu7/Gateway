using SBS.BAL.Interface;
using SBS.MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBS.Controllers
{
    public class DealerController : Controller
    {
        private readonly IVehicleManager _vehicleManager;
        private readonly IServiceManager _ServiceManager;
        private readonly IDealerManager _DealerManager;
        private readonly IBookingManager _BookingManager;
        private readonly IMechanicManager _MechanicManager;
        private readonly ICustomerManager _CustomerManager;

        public DealerController(IVehicleManager vehicleManager, IServiceManager serviceManager, IDealerManager dealerManager, IBookingManager bookingManager, IMechanicManager mechanicManager, ICustomerManager customerManager)
        {
            _vehicleManager = vehicleManager;
            _ServiceManager = serviceManager;
            _DealerManager = dealerManager;
            _BookingManager = bookingManager;
            _MechanicManager =mechanicManager;
            _CustomerManager = customerManager;
        }
        // GET: Dealer
        public ActionResult Index()
        {
            MainPageViewModel main = new MainPageViewModel();
            main.dealers= _DealerManager.GetDealers();
            main.customers = _CustomerManager.GetCustomers();
            main.services = _ServiceManager.GetServices();
            return View(main);
        }

        [HttpGet]
        public ActionResult GetDetailsOfDealer(int dealerId)
        {
            DealerInformationViewModel model = new DealerInformationViewModel();
            model.dealer = _DealerManager.GetDealer(dealerId);
            model.appointments = _BookingManager.GetBookingOfDealer(dealerId);
            model.mechanics = _MechanicManager.GetMechanics(dealerId);
            return View(model);
        }

        [HttpGet]
        public ActionResult GetDetailsOfCustomer(int id)
        {
            CustomerInformationViewModel model = new CustomerInformationViewModel();
            model.customer = _CustomerManager.GetCustomer(id);
            model.vehicles = _vehicleManager.GetVehicles(id);
            model.appointments = _BookingManager.GetBookings(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteVehicle(int id,int customerId)
        {
            var result = _vehicleManager.DeleteVehicle(id,customerId);
            return RedirectToAction("GetDetailsOfCustomer",new {id=customerId });
        }

        [HttpGet]
        public ActionResult DeleteBooking(int id, int customerId)
        {
            var result = _BookingManager.DeleteBooking(id, customerId);
            return RedirectToAction("GetDetailsOfCustomer", new { id = customerId });
        }

        [HttpGet]
        public ActionResult DeleteDealer(int id)
        {
            var result = _DealerManager.DeleteDealer(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteMechanic(int id)
        {
            var result = _MechanicManager.DeleteMechanic(id);
            return RedirectToAction("GetDetailsOfDealer", new { dealerId = id });
        }

        [HttpGet]
        public ActionResult DeleteCustomer(int id)
        {
            var result = _CustomerManager.DeleteCustomer(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteService(int id)
        {
            var result = _ServiceManager.DeleteService(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditDealer(int id)
        {
            DealerViewModel dealer  = _DealerManager.GetDealer(id);
            return View(dealer);
        }
        [HttpPost]
        public ActionResult EditDealer(DealerViewModel dealer)
        {
           var result=_DealerManager.EditDealer(dealer);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            RegisterViewModel customer = _CustomerManager.GetCustomer(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult EditCustomer(RegisterViewModel register)
        {
            var result = _CustomerManager.EditCustomer(register);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditService(int id)
        {
            ServiceViewModel service = _ServiceManager.GetService(id);
            return View(service);
        }
        [HttpPost]
        public ActionResult EditService(ServiceViewModel service)
        {
            var result = _ServiceManager.EditService(service);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditBooking(int id,int customerId)
        {
            BookAppointment booking = _BookingManager.GetBooking(id,customerId);
            return View(booking);
        }

        [HttpPost]
        public ActionResult EditBooking(BookAppointment book)
        {
            var result = _BookingManager.UpdateBooking(book);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditMechanic(int id)
        {
            MechanicViewModel mechanic = _MechanicManager.GetMechanic(id);
            return View(mechanic);
        }
        [HttpPost]
        public ActionResult EditMechanic(MechanicViewModel mechanic)
        {
            var result = _MechanicManager.EditMechanic(mechanic);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditVehicle(int id,int customerId)
        {
            VehicleViewModel vehicle = _vehicleManager.GetVehicle(id,customerId);
            return View(vehicle);
        }
        [HttpPost]
        public ActionResult EditVehicle(VehicleViewModel vehicle)
        {
            var result = _vehicleManager.UpdateVehicle(vehicle);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateDealer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult  CreateDealer(DealerViewModel dealer)
        {
            var result = _DealerManager.CreateDealer(dealer);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult  CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult  CreateCustomer(RegisterViewModel register)
        {
            var result = _CustomerManager.CreateCustomer(register);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult  CreateService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult  CreateService(ServiceViewModel service)
        {
            var result = _ServiceManager.CreateService(service);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult  CreateBooking()
        {
            return View();
        }

        [HttpPost]
        public ActionResult  CreateBooking(BookAppointment book)
        {
            var result = _BookingManager.Booking(book);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult  CreateMechanic()
        {
            return View();
        }
        [HttpPost]
        public ActionResult  CreateMechanic(MechanicViewModel mechanic)
        {
            var result = _MechanicManager.CreateMechanic(mechanic);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult  CreateVehicle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult  CreateVehicle(VehicleViewModel vehicle)
        {
            var result = _vehicleManager.AddVehicle(vehicle,vehicle.CustomerId);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}