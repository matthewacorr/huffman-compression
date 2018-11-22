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
    class Node : IComparable{
        public char Character { get; set; }
        public int Frequency { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Root { get; set; }

        // Node Constructor
        public Node(char character = '0', int frequency = 0, Node left = null, Node right = null){
            Character = character;
            Frequency = frequency;
            Left = left;
            Right = right;
        }

        // CompareTo Method
        public int CompareTo(Object obj){
                Node x = (Node)obj;
                if (Frequency < x.Frequency)
                    return 1;
                else
                    if (Frequency == x.Frequency)
                    return 0;
                else
                    return -1;
        }
    }

    class Huffman
    {
        private Node HT;
        private Dictionary<char, string> D = new Dictionary<char, string>();
        // Create an array with all possible characters (A-Z, a-z and a space char).
        public char[] listOfChars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ' };

        //Huffman Constructor
        public Huffman(string S){

            Build(AnalyzeText(S)); // Build the tree with the codes provided by Analyze Text.
            CreateCodes(HT); // Move along the tree to form codes and then add those codes to the Dictionary D.
        }

        // This method returns the frequency of each letter in the string S.
        private int[] AnalyzeText(string S){

            int[] freqArray = new int[53]; // Create an array which can store all of the possible frequencies (53 for the two 26 letter alphabets and one space char).
            char[] listOfChars = S.ToCharArray(); // Use ToCharArray to split the string into an array of characters.

            // Cycle through every character in the list of possible characters
            foreach (char e in listOfChars){

                // Cast the character to an interger and verify it is within the range of accepted characters
                if ((int)e == 32 || (int)e >= 65 && (int)e <= 90 || (int)e >= 97 && (int)e <= 122){
                    int pos; // This int will be used to find the index of a given char

                    // If the char is not a space
                    if (e != ' '){
                        if (e == Char.ToUpper(e)){ // If the char is uppercase
                            pos = Char.ToUpper(e) - 65; //Add to the index (Starting at 0)
                        }
                        else{ // Char is lowercase
                            pos = Char.ToUpper(e) - 65; // Add to the index (Starting at 0)
                            pos = pos + 26; // Adding 26 moves us into the range of lowercase chars
                        }
                    }
                    else { // Char is a space
                        pos = 52;
                    }
                    freqArray[pos] = freqArray[pos] + 1; // Increase frequency at specific index
                }
            }
            return freqArray; // Return the frequency
        }

        private void CreateCodes(Node n, string prefix = ""){ // Traverse the tree to create the codes for each leaf node
            if (n.Character != '0'){
                D.Add(n.Character, prefix); // If it is not null than add the character and the prefix to the dictionary
            }

            else{
                // Add a 0 to the left side of the huffman tree
                CreateCodes(n.Left, prefix + "0");
                if (n.Right != null)
                {
                    // Should only enter this if there is a right node, if so change the prefix to one
                    CreateCodes(n.Right, prefix + "1");
                }
            }
        }

        private void Build(int[] F){ // Builds the huffman tree (Invoked by Huffman)

            PriorityQueue<Node> PQ = new PriorityQueue<Node>(F.Length); // Create a new priority queue PQ with the length of the amount of frequencies in F[]

            for (int i = 0; i < F.Length; i++){ // This loop cycles through all frequencies and turns them into leaf nodes
                if (F[i] > 0){ // If the character has a frequency of at least 1.
                    Node working = new Node(listOfChars[i], F[i], null, null);  // Set the leaf node to have no children.
                    PQ.Add(working); // Add the node to the priority queue.
                }
            }

            if (PQ.Size() == 1){ // If there is only one leaf node.
                // Set the top node to only have one child and set the frequency to be the same as that leaf node.
                HT = new Node();
                HT.Frequency = PQ.Front().Frequency;
                HT.Left = PQ.Front();
                 
                PQ.MakeEmpty(); // Empty the priority queue
            }

            else{
                while (PQ.Size() > 1){ // While there is atleast a node in the Priority Queue PQ
                    Node working = new Node(); // Create a temp node 
                    
                    int freq = PQ.Front().Frequency; // Save the left side frequency and node, then remove it from the PQ
                    working.Left = PQ.Front();
                    PQ.Remove();
                    
                    working.Frequency = freq + PQ.Front().Frequency; // Save the right side frequency and node, then remove it from the PQ
                    working.Right = PQ.Front();
                    PQ.Remove();

                    PQ.Add(working); // Add the subtree to the PriorityQueue PQ
                }
                HT = PQ.Front(); // Go to the front of the priority queue
                PQ.MakeEmpty(); // Empty it
            }
        }

        public string Encode(string S){ // This method checks the dictionary D to encode a string S

            string eString = ""; // Initialize the encoded string
            string eString2 = "";

            char codes; // Count the index
            for (int i = 0; i < S.Length; i++){
                codes = S[i];
                if (D.ContainsKey(codes) == true){
                    eString = eString + (D[codes]);
                }
            }
            // Return Encoded String
            return eString;
        }

        public string Decode(string S){

            string dString = ""; // Initialize the decoded string
            string codes = "";

            // Create a dictionary to be the reverse of dictionary D
            Dictionary<string, char> DictRev = new Dictionary<string, char>();

            foreach (KeyValuePair<char, string> entry in D){ // Loop through values in D
                // Add the entries with reversed values and keys
                DictRev.Add(entry.Value, entry.Key);
            }

            foreach (char c in S){ // For each character in the encoded string
                codes += c.ToString(); // Add the character

                // Look to see if ReverseDic contain
                if (DictRev.ContainsKey(codes)){ // Look to see if ReverseDic contain
                    dString += DictRev[codes]; // Add it to the decoded string
                    codes = ""; // Reset the character
                }
            }

            // Return Decoded String
            return dString;
        }
    }
}
