using System.Collections.Generic;

namespace data_structures_assignment2
{
    public class Node
    {
        public Node(List<int> dataIn)
        {
            Data = dataIn;
            Next = null;
            Previous = null;
        }
        public List<int> Data { get; } // data
        public Node Next { get; set; } // next address
        public Node Previous { get; set; } // previous address
    }
}