using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace innRoadAssignment_Dynamic.ViewModel
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        [Display(Name ="Customer Name")]
        [Required(ErrorMessage ="Customer Name is required.")]
        public string CustomerName { get; set; }
        [Display(Name = "Customer Address")]
        [Required(ErrorMessage = "Customer Address is required.")]
        public string CustomerAddress { get; set; }
        [Display(Name = "Customer Phone")]
        [Required(ErrorMessage = "Customer Phone is required.")]
        public string CustomerPhone { get; set; }
        [Display(Name = "Booking From")]
        [Required(ErrorMessage = "Booking From is required.")]
        //[DataType(DataType.Date)]
        public DateTime BookingFrom { get; set; }
        [Display(Name = "Booking To")]
        [Required(ErrorMessage = "Booking To is required.")]
        //[DataType(DataType.Date)]
        public DateTime BookingTo { get; set; }
        [Display(Name = "Assigned Room")]
        [Required(ErrorMessage = "Assigned Room is required.")]
        public int AssignedRoomId { get; set; }
        [Display(Name = "Total Members")]
        [Required(ErrorMessage = "Total Members is required.")]
        public int TotalMember { get; set; }

        public IEnumerable<SelectListItem> ListOfRooms { get; set; }
    }
}