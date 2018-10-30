namespace huffman_compression
{
        class Node: IComparable
    {
        public char Character
        { get; set; }

        public int Frequency
        { get; set; }

        public Node Left
        { get; set; }

        public Node Right
        { get; set; }

        public Node (char character, int frequency, Node left, Node right)
        { ... }

        // 5 marks
        public int CompareTo ( Object obj )
        { ... }
    }

    class Huffman
    {
        private Node HT; // Huffman tree to create codes and decode text
        private Dictionary<char,string> D; // Dictionary to encode text

        // Constructor
        public Huffman (string S)
        { ... }
        
        // 15 marks
        // Return the frequency of each character in the given text (invoked by Huffman)
        private int[] AnalyzeText ( string  S )
            { ... }
        
        // 20 marks
        // Build a Huffman tree based on the character frequencies greater than 0 (invoked by Huffman)
        private void Build (int[] F)
        {
            PriorityQueue<Node>  PQ;
        }
        
        // 20 marks
        // Create the code of 0s and 1s for each character by traversing the Huffman tree (invoked by Huffman)
        private void CreateCodes ( )
        { ... }
        
        // 10 marks
        // Encode the given text and return a string of 0s and 1s
        public string Encode ( string S)
        { ... }
        
        // 10 marks
        // Decode the given string of 0s and 1s and return the original text
        public string Decode ( string S)
        { ... }
    }

}
