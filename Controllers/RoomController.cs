using innRoadAssignment_Dynamic.Models;
using innRoadAssignment_Dynamic.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace innRoadAssignment_Dynamic.Controllers
{
    public class RoomController : Controller
    {
        private innRoad_AssignmentEntities dbContext;
        public RoomController()
        {
            dbContext = new innRoad_AssignmentEntities();
        }
        // GET: Room
        public ActionResult Index()
        {
            RoomViewModel objRoomViewModel = new RoomViewModel();
            objRoomViewModel.ListOfBookingStatus = (from obj in dbContext.BookingStatus
                                                    select new SelectListItem()
                                                    {
                                                        Text = obj.BookingStatus,
                                                        Value = obj.BookingStatusId.ToString()
                                                    }).ToList();

            objRoomViewModel.ListOfRoomType = (from obj in dbContext.RoomTypes
                                               select new SelectListItem()
                                               {
                                                   Text = obj.RoomTypeName,
                                                   Value = obj.RoomTypeId.ToString()
                                               }).ToList();
            return View(objRoomViewModel);
        }
        [HttpPost]
        public ActionResult Index(RoomViewModel objRoomViewModel)
        {
            Room objRoom = new Room();

            if (objRoomViewModel.RoomId != 0)
            {
                objRoom = dbContext.Rooms.Where(model => model.RoomId == objRoomViewModel.RoomId).FirstOrDefault();
            }
            objRoom.RoomNumber = objRoomViewModel.RoomNumber;
            objRoom.RoomDescription = objRoomViewModel.RoomDescription;
            objRoom.RoomPrice = objRoomViewModel.RoomPrice;
            objRoom.BookingStatusId = objRoomViewModel.BookingStatusId;
            objRoom.IsActive = true;
            objRoom.RoomCapacity = objRoomViewModel.RoomCapacity;
            objRoom.RoomTypeId = objRoomViewModel.RoomTypeId;
            objRoom.RoomImage = "https://d1icd6shlvmxi6.cloudfront.net/gsc/EVZFXG/da/6c/0a/da6c0a14193340cca4ea3d9226ae8115/images/details_and_payment/u31.svg?pageId=ba77651a-e44e-4744-a3cd-e76b10d0c22c";
            if (objRoomViewModel.RoomId == 0)
            {
                dbContext.Rooms.Add(objRoom); 
            }
            dbContext.SaveChanges();
            return Json(new { message = "Successful.", success = true }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetAllRooms()
        {
            IEnumerable<RoomDetailsViewModel> listRoomDetailsViewModel =
                (from objRoom in dbContext.Rooms
                 join objBooking in dbContext.BookingStatus on objRoom.BookingStatusId equals objBooking.BookingStatusId
                 join objRoomType in dbContext.RoomTypes on objRoom.RoomTypeId equals objRoomType.RoomTypeId
                 where objRoom.IsActive
                 select new RoomDetailsViewModel()
                 {
                     RoomNumber = objRoom.RoomNumber,
                     RoomDescription = objRoom.RoomDescription,
                     RoomCapacity = objRoom.RoomCapacity,
                     RoomPrice = objRoom.RoomPrice,
                     BookingStatus = objBooking.BookingStatus,
                     RoomType = objRoomType.RoomTypeName,
                     RoomImage = objRoom.RoomImage,
                     RoomId = objRoom.RoomId
                 }).ToList();
            return PartialView("_RoomDetails", listRoomDetailsViewModel);
        }

        public JsonResult EditRoom(int RoomId)
        {
            var result = dbContext.Rooms.Where(model => model.RoomId == RoomId).FirstOrDefault();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteRoom(int RoomId)
        {
            var result = dbContext.Rooms.Where(model => model.RoomId == RoomId).FirstOrDefault();
            result.IsActive = false;
            dbContext.SaveChanges();
            return Json(new { message = "Successful.", success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}