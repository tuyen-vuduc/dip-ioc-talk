Console.WriteLine("Hello to SOLID shop");
Console.WriteLine("--------DIP--------");
var noOfProducts = 2;

var productItems = CreateProductItems(noOfProducts);

ServiceLocator.Register<IPaymentService>(() => new CashPaymentService());
var shopManager = new ShopManager();
shopManager.CheckOut(productItems);

ServiceLocator.Register<IPaymentService>(() => new CreditCardPaymentService());
var shopManager2 = new ShopManager();
shopManager2.CheckOut(productItems);

ProductItem[] CreateProductItems(int count = 1) {
    if (count <= 0) return Array.Empty<ProductItem>();

    var faker = new Faker<ProductItem>()
        .RuleFor(o => o.Amount, f => f.Random.Number(1, 10))
        //Pick some fruit from a basket
        .RuleFor(o => o.Description, f => f.Commerce.ProductName());
    
    return faker.Generate(count).ToArray();
}