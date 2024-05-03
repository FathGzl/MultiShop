using MultShop.Cargo.BusinessLayer.Abstract;
using MultShop.Cargo.DataAccessLayer.Abstract;
using MultShop.Cargo.EntityLayer.Concrete;

namespace MultShop.Cargo.BusinessLayer.Concrete
{
    internal class CargoCustumerManager : ICargoCustumerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;

        public CargoCustumerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }

        public void TDelete(int id)
        {
            _cargoCustomerDal.Delete(id);
        }

        public List<CargoCustomer> TGetAll()
        {
            return _cargoCustomerDal.GetAll();
        }

        public CargoCustomer TGetById(int id)
        {
            return _cargoCustomerDal.GetById(id);
        }

        public void TInsert(CargoCustomer entity)
        {
            _cargoCustomerDal.Insert(entity);
        }

        public void TUpdate(CargoCustomer entity)
        {
            _cargoCustomerDal.Update(entity);
        }
    }
}