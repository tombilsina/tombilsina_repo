namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            double a, b, c;
            double[] roots = new double[4];
            string[] input;
            input = Console.ReadLine().Split(' ');
            a = double.Parse(input[0]);
            b = double.Parse(input[1]);
            c = double.Parse(input[2]);
            double x1, x2;
            x1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            x2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            roots[0] = Math.Sqrt(x1);
            roots[1] = -Math.Sqrt(x1);
            roots[2] = Math.Sqrt(x2);
            roots[3] = -Math.Sqrt(x2);
            

            double temp;
            for (int i = 0; i < 4; i++)
            {
                int j = i;
                while (j < 3)
                {
                    if (roots[j] > roots[j + 1])
                    {
                        temp = roots[j+1];
                        roots[j + 1] = roots[j];
                        roots[j] = temp;

                    }
                    j++;

                }
            }
            for (int q = 0; q < 4; q++)
            {
                Console.WriteLine(roots[q]);
                
            }
        }
    }
}
