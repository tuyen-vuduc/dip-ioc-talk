public interface IPaymentService {
    TxStatus Pay(int amount, string note);
}

public class PaymentServiceFactory  {
    public static PaymentMethod PaymentMethod = PaymentMethod.CreditCard;

    public static IPaymentService Create() {
        
        return PaymentMethod switch
        { 
            PaymentMethod.CreditCard => new CreditCardPaymentService(),
            _ => new CashPaymentService()
        };
    }
}

public class ShopManager {
    private IPaymentService paymentService;

    public ShopManager() {
        paymentService = PaymentServiceFactory.Create();
    }

    public bool CheckOut(params ProductItem[] productItems) {
        var totalAmount = productItems.Sum(x => x.Amount);
        var note = $"Paid for {productItems.Length}";

        return paymentService.Pay(totalAmount, note) == TxStatus.Paid;
    }
}

public class CreditCardPaymentService : IPaymentService {
    public TxStatus Pay(int amount, string note) {
        Console.WriteLine($"Tx: {Guid.NewGuid()} >> CreditCard - ${amount} >> {note}");

        return TxStatus.Paid;
    }
}

public class CashPaymentService : IPaymentService {
    public TxStatus Pay(int amount, string note) {
        Console.WriteLine($"Tx: {Guid.NewGuid()} >> CASH - ${amount} >> {note}");

        return TxStatus.Paid;
    }
}

public enum PaymentMethod {
    CreditCard,
    Cash,
}

public enum TxStatus {
    Pending,
    Paid,
    NotEnoughFund,
    Cancelled
}

public class ProductItem {
    public string? Description { get; set; } 
    public int Amount { get; set; }
}

//public class CreditCardDetail {
//     public string CardHolder { get; set; }
//     public string CardNumber { get; set; }
//     public string Csv { get; set; }
//     public int ExpireMonth { get; set; }
//     public int ExpireYear { get; set; }
// }