using FMS.Application.Dto;
using FMS.Application.Interfaces;
using FMS.Domain.Models;
using MediatR;

namespace FMS.Application.Handlers.Quries.AccountQuries;

public sealed class GetAllQueryHandler(IRepository<Account> repository)
    : IRequestHandler<GetAllRequest, List<GetById>>
{
    public Task<List<GetById>> Handle(GetAllRequest request, CancellationToken cancellationToken)
    {
        var result = repository.GetAll();


        var mapped = result.Select(x => new GetById
        {
            Id = x.Id,
            AccountNumber = x.AccountNumber,
            CreateDateTime = x.CreatedDateTime,
            AccountName = x.AccountName,
            AccountType = x.AccountType,
            IsDeleted = x.IsDeleted,
            Balance = x.Balance
        }).ToList();
        return Task.FromResult(mapped);
    }
}