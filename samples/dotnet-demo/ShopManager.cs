public class ShopManager {
    private CreditCardPaymentService paymentService;

    public ShopManager() {
        paymentService = new CreditCardPaymentService();
    }

    public bool CheckOut(params ProductItem[] productItems) {
        var totalAmount = productItems.Sum(x => x.Amount);
        var note = $"Paid for {productItems.Length}";

        return paymentService.Pay(totalAmount, note) == TxStatus.Paid;
    }
}

public class CreditCardPaymentService {
    public TxStatus Pay(int amount, string note) {
        Console.WriteLine($"Tx: {Guid.NewGuid()} >> CreditCard - ${amount} >> {note}");

        return TxStatus.Paid;
    }
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