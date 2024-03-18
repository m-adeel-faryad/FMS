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

namespace FMS.Application.Handlers.Commands;

public sealed class AddAccountCommandHandler(IMapper mapper, IRepository<Account> repository) : IRequestHandler<AddAccount, string>
{
    public async Task<string> Handle(AddAccount request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<AddAccount, Account>(request);
        await repository.Insert(mapped, cancellationToken);
        throw new Exception("Just for test");
        return "Success";
    }
}