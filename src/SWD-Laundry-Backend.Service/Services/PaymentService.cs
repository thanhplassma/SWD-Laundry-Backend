﻿using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Infrastructure;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.Models.Common;
using SWD_Laundry_Backend.Core.QueryObject;
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Service.Services;

[ScopedDependency(ServiceType = typeof(IPaymentService))]
public class PaymentService(IPaymentRepository repository, IMapper mapper, ICacheLayer<Payment> cacheLayer) : IPaymentService
{
    public async Task<string> CreateAsync(PaymentModel model, CancellationToken cancellationToken = default)
    {
        var query = await repository.AddAsync(mapper.Map<Payment>(model), cancellationToken);
        var objectId = query.Id;
        return objectId;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        int i = await repository.DeleteAsync(x => x.Id == id,
            cancellationToken);
        return i;
    }

    public async Task<ICollection<Payment>> GetAllAsync(PaymentQuery? query, CancellationToken cancellationToken = default)
    {
        var list = await repository.GetAsync(cancellationToken: cancellationToken);
        return await list.ToListAsync(cancellationToken);
    }

    public async Task<Payment?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetSingleAsync(c => c.Id == id, cancellationToken);
        return entity;
    }

    public async Task<PaginatedList<Payment>> GetPaginatedAsync(PaymentQuery query, CancellationToken cancellationToken = default)
    {
        var list = await repository
        .GetAsync(c => c.IsDelete == query.IsDeleted
            , cancellationToken: cancellationToken, c => c.Orders);


        var result = await list.PaginatedListAsync(query);
        return result;
    }

    public async Task<int> UpdateAsync(string id, PaymentModel model, CancellationToken cancellationToken = default)
    {
        {
            var numberOfRows = await repository.UpdateAsync(x => x.Id == id,
                x => x
                .SetProperty(x => x.Price, model.Price)
                , cancellationToken);

            return numberOfRows;
        }
    }
}