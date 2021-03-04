using System.Collections.Generic;
using System;
using System.Threading;

namespace ClassLibrary1
{
    class Program
    {
        static void Main(string[] args)
        {
            TV.s_TV_Desc deviceDesc = new TV.s_TV_Desc();

            paramInput("Width", ref deviceDesc.width);
            paramInput("Height", ref deviceDesc.height);
            paramInput("Diagonal", ref deviceDesc.diagonal);
            paramInput("Resolution", ref deviceDesc.resolution);
            paramInput("Model name", ref deviceDesc.modelName);
            paramInput("Manufacturer", ref deviceDesc.manufacturer);
            paramInput("Price", ref deviceDesc.price);
            paramInput("Weight", ref deviceDesc.weight);

            TV device = new TV(deviceDesc);
            Console.WriteLine('\n' + device.ToString());
            Console.ReadKey();
        }

        static void paramInput(string paramName, ref string variable)
        {
            try
            {
                Console.Write("Enter device " + paramName + ":");
                variable = Console.ReadLine();
            }
            catch { }
        }
        static void paramInput(string paramName, ref TV.s_Resolution variable)
        {
            try
            {
                Console.WriteLine("Enter device " + paramName + ":");
                Console.Write("Width: ");
                variable.X_Res = Convert.ToInt32(Console.ReadLine());
                Console.Write("Height: ");
                variable.Y_Res = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                ErrorCatcher.Error(paramName);
                paramInput(paramName, ref variable);
            }
        }
        static void paramInput(string paramName, ref float variable)
        {
            try
            {
                Console.Write("Enter device " + paramName + ":");
                variable = (float)(Convert.ToDouble(Console.ReadLine()));
            }
            catch
            {
                ErrorCatcher.Error(paramName);
                paramInput(paramName, ref variable);
            }
        }
        static void paramInput(string paramName, ref int variable)
        {
            try
            {
                Console.Write("Enter device " + paramName + ":");
                variable = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                ErrorCatcher.Error(paramName);
                paramInput(paramName, ref variable);
            }
        }
    }
    class ErrorCatcher
    {
        public static void Error(string paramName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong symbol or empty entered to " + paramName + ".\n Please try again\n");
            Console.ResetColor();
        }
    }
    class TV
    {
        public struct s_Resolution
        {
            public int X_Res;
            public int Y_Res;
        }
        public struct s_TV_Desc
        {
            public int width;
            public int height;
            public float diagonal;
            public s_Resolution resolution;
            public string modelName;
            public string manufacturer;
            public float price;
            public float weight;
        }
        public TV(s_TV_Desc deviceDescription)
        {
            this.Description = deviceDescription;
        }
        public override string ToString()
        {
            string output = string.Empty;

            output += "              Width: " + Description.width + '\n';
            output += "             Height: " + Description.height + '\n';
            output += "           Diagonal: " + Description.diagonal + '\n';
            output += "         Resolution: " + Description.resolution.X_Res + "x" + Description.resolution.Y_Res + '\n';
            output += "             Square: " + Description.width * Description.height + '\n';
            output += "         Model name: " + Description.modelName + '\n';
            output += "       Manufacturer: " + Description.manufacturer + '\n';
            output += "              Price: " + Description.price + '\n';
            output += "             Weight: " + Description.weight + '\n';

            return output;
        }
        public s_TV_Desc Description { get; private set; }
    }
}

