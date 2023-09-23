using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innRoadAssignment_Dynamic.ViewModel
{
    public class SearchRooms
    {
        public DateTime CheckIn { get; set; }
        public DateTime Checkout { get; set; }
        public int Adults { get; set; }
    }
}