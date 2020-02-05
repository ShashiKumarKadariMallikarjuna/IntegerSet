/**
 * Shashi Kumar Kadari Mallikarjuna
 * CECS 475
 * Lab Assignment 2 part 1
 * Assigned date: 1/23
 * Due Date: 1/30
**/

using System;
using System.Collections.Generic;

namespace IntegerSet
{   
    //IntegerSet class
    class IntegerSet
    {
        //initializing the variable
        bool[] intSet = new bool[101];

        // constructor
        public IntegerSet()
        {
            for(int i = 0; i<101; i++)
            {
                intSet[i] = false;
            }
        }

        // Overloaded constructor with array of int type as parameter
        public IntegerSet(int[] intArray)
        {
            foreach(int i in intArray)
            {
                if (i >= 0 && i<101)
                {
                    intSet[i] = true;
                }
            }
        }

        //method that sets the value of index "num" in the array to true.
        public void setValueTrue(int num)
        {
            intSet[num] = true;
        }

        //method that sets the value of index "num" in the array to false.
        public void SetValueFalse(int num)
        {
            intSet[num] = false;
        }

        //method that return returns the value of the index "num" of the array.
        public bool GetValue(int num)
        {
            return intSet[num];
        }

        /**
        method Union creates a third set that is the set-theoretic union of two existing sets 
        (i.e., an element of the third set’s array is set to true if that element is true in either 
        or both of the existing sets—otherwise, the element of the third set is set to false).
        **/
        public IntegerSet Union(IntegerSet set2)
        {
            //creating a temporary integerset object to save the union of the two integerSet objects.
            IntegerSet set3 = new IntegerSet();
            //for loop that iterates through all the indexes in the array
            for(int i = 0; i < 101; i++)
            {
                if(set2.GetValue(i) ==false && intSet[i] == false)
                {
                    set3.SetValueFalse(i);
                }
                else
                {
                    set3.setValueTrue(i);
                }
            }
            return set3;
        }

        /**
        method Intersection creates a third set which is the set-theoretic intersection of two existing sets
        (i.e., an element of the third set’s array is set to false if that element is false in either or both 
        of the existing sets—otherwise, the element of the third set is set to true).
        **/
        public IntegerSet Intersection(IntegerSet set2)
        {
            //creating a temporary integerset object to save the intersection of the two integerSet objects.
            IntegerSet set3 = new IntegerSet();
            //for loop that iterates through all the indexes in the array
            for (int i = 0; i < 101; i++)
            {
                if (set2.GetValue(i) && intSet[i] == true)
                {
                    set3.setValueTrue(i);
                }
                else
                {
                    set3.SetValueFalse(i);
                }
            }
            return set3;
        }

        // method InsertElement inserts a new integer k into a set (by setting a[k] to true)
        public void InsertElement(int num)
        {
            intSet[num] = true;
        }

        //method DeleteElement deletes integer m (by setting a[m] to false).
        public void DeleteElement(int num)
        {
            intSet[num] = false;
        }

        //method ToString returns a string containing a set as a list of numbers separated by spaces.
        public string ToString()
        {
            List<int> numbers = new List<int>();
            for(int i = 0; i < 101; i++)
            {
                if (intSet[i] == true)
                {
                    numbers.Add(i);
                }
            }
            if (numbers.Count == 0)
            {
                return "---";
            }
            else
            {
                return string.Join(" ", numbers.ToArray());
            }
        }

        //method IsEqualTo determines whether two sets are equal.
        public bool IsEqualTo(IntegerSet set2)
        {
            bool areEqual = true;
            //for loop that iterates through all the indexes in the array
            for (int i = 0; i < 101; i++)
            {
                if (intSet[i] != set2.GetValue(i))
                {
                    areEqual = false;
                    break;
                }
            }
            return areEqual;
            
        }
    }

    class Program
    {
        //Main method
        static void Main(string [] args)
        {
            // initialize two sets
            var A = new int[] { 2, 10, 16, 33, 99 };
            Console.WriteLine("Input Set A");
            IntegerSet set1 = InputSet(A);

            var B = new int[] { 3, 10, 1, 33, 80 };
            Console.WriteLine("\nInput Set B");
            IntegerSet set2 = InputSet(B);
            

            IntegerSet union = set1.Union(set2);
            IntegerSet intersection = set1.Intersection(set2);
            
            // prepare output
            Console.WriteLine("\nSet A contains elements:");
            Console.WriteLine(set1.ToString());
            Console.WriteLine("\nSet B contains elements:");
            Console.WriteLine(set2.ToString());
            Console.WriteLine(
            "\nUnion of Set A and Set B contains elements:");
            Console.WriteLine(union.ToString());
            Console.WriteLine(
            "\nIntersection of Set A and Set B contains elements:");
            Console.WriteLine(intersection.ToString());

            // test whether two sets are equal
            if (set1.IsEqualTo(set2))
                Console.WriteLine("\nSet A is equal to set B");
            else
                Console.WriteLine("\nSet A is not equal to set B");

            // test insert and delete
            Console.WriteLine("\nInserting 77 into set A...");
            set1.InsertElement(77);
            Console.WriteLine("\nSet A now contains elements:");
            Console.WriteLine(set1.ToString());

            Console.WriteLine("\nDeleting 77 from set A...");
            set1.DeleteElement(77);
            Console.WriteLine("\nSet A now contains elements:");
            Console.WriteLine(set1.ToString());

            // test constructor
            int[] intArray = { 25, 67, 2, 9, 99, 105, 45, -5, 100, 1 };
            IntegerSet set3 = new IntegerSet(intArray);

            Console.WriteLine("\nNew Set contains elements:");
            Console.WriteLine(set3.ToString());
        } 
        // end Main


        //method to create new object of IntegerSet type.
        private static IntegerSet InputSet(int[] intArray)
        {
            return new IntegerSet(intArray);
        }
    }
}
