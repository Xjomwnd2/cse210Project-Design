using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; }
    public double Price { get; }
    private int stock;

    public Product(string name, double price, int stock)
    {
        Name = name;
        Price = price;
        this.stock = stock;
    }

    public string GetDetails()
    {
        return $"{Name}: ${Price:F2}, Stock: {stock}";
    }

    public bool IsAvailable(int quantity)
    {
        return stock >= quantity;
    }

    public bool ReduceStock(int quantity)
    {
        if (IsAvailable(quantity))
        {
            stock -= quantity;
            return true;
        }
        else
        {
            Console.WriteLine($"Not enough stock for {Name}.");
            return false;
        }
    }
}

class Cart
{
    private Dictionary<Product, int> items;

    public Cart()
    {
        items = new Dictionary<Product, int>();
    }

    public void AddProduct(Product product, int quantity)
    {
        if (product.IsAvailable(quantity))
        {
            if (items.ContainsKey(product))
                items[product] += quantity;
            else
                items.Add(product, quantity);

            product.ReduceStock(quantity);
            Console.WriteLine($"Added {quantity}x {product.Name} to cart.");
        }
        else
        {
            Console.WriteLine($"Cannot add {product.Name} to cart. Insufficient stock.");
        }
    }

    public double CalculateTotal()
    {
        double total = 0;
        foreach (var item in items)
        {
            total += item.Key.Price * item.Value;
        }
        return total;
    }

    public Dictionary<Product, int> GetItems()
    {
        return items;
    }
}

class Order
{
    public int OrderID { get; }
    private Dictionary<Product, int> items;
    private double totalPrice;

    public Order(Cart cart)
    {
        OrderID = new Random().Next(1000, 9999);
        items = new Dictionary<Product, int>(cart.GetItems());
        totalPrice = cart.CalculateTotal();
    }

    public void ProcessOrder()
    {
        Console.WriteLine($"Order {OrderID} placed successfully.");
        Console.WriteLine(GenerateSummary());
    }

    public string GenerateSummary()
    {
        string summary = $"\nOrder ID: {OrderID}\nItems:\n";
        foreach (var item in items)
        {
            summary += $"- {item.Value}x {item.Key.Name} @ ${item.Key.Price:F2} each\n";
        }
        summary += $"Total: ${totalPrice:F2}";
        return summary;
    }
}

class Customer
{
    public string Name { get; }
    private Cart cart;

    public Customer(string name)
    {
        Name = name;
        cart = new Cart();
    }

    public void AddToCart(Product product, int quantity)
    {
        cart.AddProduct(product, quantity);
    }

    public void PlaceOrder()
    {
        if (cart.GetItems().Count == 0)
        {
            Console.WriteLine("Cart is empty. Add items before placing an order.");
        }
        else
        {
            Order order = new Order(cart);
            order.ProcessOrder();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.\n");

        Product laptop = new Product("Laptop", 1200, 5);
        Product mouse = new Product("Wireless Mouse", 25, 20);
        Product keyboard = new Product("Mechanical Keyboard", 75, 10);

        Console.WriteLine(laptop.GetDetails());
        Console.WriteLine(mouse.GetDetails());
        Console.WriteLine(keyboard.GetDetails());

        Customer customer = new Customer("Alice");

        customer.AddToCart(laptop, 1);
        customer.AddToCart(mouse, 2);
        customer.AddToCart(keyboard, 1);

        customer.PlaceOrder();
    }
}
