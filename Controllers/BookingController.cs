using innRoadAssignment_Dynamic.Models;
using innRoadAssignment_Dynamic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace innRoadAssignment_Dynamic.Controllers
{
    public class BookingController : Controller
    {
        private innRoad_AssignmentEntities dbContext;
        public BookingController()
        {
            dbContext = new innRoad_AssignmentEntities();
        }
        // GET: Booking
        public ActionResult Index()
        {
            BookingViewModel objBookingViewModel = new BookingViewModel();
            objBookingViewModel.ListOfRooms = (from objRooms in dbContext.Rooms
                                               where objRooms.BookingStatusId == 2 && objRooms.IsActive
                                               select new SelectListItem()
                                               {
                                                   Text = objRooms.RoomNumber,
                                                   Value = objRooms.RoomId.ToString()
                                               }).ToList();
            return View(objBookingViewModel);
        }
        [HttpPost]
        public ActionResult Index(BookingViewModel objBookingViewModel)
        {
            RoomBooking objRoomBooking = new RoomBooking();

            if (objBookingViewModel.BookingId != 0)
            {
                objRoomBooking = dbContext.RoomBookings.Where(model => model.BookingId == objBookingViewModel.BookingId).FirstOrDefault();
            }
            objRoomBooking.CustomerName = objBookingViewModel.CustomerName;
            objRoomBooking.CustomerPhone = objBookingViewModel.CustomerPhone;
            objRoomBooking.CustomerAddress = objBookingViewModel.CustomerAddress;
            objRoomBooking.BookingFrom = objBookingViewModel.BookingFrom;
            objRoomBooking.BookingTo = objBookingViewModel.BookingTo;
            objRoomBooking.AssignedRoomId = objBookingViewModel.AssignedRoomId;
            objRoomBooking.TotalMembers = objBookingViewModel.TotalMember;
            if (objBookingViewModel.BookingId == 0)
            {
                dbContext.RoomBookings.Add(objRoomBooking);
            }
            dbContext.SaveChanges();
            return Json(new { message = "Successful.", success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}