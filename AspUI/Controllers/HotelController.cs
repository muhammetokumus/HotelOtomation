using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HotelController : Controller
    {
        private readonly ILogger<HotelController> _logger;
        IHotelService _hotelService;
        public HotelController(ILogger<HotelController> logger, IHotelService hotelService)
        {
            _logger = logger;
            _hotelService = hotelService;
        }
        public IActionResult Index()
        {
            return View(_hotelService.GetAll());
        }

        public IActionResult Update(int id)
        {
            var hotel = _hotelService.Get(id);
            return View(hotel);
        }

        [HttpPost]
        public IActionResult Update(Hotel hotel)
        {
            var updatedHotel = _hotelService.Get(hotel.Id);
            if (updatedHotel != null)
            {
                updatedHotel.IsFull = hotel.IsFull;
                updatedHotel.Name = hotel.Name;
                updatedHotel.Name = hotel.Name;
                updatedHotel.Description = hotel.Description;
                updatedHotel.DailyPrice = hotel.DailyPrice;
                _hotelService.Update(updatedHotel);
                return RedirectToAction("Index", "Home");
            }
            return View(hotel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                if (hotel != null)
                {
                    _hotelService.Add(hotel);
                    return RedirectToAction("Index");
                }
            }
            return View(hotel);
        }

        public IActionResult Delete(int id)
        {
            var hotel = _hotelService.Get(id);
            _hotelService.Delete(hotel);
            return RedirectToAction("index");
        }
    }
}
