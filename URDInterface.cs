using System;
using System.Collections.Generic;

namespace data_structures_assignment2
{
    public class UrdInterface
    {

        private DoublyLinkedList Application { get; } // doubly linked list

        private List<int> _appState;
        public List<int> AppState // application state
        {
            get => Application.CurrentNode.Data; // returns current app state
            private set => _appState = value;
        }

        // initialize application
        public UrdInterface(List<int> initialData)
        {
            AppState = initialData;
            Application = new DoublyLinkedList();
            Application.Append(initialData);
            DisplayState("Initial State");
        }

        // if current node is the last node, append new node to current node otherwise insert new node between currentnode and its next node
        public void Do(List<int> data, string operation)
        {
            AppState = data;
            if (Application.CurrentNode?.Next == null)
            {
                Application.Append(data);
            }
            else
            {
                Application.InsertBetween(data);
            }
            
            DisplayState(operation);
        }

        // sort current appstate and return new state
        public List<int> Sort()
        {
            var newAppState = new List<int>(AppState);
            newAppState.Sort();
            return newAppState;
        }

        // reverse current appstate and return new state
        public List<int> Reverse()
        {
            var newAppState = new List<int>(AppState);
            newAppState.Reverse();
            return newAppState;
        }

        // add element at the end of the current state
        public List<int> Add(int number)
        {
            var newAppState = new List<int>(AppState) {number};
            return newAppState;
        }

        // undo operation
        public void Undo()
        {
            if (Application.CurrentNode.Previous != null)
            {
                Application.CurrentNode = Application.CurrentNode.Previous;
                DisplayState("Undo");
            } 
            else
            {
                Console.WriteLine("Nothing to undo");
            }
        }

        //redo operation
        public void Redo()
        {
            if (Application.CurrentNode.Next != null)
            {
                Application.CurrentNode = Application.CurrentNode.Next;
                DisplayState("Redo");
            }
            else
            {
                Console.WriteLine("Nothing to redo");
            }
        }
        
        // display current state
        private void DisplayState(string operation)
        {
            Console.WriteLine($"{operation} : {string.Join(",",AppState)}");
        }
    }
}