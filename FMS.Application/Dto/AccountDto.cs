using FMS.Domain.Models;
using MediatR;

namespace FMS.Application.Dto;

public class AddAccount : IRequest<string>
{
    public string AccountName { get; set; } = default!;
    public double Balance { get; set; }
    public string AccountNumber { get; set; } = default!;
    public AccountTypes AccountType { get; set; }
}
public class UpdateAccount : IRequest<string>
{
    public int Id { get; set; }
    public string AccountName { get; set; } = default!;
    public double Balance { get; set; }
    public string AccountNumber { get; set; } = default!;
    public AccountTypes AccountType { get; set; }
}

public class GetAllRequest : IRequest<List<GetById>>;
public class GetById 
{
    public int Id { get; set; }
    public string AccountName { get; set; } = default!;
    public string AccountNumber { get; set; } = default!;
    public bool IsDeleted { get; set; }
    public double Balance { get; set; }
    public DateTime CreateDateTime { get; set; }
    public AccountTypes AccountType { get; set; }
}
public record GetByIdRequest(int Id) : IRequest<GetById>;
public record DeleteAccountRequest(int Id) : IRequest<string>;