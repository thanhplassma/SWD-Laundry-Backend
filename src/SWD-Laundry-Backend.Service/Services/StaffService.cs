﻿using System.Linq.Expressions;
using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.Models.Common;
using SWD_Laundry_Backend.Core.QueryObject;
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Service.Services;

[ScopedDependency(ServiceType = typeof(IStaffService))]
public class StaffService : IStaffService
{
    private readonly IStaffRepository _repository;
    private readonly IMapper _mapper;

    public StaffService(IStaffRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<string> CreateAsync(StaffModel model, CancellationToken cancellationToken = default)
    {
        var query = await _repository.AddAsync(_mapper.Map<Staff>(model), cancellationToken);
        var objectId = query.Id;
        return objectId;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.DeleteAsync(x => x.Id == id, cancellationToken: cancellationToken);
        return numberOfRows;
    }

    public async Task<ICollection<Staff>> GetAllAsync(StaffQuery? query, CancellationToken cancellationToken = default)
    {
        var list = await _repository
            .GetAsync(null,
            cancellationToken: cancellationToken,
            c => c.ApplicationUser);
        return await list.ToListAsync(cancellationToken);
    }

    public async Task<Staff?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {

        var entity = await _repository.GetSingleAsync(c => c.Id == id, cancellationToken);
        return entity;
    }

    public async Task<PaginatedList<Staff>> GetPaginatedAsync(StaffQuery query, CancellationToken cancellationToken = default)
    {
        var list = await _repository.GetAsync(null,
        cancellationToken: cancellationToken,
        c => c.ApplicationUser);
       
        var result = await list.PaginatedListAsync(query);
        return result;

    }

    public async Task<int> UpdateAsync(string id, StaffModel model, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.UpdateAsync(x => x.Id == id,
            x => x
            .SetProperty(x => x.ApplicationUserID, model.ApplicationUserId)
            , cancellationToken);

        return numberOfRows;
    }
}
