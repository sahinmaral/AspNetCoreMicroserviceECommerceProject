﻿using MultiShop.Cargo.Dto.Abstract;

namespace MultiShop.Cargo.Dto.Concrete
{
    public class UpdateCargoCompanyDto : BaseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
