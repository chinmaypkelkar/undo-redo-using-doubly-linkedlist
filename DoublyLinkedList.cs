using System.Collections.Generic;

namespace data_structures_assignment2
{
    public class DoublyLinkedList
    {
        private Node Head { get; set; } // head of the linked list
        private Node Tail { get; set; } // tail of the linked list
        
        public Node CurrentNode { get; set; } // tracks current state

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        // used to append the node at the end of the list
        public void Append(List<int> data)
        {
            var newNode = new Node(data);
            if (Head is null)
            {
                Head = newNode;
                Tail = Head;
            }
            else
            {
                newNode.Previous = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }
            CurrentNode = Tail;
        }

        // used to insert node in between two nodes. It is used to perform Do operations after Undo to unlink unnecessary nodes
        public void InsertBetween(List<int> data)
        {
            var newNode = new Node(data) {Previous = CurrentNode};
            CurrentNode.Next = newNode;
            Tail = newNode;
            CurrentNode = newNode;
        }
        
    }
}