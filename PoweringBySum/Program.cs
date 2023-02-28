using System;

namespace PoweringBySum
{
    class Programm
    {
        static int Multiplying(int a, int b)
        {
            bool minus = false;
            if (a == 0 || b == 0) return 0;
            if (a < 0 && b < 0)
            {
                a = -a;
                b = -b;
                minus = false;
            }           
            else if (a < 0)
            {
                a = -a;
                minus = true;
            }
            else if (b < 0)
            {                    
                b = -b;
                minus = true;
            }
                
            int answer = 0;

            for (int i = 0; i < b; i++)
            {
                try
                {
                    checked
                    {
                        answer += a;
                    }                  
                }
                catch (OverflowException)
                {
                    //Console.WriteLine("Overflow exception was caught!");
                    return answer;
                }
            }

            if (minus)
                answer = -answer;

            return answer;
        }
        static int Powering(int a, int k)
        {
            if (a == 1) return 1;
            if (a < 0)
            {
                if (k % 2 == 0)
                {
                    return Powering(-a, k);
                }
                else
                {
                    return -Powering(-a, k);
                }
            }
            if (k < 0) return 0;
            if (k == 0) return 1;
            if (k == 1) return a;


            int answer = a;

            for (int i = 0; i < k-1; i++)
            {
                answer = Multiplying(answer, a);
            }

            return answer;
        }

        static void TestPow()
        {
            Random random = new Random();
            int rounds = 1000, count = 0;
            int mypow = 0, pow = 0;

            for (int i = 0; i < rounds; i++)
            {
                int a = random.Next(-50, 50);
                int k = random.Next(-10, 10);
                
                try
                {
                    checked
                    {
                        mypow = Powering(a, k);
                        pow = (int)Math.Pow(a, k);                                            
                    }
                    if (mypow == pow)
                    {
                        Console.WriteLine($"{a}^{k} = {mypow}" + '\n' + "Success" + '\n');
                        count++;
                    }
                    else
                    {
                        Console.WriteLine($"{a}^{k} = {mypow}, when Math.Pow is {pow}");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("FAIL" + '\n');
                        Console.ResetColor();
                    }

                }
                catch (OverflowException)
                {
                    Console.WriteLine($"{a}^{k} = {mypow}");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Overflow" + '\n');
                    Console.ResetColor();
                    count++;
                }
            }

            if (count == rounds)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Powering Test completed successfully");
                Console.ResetColor();
            }              
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Powering Test failed");
                Console.ResetColor();
            }
        }

        static void TestMul()
        {
            Random random = new Random();
            int rounds = 1000, count = 0;
            int mymul = 0, mul = 0;

            for (int i = 0; i < rounds; i++)
            {
                int a = random.Next(-10, 10);
                int b = random.Next(-10, 10);

                try
                {
                    checked
                    {
                        mymul = Multiplying(a, b);
                        mul = a * b;
                    }
                    if (mymul == mul)
                    {
                        //Console.WriteLine($"{a}^{b} = {mymul}" + '\n' + "Success" + '\n');
                        count++;
                    }
                    else
                    {
                        Console.WriteLine($"{a}^{b} = {mymul}, when Math.Pow is {mul}");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("FAIL" + '\n');
                        Console.ResetColor();
                    }

                }
                catch (OverflowException)
                {
                    Console.WriteLine($"{a}^{b} = {mymul}");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Overflow" + '\n');
                    Console.ResetColor();
                    count++;
                }
            }

            if (count == rounds)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Multiplying Test completed successfully");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Multiplying Test failed");
                Console.ResetColor();
            }
        }

        static void Main()
        {
            int a = -1, k = 4;
            TestPow();
            TestMul();
            Console.WriteLine($"{a}^{k} = {Powering(a, k)}");
            //Console.WriteLine(Multiplying(-1, -4));
        }
    }
}
