Console.WriteLine("Hello to SOLID shop");
Console.WriteLine("--------DIP--------");
var noOfProducts = 2;

var productItems = CreateProductItems(noOfProducts);


PaymentMethod paymentMethod = PaymentMethod.CreditCard;

ServiceLocator.Register<IPaymentService>(() => new CashPaymentService(), PaymentMethod.Cash.ToString());
ServiceLocator.Register<IPaymentService>(() => new CreditCardPaymentService(), PaymentMethod.CreditCard.ToString());
ServiceLocator.Register<IPaymentService>(() => paymentMethod switch {
    PaymentMethod.CreditCard => ServiceLocator.Get<IPaymentService>(paymentMethod.ToString()),
    _ => ServiceLocator.Get<IPaymentService>(PaymentMethod.Cash.ToString())
});

paymentMethod = PaymentMethod.Cash;
var shopManager = new ShopManager();
shopManager.CheckOut(productItems);

paymentMethod = PaymentMethod.CreditCard;
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