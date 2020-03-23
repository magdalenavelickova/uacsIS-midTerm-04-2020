using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityApplication.Data;
using UniversityApplication.Data.DTOs;
using UniversityApplication.Data.Models;

namespace UniversityApplication.Service.Service
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly UniversityDataContext _dataContext;

        public AddressService(UniversityDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public bool DeleteAddress(int addressId)
        {
            var address = _dataContext.Addresses.FirstOrDefault(x => x.Id == addressId);

            if (address == null)
            {
                return false;
            }

            _dataContext.Addresses.Remove(address);
            return _dataContext.SaveChanges() > 0;
        }

        public AddressDTO GetAddress(int addressId)
        {
            var address = _dataContext.Addresses.FirstOrDefault(x => x.Id == addressId);

            return _mapper.Map < AddressDTO > (address);
        }

        public IEnumerable<AddressDTO> GetAddresses()
        {
            var addresses = _dataContext.Addresses.ToList();
            return _mapper.Map<IEnumerable<AddressDTO>>(addresses);
        }

        public AddressDTO PutPoints(int id, AddressDTO addressObject)
        {
            var address = _dataContext.Addresses.FirstOrDefault(x => x.Id == id);
            if (address == null)
            {
                throw new Exception("Address not found");
            }

            addressObject.Id = address.Id;
            address = _mapper.Map<Address>(addressObject);
            _dataContext.SaveChanges();


            return _mapper.Map<AddressDTO>(address);
        }

        public AddressDTO SaveAddress(AddressDTO address)
        {
            Address newAddress = _mapper.Map<Address>(address);

            _dataContext.Addresses.Add(newAddress);
            _dataContext.SaveChanges();

            return _mapper.Map<AddressDTO>(newAddress);
        }
    }
}
