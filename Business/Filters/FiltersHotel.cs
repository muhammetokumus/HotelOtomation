using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Filters
{
    public static class FiltersHotel
    {
        public static IQueryable<Hotel> GetHotels(string minPrice, string maxPrice, string isIstanbul, string isEskisehir, string isIzmir, HotelContext _hotelContext)
        {
            IQueryable<Hotel> query = _hotelContext.Hotels;

            if (minPrice != null)
            {
                query = query.Where(h => h.DailyPrice >= Convert.ToDecimal(minPrice));
            }
            if (maxPrice != null)
            {
                query = query.Where(h => h.DailyPrice <= Convert.ToDecimal(maxPrice));
            }
            if (isIstanbul == "on")
            {
                query = query.Where(h => h.City == "İstanbul");
            }
            if (isEskisehir == "on")
            {
                query = query.Where(h => h.City == "Eskişehir");
            }
            if (isIzmir == "on")
            {
                query = query.Where(h => h.City == "İzmir");
            }
            return query;
        }
    }
}
