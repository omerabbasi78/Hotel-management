using innRoadAssignment_Dynamic.Models;
using innRoadAssignment_Dynamic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace innRoadAssignment_Dynamic.Controllers
{
    public class HomeController : Controller
    {
        private innRoad_AssignmentEntities DbContext;
        public HomeController()
        {
            DbContext = new innRoad_AssignmentEntities();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Index(SearchRooms objSearchRooms)
        {
            Session["CheckIn"] = objSearchRooms.CheckIn;
            Session["CheckOut"] = objSearchRooms.Checkout;
            Session["Adults"] = objSearchRooms.Adults;
            return View();
        }
    }
}