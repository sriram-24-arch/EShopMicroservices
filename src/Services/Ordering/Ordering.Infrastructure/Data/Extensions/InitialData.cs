namespace Ordering.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static IEnumerable<Customer> Customers =>
            new List<Customer>
            {
                Customer.Create(CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")), "mehmet", "mehmet@gmail.com"),
                Customer.Create(CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")), "john", "john@gmail.com")
            };

        public static IEnumerable<Product> Products =>
            new List<Product>
            {
                Product.Create(ProductId.Of(new Guid("a3f1c4e2-8f4b-4d3b-9c3a-1f2e3d4c5b6a")), "Laptop", 1500m),
                Product.Create(ProductId.Of(new Guid("b4e2d3c1-7f6a-5b4c-8d9e-0f1a2b3c4d5e")), "Smartphone", 800m),
                Product.Create(ProductId.Of(new Guid("c5d4e3f2-6a5b-4c3d-9e8f-1a0b2c3d4e5f")), "Tablet", 400m)
            };

        public static IEnumerable<Order> OrdersWithItems
        {
            get
            {
                var address1 = Address.Of("Mehmet", "Yilmaz", "mehmet@gmail.com", "123 Main St", "Turkey", "Istanbul", "34000");
                var address2 = Address.Of("John", "Doe", "john@gmail.com", "456 Elm St", "USA", "California", "90001");

                var payment1 = Payment.Of("Mehmet, Yilmaz", "4111111111111111", "12/25", "123", 1);
                var payment2 = Payment.Of("John Doe", "4222222222222", "11/24", "456", 2);

                var order1 = Order.Create(
                             OrderId.Of(Guid.NewGuid()),
                             CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),
                             OrderName.Of("ORD_1"),
                             shippingAddress: address1,
                             billingAddress: address1,
                             payment1);

                order1.Add(ProductId.Of(new Guid("a3f1c4e2-8f4b-4d3b-9c3a-1f2e3d4c5b6a")), 2, 3000m);
                order1.Add(ProductId.Of(new Guid("c5d4e3f2-6a5b-4c3d-9e8f-1a0b2c3d4e5f")), 3, 1200m);

                var order2 = Order.Create(
                             OrderId.Of(Guid.NewGuid()),
                             CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),
                             OrderName.Of("ORD_2"),
                             shippingAddress: address2,
                             billingAddress: address2,
                             payment2);

                order2.Add(ProductId.Of(new Guid("b4e2d3c1-7f6a-5b4c-8d9e-0f1a2b3c4d5e")), 4, 1600m);

                return new List<Order> { order1, order2 };
            }
        }
    }
}
