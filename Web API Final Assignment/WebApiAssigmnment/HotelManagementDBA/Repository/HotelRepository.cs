using HotelManagementDBA.Interface;
using HotelManagementModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDBA.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelManagementDBA.Database.HotelManagmentEntities _db;

        public HotelRepository()
        {
            _db = new Database.HotelManagmentEntities();
        }
        public int AddHotels(List<Hotel> hotels)
        {
            if (hotels != null)
            {
                for(int i = 0; i < hotels.Count; i++)
                {
                    Database.Hotel h = new Database.Hotel();
                    
                    
                    h.Name = hotels[i].Name;
                    h.Address = hotels[i].Address;
                    h.City = hotels[i].City;
                    h.Contact_Number = hotels[i].Contact_Number;
                    h.Contact_Person = hotels[i].Contact_Person;
                    h.Created_By = hotels[i].Created_By;
                    h.Created_Date = DateTime.UtcNow;
                    h.PinCode = hotels[i].PinCode;
                    h.IsActive = hotels[i].IsActive;
                    h.Website = hotels[i].Website;
                    h.Facebook = hotels[i].Facebook;
                    h.Twitter = hotels[i].Twitter;
                    h.Updated_By = null;
                    h.Updated_Date = null;

                    _db.Hotels.Add(h);
                }
                _db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<Hotel> GetAllHotels()
        {
            List<Database.Hotel> hotels = new List<Database.Hotel>();
            hotels= _db.Hotels.ToList();
            hotels = hotels.OrderBy(i => i.Name).ToList();
            if (hotels != null)
            {
                List<Hotel> hotel = new List<Hotel>();
                for (int i = 0; i < hotels.Count; i++)
                {
                    Hotel h = new Hotel();
                    h.Id = hotels[i].Id;
                    h.Name = hotels[i].Name;
                    h.Address = hotels[i].Address;
                    h.City = hotels[i].City;
                    h.Contact_Number = hotels[i].Contact_Number;
                    h.Contact_Person = hotels[i].Contact_Person;
                    h.Created_By = hotels[i].Created_By;
                    h.Created_Date = hotels[i].Created_Date;
                    h.PinCode = hotels[i].PinCode;
                    h.IsActive = hotels[i].IsActive;
                    h.Website = hotels[i].Website;
                    h.Facebook = hotels[i].Facebook;
                    h.Twitter = hotels[i].Twitter;
                    h.Updated_By = hotels[i].Updated_By;
                    h.Updated_Date = hotels[i].Updated_Date;
                    hotel.Add(h);
                }
                return hotel;
            }
            else
            {
                return null;
            }
            
        }

        public List<Dictionary<string, string>> Hotels(string param, string where)
        {
            var JoinTable= _db.Hotels.Join(_db.Rooms, h => h.Id, r => r.Hotel_Id, (h, r) => new{
                Name=h.Name,
                City=h.City,
                Pincode=h.PinCode,
                Price=r.Price,
                Category=r.Category
            }).ToList();
            if (JoinTable != null)
            {
                List<Dictionary<string,string>> result = new List<Dictionary<string,string>>();
                switch (param)
                {
                    case "city":
                        var city = JoinTable.Where(i => i.City == where).ToList();
                        for (int i = 0; i < city.Count; i++)
                        {
                            Dictionary<string,string> l = new Dictionary<string, string>();
                            l.Add("Name",city[i].Name);
                            l.Add("City",city[i].City);
                            l.Add("PinCode",city[i].Pincode);
                            l.Add("Price",Convert.ToString(Math.Round(city[i].Price,2)));
                            l.Add("Category",city[i].Category);

                            result.Add(l);
                        }
                        break;
                    case "pincode":
                        var pincode = JoinTable.Where(i => i.Pincode == where).ToList();
                        for (int i = 0; i < pincode.Count; i++)
                        {
                            Dictionary<string, string> l = new Dictionary<string, string>();
                            l.Add("Name",pincode[i].Name);
                            l.Add("City",pincode[i].City);
                            l.Add("PinCode",pincode[i].Pincode);
                            l.Add("Price",Convert.ToString(Math.Round(pincode[i].Price,2)));
                            l.Add("Category",pincode[i].Category);

                            result.Add(l);
                        }
                        break;
                    case "price":
                        decimal p = Convert.ToDecimal(where);
                        var price = JoinTable.Where(i => i.Price == p).ToList();
                        for (int i = 0; i < price.Count; i++)
                        {
                            Dictionary<string, string> l = new Dictionary<string, string>();
                            l.Add("Name",price[i].Name);
                            l.Add("City",price[i].City);
                            l.Add("PinCode",price[i].Pincode);
                            l.Add("Price",Convert.ToString(Math.Round(price[i].Price,2)));
                            l.Add("Category",price[i].Category);

                            result.Add(l);
                        }
                        break;
                    case "category":
                        var category = JoinTable.Where(i => i.Category == where).ToList();
                        for (int i = 0; i < category.Count; i++)
                        {
                            Dictionary<string, string> l = new Dictionary<string, string>();
                            l.Add("Name", category[i].Name);
                            l.Add("City", category[i].City);
                            l.Add("PinCode", category[i].Pincode);
                            l.Add("Price", Convert.ToString(Math.Round(category[i].Price,2)));
                            l.Add("Category", category[i].Category);

                            result.Add(l);
                        }
                        break;
                    default:
                        var defualt = JoinTable.OrderBy(i=>i.Price).ToList();
                        for (int i = 0; i < defualt.Count; i++)
                        {
                            Dictionary<string, string> l = new Dictionary<string, string>();
                            l.Add("Name", defualt[i].Name);
                            l.Add("City", defualt[i].City);
                            l.Add("PinCode", defualt[i].Pincode);
                            l.Add("Price", Convert.ToString(Math.Round(defualt[i].Price,2)));
                            l.Add("Category", defualt[i].Category);

                            result.Add(l);
                        }
                        break;
                }
                return result;
            }
            else
            {
               return null;
            }
            
        }
    }
}
