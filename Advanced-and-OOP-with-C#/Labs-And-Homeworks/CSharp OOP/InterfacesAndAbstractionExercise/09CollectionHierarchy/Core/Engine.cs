using System;
using System.Collections.Generic;

using _09CollectionHierarchy.Interfaces;
using _09CollectionHierarchy.Models;

namespace _09CollectionHierarchy.Core
{
    public class Engine
    {
        private readonly AddCollection addCollection;
        private readonly AddRemoveCollection addRemoveCollection;
        private readonly MyList myList;
        private readonly List<string> stringResult;
        private readonly List<int> intResult;

        public Engine()
        {
            this.addCollection = new AddCollection();
            this.addRemoveCollection = new AddRemoveCollection();
            this.myList = new MyList();

            this.stringResult = new List<string>();
            this.intResult = new List<int>();
        }

        public void Run()
        {
            string[] elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int collection = 0; collection < 3; collection++)
            {
                foreach (var element in elements)
                {
                    ProcessAddOperation(collection, element);
                }

                Console.WriteLine(string.Join(" ", this.intResult));

                this.intResult.Clear();
            }

            int numberOfRemoveOperations = int.Parse(Console.ReadLine());

            RemoveItem(numberOfRemoveOperations, this.addRemoveCollection);
            RemoveItem(numberOfRemoveOperations, this.myList);
        }

        private void ProcessAddOperation(int collection, string element)
        {
            switch (collection)
            {
                case 0:
                    int elementToAddInFirstList = this.addCollection.Add(element);
                    this.intResult.Add(elementToAddInFirstList);
                    break;
                case 1:
                    int elementToAddInSecondList = this.addRemoveCollection.Add(element);
                    this.intResult.Add(elementToAddInSecondList);
                    break;
                case 2:
                    int elementToAddInThirdList = this.myList.Add(element);
                    this.intResult.Add(elementToAddInThirdList);
                    break;
            }
        }

        private void RemoveItem(int count, IAddRemoveCollection collection)
        {
            for (int i = 0; i < count; i++)
            {
                string element = collection.Remove();
                this.stringResult.Add(element);
            }

            Console.WriteLine(string.Join(" ", this.stringResult));
            this.stringResult.Clear();
        }
    }
}
