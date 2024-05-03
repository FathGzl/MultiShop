using MultShop.Cargo.BusinessLayer.Abstract;
using MultShop.Cargo.DataAccessLayer.Abstract;
using MultShop.Cargo.EntityLayer.Concrete;

namespace MultShop.Cargo.BusinessLayer.Concrete
{
    internal class CargoOperationManager: ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }

        public void TDelete(int id)
        {
            _cargoOperationDal.Delete(id);
        }

        public List<CargoOperation> TGetAll()
        {
            return _cargoOperationDal.GetAll();
        }

        public CargoOperation TGetById(int id)
        {
            return _cargoOperationDal.GetById(id);
        }

        public void TInsert(CargoOperation entity)
        {
            _cargoOperationDal.Insert(entity);
        }

        public void TUpdate(CargoOperation entity)
        {
            _cargoOperationDal.Update(entity);
        }
    }
}