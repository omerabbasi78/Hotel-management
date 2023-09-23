﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace innRoadAssignment_Dynamic.ViewModel
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }
        [Display(Name = "Room Number")]
        [Required(ErrorMessage ="Room Number is required.")]
        public string RoomNumber { get; set; }
        [Display(Name = "Room Image")]
        public string RoomImage { get; set; }
        [Display(Name = "Room Price")]
        [Required(ErrorMessage = "Room Price is required.")]
        [Range(50, 1000, ErrorMessage = ("Room Price should be equal or greater than {1}"))]
        public decimal RoomPrice { get; set; }
        [Display(Name = "Booking Status")]
        [Required(ErrorMessage = "Booking Status is required.")]
        public int BookingStatusId { get; set; }
        [Display(Name = "Room Type")]
        [Required(ErrorMessage = "Room Type is required.")]
        public int RoomTypeId { get; set; }
        [Display(Name = "Room Capacity")]
        [Required(ErrorMessage = "Room Capacity is required.")]
        [Range(1, 8, ErrorMessage = ("Room Capacity should be equal or greater than {1}"))]
        public int RoomCapacity { get; set; }
        [Display(Name = "Room Description")]
        public string RoomDescription { get; set; }
        [Display(Name = "Booking Status")]
        public List<SelectListItem> ListOfBookingStatus { get; set; }
        [Display(Name = "Room Type")]
        public List<SelectListItem> ListOfRoomType { get; set; }
    }
}