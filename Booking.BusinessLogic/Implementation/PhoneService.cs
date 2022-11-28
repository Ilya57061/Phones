using Booking.Model.Database;
using Booking.Model.Models;


namespace Booking.BusinessLogic.Implementation
{
    public class PhoneService
    {
        ApplicationContext _db;

        public PhoneService()
        {
            _db = new ApplicationContext();
        }
  
        public void Create(Phone model)
        {
            _db.Phones.Add(model);
            _db.SaveChanges();
        }
        public IEnumerable<Phone> Get()
        {
            return _db.Phones.ToList();        
        }
        public void Delete(Phone model)
        {
            _db.Phones.Remove(model);
            _db.SaveChanges();
        }
        public void Update(Phone model)
        {
            _db.Phones.Update(model);
            _db.SaveChanges();
        }
    }
}
