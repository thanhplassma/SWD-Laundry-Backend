﻿using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Contract.Service.Interface;

public interface ITimeScheduleService : ICreateAble<TimeScheduleModel, string>, IGetAble<TimeSchedule, string>, IUpdateAble<TimeScheduleModel, string>, IDeleteAble<string>
{
}