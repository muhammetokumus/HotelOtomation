using Business.Abstract;
using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HotelManager : IHotelService
    {
        IHotelDal _hotelDal;
        public HotelManager(IHotelDal hotelDal)
        {
            _hotelDal = hotelDal;
        }
        public void Add(Hotel hotel)
        {
            _hotelDal.Add(hotel);
        }

        public void Delete(Hotel hotel)
        {
            _hotelDal.Delete(hotel);
        }

        public Hotel Get(int id)
        {
            return _hotelDal.Get(h => h.Id == id);
        }

        public List<Hotel> GetAll()
        {
            return _hotelDal.GetAll();
        }
        public void Update(Hotel hotel)
        {
            _hotelDal.Update(hotel);
        }
    }
}
