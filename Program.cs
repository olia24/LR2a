using System.Collections.Generic;
using System;
using System.Threading;
using ClassLibrary1;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
        resetMark:
            int count = 0;
            try
            {
                Console.Write("Input TV`s count: ");
                count = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                ErrorCatcher.Error("(devices count)");
                Thread.Sleep(2500);
                Console.Clear();
                goto resetMark;
            }

            List<TV> TVList = new List<TV>();

            for (int i = 0; i < count; i++)
            {
                TV.s_TV_Desc deviceDesc = new TV.s_TV_Desc();
                TV.ParamsInputRequest(ref deviceDesc);
                TVList.Add(new TV(deviceDesc));
            }

            foreach (TV device in TVList)
                Console.WriteLine('\n' + device.ToString());

            Console.ReadKey();
        }
    }
}