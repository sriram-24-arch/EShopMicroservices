﻿
namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string category) : IQuery<GetProductByCategoryResult>;

    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    public class GetProductByCategoryHandler
        (IDocumentSession session, ILogger<GetProductByCategoryHandler> logger)
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByIdHandler.Handle called with {@Query}", query);

            var products = await session.Query<Product>()
                            .Where(p=> p.Category.Contains(query.category)).ToListAsync();
            return new GetProductByCategoryResult(products);
        }
    }
}
