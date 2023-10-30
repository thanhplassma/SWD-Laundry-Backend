﻿using Microsoft.AspNetCore.Mvc;

namespace SWD_Laundry_Backend.Core.QueryObject;
public record LaundryStoreQuery : BaseQuery
{
    [BindProperty(Name = "user-id", SupportsGet = true)]
    public string? UserId { get; init; }
}
