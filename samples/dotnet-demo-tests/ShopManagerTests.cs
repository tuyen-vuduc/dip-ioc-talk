

namespace samples;

public class ShopManagerTests
{
    [Fact]
    public void CheckOut_OK()
    {
        var shopManager = new ShopManager();
        var productItem = new ProductItem {
            Amount = 100,
        };

        var result = shopManager.CheckOut(productItem);

        Assert.True(result);     
    }
}