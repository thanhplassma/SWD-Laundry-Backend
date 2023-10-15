﻿using Microsoft.AspNetCore.Mvc;

namespace SWD_Laundry_Backend.Core.QueryObject;
public record OrderHistoryQuery : BaseQuery
{
    [FromQuery(Name = "order-id")]
    public string? OrderId { get; set; }
    [FromQuery(Name = "customer-id")]
    public string? CustomerId { get; init; }
    [FromQuery(Name = "laundry-store-id")]
    public string? LaundryStoreId { get; init; }
}