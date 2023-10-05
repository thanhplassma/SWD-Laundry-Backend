﻿using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Contract.Service.Interface;

public interface ICustomerService :
    ICreateAble<CustomerModel, string>,
    IGetAble<Customer, string>,
    IUpdateAble<CustomerModel, string>,
    IDeleteAble<string>
{
}