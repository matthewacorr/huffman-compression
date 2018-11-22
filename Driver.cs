using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

/***
 * 
 * COIS2020 - Assignment #2 - Huffman Compression
 * 
 * Created by: Matthew Corr    (0626013)
 *             Timothy Chaundy (0620479)
 * 
 ***/

namespace huffman_compression
{
    class Driver{
        static void Main(){
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White; // Color for readability
                    Console.WriteLine("Please Enter a string to be encoded"); // Welcome the user
                    Console.WriteLine("Valid Characters are A-Z, a-z and space (Non valid characters will be ignored)"); // Inform user of valid characters
                    Console.WriteLine("Press Ctrl+C to exit the program");
                    Console.WriteLine("------------------------------------------------------------------------------"); // Formatting for console readibilty

                    // Take string from user, we don't have to worry about invalid characters as AnalyzeText will sanitize it for us.
                    Console.ForegroundColor = ConsoleColor.Green; // Color for readability
                    string input = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White; // Color for readability
                    Huffman HuffTree = new Huffman(input);

                    // Encode the String using Encode().
                    string encoded = HuffTree.Encode(input);
                    Console.Write("Encoded String: ");
                    Console.ForegroundColor = ConsoleColor.Red;  // Color for readability
                    Console.Write(encoded + "\n");
                    Console.ForegroundColor = ConsoleColor.White;  // Color for readability

                    // Decode the String using Decode().
                    string decoded = HuffTree.Decode(encoded);
                    Console.Write("Decoded String: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;  // Color for readability
                    Console.Write(decoded + "\n\n");
                    Console.ForegroundColor = ConsoleColor.White;  // Color for readability

                    // Once the user has seen the decoded message pressing any key will clear the terminal and accept more user input
                    Console.ReadKey();
                    Console.Clear();
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a string\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
