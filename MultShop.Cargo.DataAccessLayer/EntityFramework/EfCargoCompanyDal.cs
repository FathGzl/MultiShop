using MultShop.Cargo.DataAccessLayer.Abstract;
using MultShop.Cargo.DataAccessLayer.Concrete;
using MultShop.Cargo.DataAccessLayer.Repositories;
using MultShop.Cargo.EntityLayer.Concrete;

namespace MultShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
    {
        public EfCargoCompanyDal(CargoContext context) : base(context)
        {
        }
    }
}
