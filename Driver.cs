using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using COIS_2020H_Assignment_2;

namespace COIS_2020H_Assignment_2
{
    class Driver
    {
      public static void Main()
        {
            string input;
            Console.WriteLine("Please input a sentence to be parsed");
            input = Console.ReadLine();
            Huffman x = new Huffman(input);

            Console.WriteLine("Text that will be encoded: {0}", input);
            x.Encode(input);

            Console.WriteLine("Code that will be decoded: {0}", input);
            x.Decode(input);
        }
    }
}
