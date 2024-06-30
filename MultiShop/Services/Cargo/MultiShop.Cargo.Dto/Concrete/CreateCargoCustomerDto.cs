﻿using MultiShop.Cargo.Dto.Abstract;

namespace MultiShop.Cargo.Dto.Concrete
{
    public class CreateCargoCustomerDto : BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
