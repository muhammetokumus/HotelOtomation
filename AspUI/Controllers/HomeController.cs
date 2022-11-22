using Business.Abstract;
using Business.Filters;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AspUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IHotelService _hotelService;
        HotelContext _hotelContext;
        public HomeController(ILogger<HomeController> logger, IHotelService hotelService, HotelContext hotelContext)
        {
            _logger = logger;
            _hotelService = hotelService;
            _hotelContext = hotelContext;
        }

        public IActionResult Index()
        {
            return View(_hotelService.GetAll());
        }

       

        public IActionResult Details(int id)
        {
            var hotel = _hotelService.Get(id);
            if (id == null || _hotelService.GetAll() == null)
            {
                return NotFound();
            }
            return View(hotel);
        }
        public IActionResult Hotels(string minPrice = null, string maxPrice = null, string isIstanbul = null,string isEskisehir = null,string isIzmir = null)
        {
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            ViewBag.IsIstanbul = isIstanbul == "on" ? true : false;
            ViewBag.IsEskisehir = isEskisehir == "on" ? true : false;
            ViewBag.IsIzmir = isIzmir == "on" ? true : false;
            return View(FiltersHotel.GetHotels(minPrice, maxPrice,isIstanbul,isEskisehir,isIzmir,_hotelContext));
        }

        [HttpPost]
        public IActionResult Hotels(string city = null)
        {
            IQueryable<Hotel> query = _hotelContext.Hotels;
            if (city != null)
            {
                query = query.Where(x => x.City == city);
            }
            return View(query.ToList());
        }

    }
}
