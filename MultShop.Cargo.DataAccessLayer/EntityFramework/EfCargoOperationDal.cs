using MultShop.Cargo.DataAccessLayer.Abstract;
using MultShop.Cargo.DataAccessLayer.Concrete;
using MultShop.Cargo.DataAccessLayer.Repositories;
using MultShop.Cargo.EntityLayer.Concrete;

namespace MultShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
    {
        public EfCargoOperationDal(CargoContext context) : base(context)
        {
        }
    }
}
