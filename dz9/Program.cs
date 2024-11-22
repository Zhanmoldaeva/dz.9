/*1 задание
 * public interface IBeverage
{
    string GetDescription();
    decimal Cost();
}

public class Espresso : IBeverage
{
    public string GetDescription()
    {
        return "Эспрессо";
    }

    public decimal Cost()
    {
        return 200m;
    }
}

public class Tea : IBeverage
{
    public string GetDescription()
    {
        return "Чай";
    }

    public decimal Cost()
    {
        return 522m;
    }
}

public abstract class BeverageDecorator : IBeverage
{
    protected IBeverage beverage;

    protected BeverageDecorator(IBeverage beverage)
    {
        this.beverage = beverage;
    }

    public virtual string GetDescription()
    {
        return beverage.GetDescription();
    }

    public virtual decimal Cost()
    {
        return beverage.Cost();
    }
}


public class Milk : BeverageDecorator
{
    public Milk(IBeverage beverage) : base(beverage) { }

    public override string GetDescription()
    {
        return beverage.GetDescription() + ", Молоко";
    }

    public override decimal Cost()
    {
        return beverage.Cost() + 89m;
    }
}

public class Sugar : BeverageDecorator
{
    public Sugar(IBeverage beverage) : base(beverage) { }

    public override string GetDescription()
    {
        return beverage.GetDescription() + ", Сахар";
    }

    public override decimal Cost()
    {
        return beverage.Cost() + 45m;
    }
}

public class WhippedCream : BeverageDecorator
{
    public WhippedCream(IBeverage beverage) : base(beverage) { }

    public override string GetDescription()
    {
        return beverage.GetDescription() + ", Взбитые сливки";
    }

    public override decimal Cost()
    {
        return beverage.Cost() + 9m;
    }
}

public class Program
{
    public static void Main()
    {
        IBeverage beverage = new Espresso();
        Console.WriteLine($"{beverage.GetDescription()} - {beverage.Cost()}tg");
        
        beverage = new Milk(beverage);
        Console.WriteLine($"{beverage.GetDescription()} - {beverage.Cost()}tg");

        beverage = new Sugar(beverage);
        Console.WriteLine($"{beverage.GetDescription()} - {beverage.Cost()}tg");

        beverage = new WhippedCream(beverage);
        Console.WriteLine($"{beverage.GetDescription()} - {beverage.Cost()}tg");

        Console.WriteLine();

        IBeverage tea = new Tea();
        tea = new Sugar(tea);
        tea = new Milk(tea);
        Console.WriteLine($"{tea.GetDescription()} - {tea.Cost()}tg");
    }
}
*/


public interface IPaymentProcessor
{
    void ProcessPayment(double amount);
}
public class PayPalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Обработка платежа {amount} через PayPal.");
    }
}
public class StripePaymentService
{
    public void MakeTransaction(double totalAmount)
    {
        Console.WriteLine($"Обработка транзакции на {totalAmount} с помощью Stripe.");
    }
}
public class StripePaymentAdapter : IPaymentProcessor
{
    private StripePaymentService _stripePaymentService;

    public StripePaymentAdapter(StripePaymentService stripePaymentService)
    {
        _stripePaymentService = stripePaymentService;
    }

    public void ProcessPayment(double amount)
    {
        _stripePaymentService.MakeTransaction(amount);
    }
    class Program
    {
        static void Main(string[] args)
        {
            IPaymentProcessor paypalProcessor = new PayPalPaymentProcessor();
            paypalProcessor.ProcessPayment(100.0);

            StripePaymentService stripeService = new StripePaymentService();
            IPaymentProcessor stripeProcessor = new StripePaymentAdapter(stripeService);
            stripeProcessor.ProcessPayment(200.0);
        }
    }
}

