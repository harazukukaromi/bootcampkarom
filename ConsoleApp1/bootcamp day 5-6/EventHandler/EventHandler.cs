/*using System;

//event handler part1
public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice); // 1. Delegate

public class Broadcaster
{
    private decimal _price;

    // 2. Event declaration
    public event PriceChangedHandler PriceChanged;

    public decimal Price
    {
        get { return _price; }
        set
        {
            if (_price != value)
            {
                decimal oldPrice = _price;
                _price = value;

                // 3. Raise the event
                OnPriceChanged(oldPrice, _price);
            }
            else
            {
                Console.WriteLine($"No event triggered. Price remains the same at {_price:C}");
            }
        }
    }

    // 4. Protected virtual method to raise the event
    protected virtual void OnPriceChanged(decimal oldPrice, decimal newPrice)
    {
        if (PriceChanged != null)
        {
            PriceChanged(oldPrice, newPrice);
        }
    }
}

public class Subscriber
{
    public void Subscribe(Broadcaster broadcaster)
    {
        broadcaster.PriceChanged += OnPriceChanged;
    }

    private void OnPriceChanged(decimal oldPrice, decimal newPrice)
    {
        Console.WriteLine($"Price changed from {oldPrice:C} to {newPrice:C}");
    }
}

public class Program
{
    public static void Main()
    {
        Broadcaster broadcaster = new Broadcaster();
        Subscriber subscriber = new Subscriber();

        subscriber.Subscribe(broadcaster);

        // Change the price to trigger the event
        broadcaster.Price = 35.00m;
        broadcaster.Price = 120.10m;
        broadcaster.Price = 120.50m;
        broadcaster.Price = 120.50m; // No change, no event
        broadcaster.Price = 87.75m;
        broadcaster.Price = -12.75m;
        broadcaster.Price = 30.23m;
    }
}*/
