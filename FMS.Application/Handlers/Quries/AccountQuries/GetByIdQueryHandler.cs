using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FMS.Application.Dto;
using FMS.Application.Interfaces;
using FMS.Domain.Models;
using MediatR;

namespace FMS.Application.Handlers.Quries.AccountQuries;

public class GetByIdQueryHandler(IMapper mapper, IRepository<Account> repository) : IRequestHandler<GetByIdRequest, GetById>
{
    public async Task<GetById> Handle(GetByIdRequest request, CancellationToken cancellationToken)
    {
        var result = await repository.Get(request.Id);
        var mapped = mapper.Map<GetById>(result);
        return mapped;
    }
}