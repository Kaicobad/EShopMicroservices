﻿using Basket.API.Repository;

namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart Cart);
public class GetBasketQueryHandler(IBasketRepositoryService _basketRepository) : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async  Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var response = await _basketRepository.GetBasket(request.UserName, cancellationToken);
        return new GetBasketResult(response);
    }
}
