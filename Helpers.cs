using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace COIS_2020H_Assignment_2
{
    class Node: IComparable
    {
        public char// 10 marks
        // Decode the given string of 0s and 1s and return the original text
        public string Decode ( string S)
        {

        } Character { get; set; }
        public int Frequency { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node (char character, int frequency, Node left, Node right)
        {

        }

        // 5 marks
        public int CompareTo ( Object obj )
        {

        }
    }

    class Huffman
    {
        private Node HT; // Huffman tree to create codes and decode text
        private Dictionary<char,string> D; // Dictionary to encode text

        // Constructor
        public Huffman (string S)
        {

        }

        // 15 marks
        // Return the frequency of each character in the given text (invoked by Huffman)
        private int[] AnalyzeText ( string  S )
        {
          int[] frequency = new int[43];
          foreach(char C in S)
          {
            if(C )
          }
        }

        // 20 marks
        // Build a Huffman tree based on the character frequencies greater than 0 (invoked by Huffman)
        private void Build (int[] F)
        {
            PriorityQueue<Node>  PQ;
        }

        // 20 marks
        // Create the code of 0s and 1s for each character by traversing the Huffman tree (invoked by Huffman)
        private void CreateCodes ( )
        {

        }

        // 10 marks
        // Encode the given text and return a string of 0s and 1s
        public string Encode(string S)
        {
        //invoke huffman() [?], insert letters into dictionary w/ codes then read dictionary and output the code of each letter once the initial string is looked at again
            string result = "";
            char lookup;
            for(int i = 0; i< S.Length; i++){
                lookup = S[i];

                if(D.ContainsKey(lookup)==true)
                {
                    result = result + (D[lookup] +' ');
                }
            }
            return result;
        }

        // Decode the given string of 0s and 1s and return the original text
        public string Decode(string S)
        {
            string result = "";
            Node current = Root;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '0')
                    current = current.Left;
                else
                    current = current.Right;

                if (current.Left == null && current.Right == null)
                    result = result + current.Character;

                if (S[i + 1] == ' ')
                    i = i + 1;
                //adds up with the additional increase from the initial for loop to skip the space fully
            }

            return result;
        }
    }

}
