using System.Diagnostics;

public class CheckoutService(InventoryClient inventory)
{
    private static readonly ActivitySource Source = new("OrdersApi");

    public async Task<Order> PlaceOrderAsync(Cart cart)
    {
        using var activity = Source.StartActivity("PlaceOrder");
        activity?.SetTag("order.item_count", cart.Items.Count);

        try
        {
            await inventory.ReserveAsync(cart.Items); // child span via HttpClient
            return Order.From(cart);
        }
        catch (Exception ex)
        {
            activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
            throw;
        }
    }
}
