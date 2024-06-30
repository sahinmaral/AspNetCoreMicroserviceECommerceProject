﻿using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccess.Context;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.DataAccess.Concrete.EntityFramework
{
    public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
    {
        public EfCargoDetailDal(CargoContext context) : base(context)
        {
        }
    }

}
