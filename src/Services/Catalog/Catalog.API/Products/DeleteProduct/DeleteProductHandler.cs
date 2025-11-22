
namespace Catalog.API.Products.DeleteProduct
{

    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProdctCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProdctCommandValidator() {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id is Required");
        }
    }
    public class DeleteProductHandler
        (IDocumentSession session)
        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            session.Delete<Product>(command.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(true);
        }
    }
}
