using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AspUI.Controllers
{
    public class AdminController : Controller
    {
        IHotelService _hotelService;

        public AdminController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public IActionResult Index()
        {
            return View(_hotelService.GetAll());
        }
    }
}
