using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_01_8768_9208
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            Random r = new Random();//DateTime.Now.Millisecond);
            a = r.Next();
            int b = r.Next();
            int[] A = new int[20];
            int[] B = new int[20];
            int[] C = new int[20];

            for (int i = 0; i < 20; i++)
            {
                A[i] = r.Next(12, 129);
                B[i] = r.Next(12, 129);
                int efresh = A[i] - B[i];
                if (efresh < 0) efresh *= -1;
                C[i] = efresh;

            }
            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0,-3} ", A[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0,-3} ", B[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0,-3} ", C[i]);
            }

            Console.WriteLine(" ");
            Console.ReadKey();
        }
    }
}




namespace dotNet5780_02_8768_9208
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] places = new bool[12, 31];
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    places[i, j] = false;
                    //                  Console.Write("{0,-3} ", places[i, j]);
                }
            }


            Console.WriteLine("Enter your choice please:");
            Console.WriteLine("1- Customer requirement for hospitality");
            Console.WriteLine("2- View the annual list of all accommodation periods");
            Console.WriteLine("3- Displays the total number of days occupied per year and the percentage of annual occupancy");
            Console.WriteLine("4- Exit");
            string choice = Console.ReadLine();
            float count = 0;
            while (choice != "4")
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter the date of beginning of the stay");
                        string dateBegin = Console.ReadLine();
                        Console.WriteLine("Enter the time of the stay");
                        string timeStay = Console.ReadLine();

                        string day = dateBegin.Substring(0, 2);
                        string month = dateBegin.Substring(3);

                        int dayInt = Int32.Parse(day);
                        int monthInt = Int32.Parse(month);
                        int timeStayInt = Int32.Parse(timeStay);

                        bool flag = true;

                        for (int i = 0, d = dayInt - 1, m = monthInt - 1; i < timeStayInt; i++, d++)
                        {
                            if (d < 30)
                            {
                                if (places[m, d] == true && places[m, d + 1] == true)
                                {
                                    flag = false;
                                    Console.WriteLine("no places, sorry");
                                    break;
                                }
                            }
                            else
                            {
                                if (places[m, d] == true && places[m + 1, 1] == true)
                                {
                                    flag = false;
                                    Console.WriteLine("no places, sorry");
                                    break;
                                }
                            }
                            if ((d + 1) % 31 == 0)
                            {
                                m++;
                                d = 0;
                            }
                        }

                        if (flag)
                        {
                            Console.WriteLine("welcome to exo1");
                            for (int j = 0, d1 = dayInt - 1, m1 = monthInt - 1; j < timeStayInt; j++, d1++)
                            {
                                places[m1, d1] = true;
                                count++;
                                if ((d1 + 1) % 31 == 0)
                                {
                                    m1++;
                                    d1 = -1;
                                }
                            }
                        }
                        break;
                    case "2":
                        bool taken = false;
                        for (int m = 0, d = 0; m < 11 || d < 30; d++)
                        {
                            if ((d + 1) % 31 == 0)
                            {
                                d = 0;
                                m++;
                            }
                            if (places[m, d] == true)
                            {
                                Console.Write("unaivalable from : {0}/{1} ", d + 1, m + 1);
                                taken = true;
                            }
                            while (places[m, d] == true)
                            {
                                d++;
                                if ((d + 1) % 31 == 0)
                                {
                                    d = 0;
                                    m++;
                                }
                            }
                            if (taken == true)
                            {
                                Console.WriteLine("until : {0}/{1} ", d + 1, m + 1);
                                taken = false;
                            }
                        }

                        break;

                    case "3":
                        Console.WriteLine("there are {0} days reserved, which represent {1}% of the year", count, count / (12 * 31) * 100);
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Enter your choice please:");
                choice = Console.ReadLine();
            }


            Console.ReadKey();

        }
    }
}
