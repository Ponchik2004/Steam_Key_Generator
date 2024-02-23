using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Key_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please type the amount of keys to be generated: ");
            ReadAndCheck();
        }

        static void ReadAndCheck()
        {
            try
            {
                int amount = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                Console.WriteLine("Keys:");
                for (int i = 0; i < amount; i++)
                {
                    Console.WriteLine(keyGenerator());
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("");
                Console.WriteLine("Error...:" + e.Message + " Please type a valid number.");
                ReadAndCheck();
            }
        }

        static string keyGenerator()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string code = "";

            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[20]; // Adjust the length as needed
                rng.GetBytes(randomBytes);

                for (int i = 0; i < 15; i++)
                {
                    int index = BitConverter.ToInt32(randomBytes, i % randomBytes.Length) % chars.Length;
                    if (index < 0)
                        index += chars.Length;
                    code += chars[index];
                }
            }

            return code.Substring(0, 5) + "-" + code.Substring(5, 5) + "-" + code.Substring(10, 5);
        }
    }

}