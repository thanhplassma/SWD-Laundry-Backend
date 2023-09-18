﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Application.Common.Interfaces;

namespace SWD_Laundry_Backend.Application.Building.Queries;
public class GetBuildingQuery : IRequest<BuildingViewModel>
{
    public int Id { init; get; }
}

public class GetBuildingQueryHandler : IRequestHandler<GetBuildingQuery, BuildingViewModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetBuildingQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BuildingViewModel> Handle(GetBuildingQuery request, CancellationToken cancellationToken)
    {
        var building = await _context.Get<Domain.Entities.Building>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        return _mapper.Map<BuildingViewModel>(building);
    }
}