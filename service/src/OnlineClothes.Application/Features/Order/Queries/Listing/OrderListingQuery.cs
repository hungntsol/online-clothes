using OnlineClothes.Domain.Paging;

namespace OnlineClothes.Application.Features.Order.Queries.Listing;

public class OrderListingQuery : PagingRequest, IRequest<JsonApiResponse<PagingModel<OrderListingQueryViewModel>>>
{
}
