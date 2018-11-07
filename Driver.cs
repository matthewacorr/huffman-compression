using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace COIS_2020H_Assignment_2
{
    class Driver
    {
      Console.WriteLine("Please enter a sentence to be parsed:");
      string str = Console.ReadLine();
      Huffman huffman = new Huffman(str);
    }
}
