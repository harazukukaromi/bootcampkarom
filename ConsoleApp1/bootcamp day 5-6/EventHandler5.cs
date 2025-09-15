/*using System;

//event accesors
public class Product
{
    // Manually declared delegate field
    private EventHandler? priceChanged;

    // Event with custom add/remove accessors
    public event EventHandler PriceChanged
    {
        add
        {
            Console.WriteLine("Subscribing to PriceChanged");
            priceChanged += value;
        }
        remove
        {
            Console.WriteLine("Unsubscribing from PriceChanged");
            priceChanged -= value;
        }
    }

    private decimal price;

    public decimal Price
    {
        get => price;
        set
        {
            if (price != value)
            {
                price = value;
                OnPriceChanged(); // Raise the event
            }
        }
    }

    // Protected virtual method to raise the event
    protected virtual void OnPriceChanged()
    {
        priceChanged?.Invoke(this, EventArgs.Empty);
    }
    class Program
    {
        static void Main()
        {
            Product p = new Product();

            // Subscribe
            p.PriceChanged += P_PriceChanged;

            // Trigger event
            p.Price = 10.99m;

            // Unsubscribe
            p.PriceChanged -= P_PriceChanged;

            p.Price = 12.99m;
        }

        private static void P_PriceChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Price changed!");
        }
    }
}*/

