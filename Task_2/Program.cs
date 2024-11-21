namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           





            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                    ================================");
            Console.WriteLine("                                         Welcome to the Program      ");
            Console.WriteLine("                                    ================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;

            List<int> list = new List<int>() { };
            string P = "Print numbers";
            string A = "Add a number";
            string M = "Display mean of the numbers";
            string S = "Display the smallest number";
            string L = "Display the largest number";
            string F = "Find a number";
            string C = "Clear the while list";
            string Q = "Quit";
            char choice = ' ';
            do
            {
                Console.WriteLine("                                    Main Menu");
                Console.WriteLine($"                                    P - {P}");
                Console.WriteLine($"                                    A - {A}");
                Console.WriteLine($"                                    M - {M}");
                Console.WriteLine($"                                    S - {S}");
                Console.WriteLine($"                                    L - {L}");
                Console.WriteLine($"                                    F - {F}");
                Console.WriteLine($"                                    C - {C}");
                Console.WriteLine($"                                    Q - {Q}");
                Console.WriteLine("                                    =================================");
                Console.Write("Enter you Choice :==> ");
                choice = char.ToUpper(char.Parse(Console.ReadLine()));





                switch (choice)
                {



                    case 'P':
                        if (list.Count == 0)
                        {
                            Console.WriteLine("[] - Your list is empty");
                        }
                        else
                        {
                            Console.WriteLine("[ " + string.Join(" ", list) + " ]");      //== Reference for Join function ==< learn.microsoft.com > 
                        }
                        break;




                   
                    case 'A':
                        Console.Write("Enter the number to add :==> ");
                        int add = int.Parse(Console.ReadLine());

                        if (list.Contains(add))     //========= boun ==== Condition for No duplicate === Reference for Contain function ==< Stack overflow >====
                        {
                            Console.WriteLine($"The number {add} already exists in the list.");
                        }
                        else
                        {
                            list.Add(add);
                            Console.WriteLine($"Output :==> {add} added");
                        }
                        break;





                    case 'M':
                        
                        if (list.Count == 0)
                        {
                            Console.WriteLine("Unable to calculate the mean - no data");
                        }
                        else
                        {
                            double sum = 0;
                            foreach (int num in list)
                            {
                                sum += num;
                            }
                            double mean = sum / list.Count;
                            Console.WriteLine($"The mean is: {mean}");
                            break;
                        }
                        break;





                    case 'S':
                        if (list.Count == 0)
                        {
                            Console.WriteLine("Unable to determine the smallest number - list is empty");
                        }
                        else
                        {
                            int smallest = list[0];
                            foreach (int num in list)
                            {
                                if (num < smallest)
                                {
                                    smallest = num;
                                }
                            }
                            Console.WriteLine($"The smallest number is: {smallest}");
                        }
                        break;






                    case 'L':
                        if (list.Count == 0)
                        {
                            Console.WriteLine("Unable to determine the large number - list is empty");
                        }
                        else
                        {
                            int largest = list[0];
                            foreach (int num in list)
                            {
                                if (num > largest)
                                {
                                    largest = num;
                                }
                            }
                            Console.WriteLine($"The largest number is: {largest}");
                        }
                        break;





                    case 'F':
                       
                        if (list.Count == 0)
                        {
                            Console.WriteLine("[] - this list is empty");
                        }
                        else
                        {
                            Console.WriteLine("Enter the number to search :==>");
                            int target = int.Parse(Console.ReadLine());
                            int index = -1;
                            for (int i = 0; i < list.Count; i++)
                            {
                                if (list[i] == target)
                                {
                                    index = i;
                                    break;
                                }
                            }
                            if (index != -1)
                            {
                                Console.WriteLine($"The number {target} is found at index {index}.");
                            }
                            else
                            {
                                Console.WriteLine($"The number {target} is not found in the list.");
                            }
                        }
                        break;





                    case 'C':                               //======================= bouns =========================
                        if (list.Count != 0)
                        {
                            list.Clear();
                            Console.WriteLine("[ ] - Done... Now your list is empty");
                        }
                        else
                            Console.WriteLine("[ ] - The list is already empty."   );
                    
                    break;





                    case 'Q':
                        Console.WriteLine("GoodBay.......");
                       Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknown selection, please try again");
                        break;
                }
            }
            while (choice != 'Q');
           
        }
    }
}
