using FluentValidation;
using FMS.Application.Dto;
using FMS.WebApi.Validations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FMS.WebApi.Controllers;
[ApiController]
[Route("api/v1/[Controller]/[action]")]
public sealed class AccountController(IMediator mediator, IValidator<AddAccount> addValidator, IValidator<UpdateAccount> updateValidator) : ControllerBase
{
    [HttpPost]
    public async Task<IResult> Create(AddAccount form, CancellationToken token = default)
    {
        var validate =  await addValidator.ValidateAsync(form, token);
        if (!validate.IsValid)
        {
            return Results.BadRequest(validate.Errors);
        }
        return Results.Ok(await mediator.Send(form, token));
    }

    [HttpGet]
    public async Task<IResult> GetAll()
    {
       var result = await mediator.Send(new GetAllRequest(),CancellationToken.None);
       return Results.Ok(result);
    }
    [HttpGet("/{id}")]
    public async Task<IResult> Get(int id)
    {
        var result = await mediator.Send(new GetByIdRequest(id), CancellationToken.None);
        return Results.Ok(result);
    }
    [HttpPut]
    public async Task<IResult> Update(UpdateAccount form, CancellationToken token = default)
    {
        var validate = await updateValidator.ValidateAsync(form, token);
        if (!validate.IsValid)
        {
            return Results.BadRequest(validate.Errors);
        }
        return Results.Ok(await mediator.Send(form, token));
    }
    [HttpDelete("/{id}")]
    public async Task<IResult> Delete(int id, CancellationToken token = default)
    {
        return Results.Ok(await mediator.Send(new DeleteAccountRequest(id), token));
    }
}