
namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(string Name, List<string> Category, string Description, 
                                       string ImageFile, decimal Price) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    { 
        public CreateProductCommandValidator() { 
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name is Required");
            RuleFor(c => c.Category).NotEmpty().WithMessage("Category is Required");
            RuleFor(c => c.ImageFile).NotEmpty().WithMessage("ImageFile is Required");
            RuleFor(c => c.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
    public class CreateProductCommadHandler(IDocumentSession session)  
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            //Save to Database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);
        }
    }
}
