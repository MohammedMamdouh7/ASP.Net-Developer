namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numSmallcarpets = default;
            int numLargecarpets = default;

            Console.WriteLine("Welcom...  \n here Islam's Carpet Cleaning Service We are always happy to serve you," +
                " Here are the details: \n Charges:\r\n        $25 per small\r\n      " +
                "  $35 per large\r\n    Sales tax rate is 6%\r\n    Estimates are valid for 30 days." +
                " \n \n Please enter the number of small carbet you would like cleaned:");
            numSmallcarpets = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the number of large carbet you would like cleaned:");
            numLargecarpets = Convert.ToInt32(Console.ReadLine());

            double smallCarpetscost = 25 * numSmallcarpets;
            double largeCarpetscost = 35 * numLargecarpets;
            double cost = smallCarpetscost + largeCarpetscost;
            double costTax = 0.06;
            double tax = cost * costTax;
            double totalCost = cost + tax;

            Console.WriteLine($"The number of small carpet: --> {numSmallcarpets}\n " +
                $" The number of Larg carpet: --> {numLargecarpets}          " +
                " \nPrice per small carpet: 25$  \n Price per large carpet: 35$   " +
                $"           \n  Cost: {cost}$ \n    Tax: {tax}$ ==> Cost * {costTax} ");
            Console.WriteLine("================================================================= \n " +
                $"Total estimate: {totalCost}$  \n This estimate is valid for 30 dayes.");
        }
    }
}
