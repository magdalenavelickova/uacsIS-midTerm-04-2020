using System;
using System.Collections.Generic;
using System.Text;
using UniversityApplication.Data.DTOs;

namespace UniversityApplication.Service.Service
{
    public interface IAddressService
    {
        IEnumerable<AddressDTO> GetAddresses();

        AddressDTO GetAddress(int addressId);

        AddressDTO SaveAddress(AddressDTO address);

        bool DeleteAddress(int addressId);

        AddressDTO PutPoints(int id, AddressDTO addressObject);
    }

}
