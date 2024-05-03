using MultShop.Cargo.DataAccessLayer.Abstract;
using MultShop.Cargo.DataAccessLayer.Concrete;
using MultShop.Cargo.DataAccessLayer.Repositories;
using MultShop.Cargo.EntityLayer.Concrete;

namespace MultShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        public EfCargoCustomerDal(CargoContext context) : base(context)
        {
        }
    }
}
