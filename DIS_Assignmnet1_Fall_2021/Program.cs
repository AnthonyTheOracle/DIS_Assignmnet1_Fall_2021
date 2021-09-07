using System;
using System.Collections.Generic;
using System.Linq;

namespace DIS_Assignmnet1_Fall_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Question 1
            Console.WriteLine("Q1 : Enter the string:");
            string s = Console.ReadLine();
            bool pos = HalvesAreAlike(s);
            if (pos)
            {
                Console.WriteLine("Both Halfs of the string are alike");
            }
            else
            {
                Console.WriteLine("Both Halfs of the string are not alike");
            }

            Console.WriteLine();
            
            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s1 = Console.ReadLine();
            bool flag = CheckIfPangram(s1);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();
            
            //Question 3:
            int[,] arr = new int[,] { { 1, 2, 3 }, { 3, 2, 1 } };
            int Wealth = MaximumWealth(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("Richest person has a wealth of {0}", Wealth);
            
            //Question 4:
            string jewels = "aA";
            string stones = "aAAbbbb";
            Console.WriteLine("Q4:");
            int num = NumJewelsInStones(jewels, stones);
            Console.WriteLine("the number of stones you have that are also jewels are {0}:", num);
            Console.WriteLine();
            
            
            //Question 5:
            Console.WriteLine("Q5:");
            string word2 = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            string rotated_string = RestoreString(word2, indices);
            Console.WriteLine("The Final string after rotation is {0}", rotated_string);
            
            
            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            int[] nums = { 0, 1, 2, 3, 4 };
            int[] index = { 0, 1, 2, 2, 1 };
            int[] target = CreateTargetArray(nums, index);
            
            Console.WriteLine("Target array  for the Given array's is:");
            for (int i = 0; i < target.Length; i++)
            {
                Console.Write(target[i] + "\t");
            }
            Console.WriteLine();
            */
            /**/

        }

        //Q1
        public static bool HalvesAreAlike(string s)
        {
            //initialize valid vowels for this excersize
            var vowels = new HashSet<char>(new char[] { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' });

            //get mid point of string in order to separate string into two equal halfs
            var mid = s.Length / 2;

            //call the method CountVowels and return the number of vowels in first half
            //and second half of string
            var firstHalf = CheckVowel(0, mid);
            var secondHalf = CheckVowel(mid, mid);

            //if comparison values is not the same bases on vowels counted
            //return false else return true
            return firstHalf == secondHalf;

            //method used to check for equality of vowels
            int CheckVowel(int start, int length)
            {
                int count = 0;
                for (int i = start; i < start + length; i++)
                    if (vowels.Contains(s[i])) count++;

                return count;
            }
        }

        //Q2
        public static bool CheckIfPangram(string sentence)
        {
            // mark would be false.
            bool[] mark = new bool[26];

            // For indexing in mark[]
            int index = 0;

            // Traverse all characters
            for (int i = 0; i < sentence.Length; i++)
            {

                if ('A' <= sentence[i] && sentence[i] <= 'Z')
                    index = sentence[i] - 'A';

                else if ('a' <= sentence[i] && sentence[i] <= 'z')
                    index = sentence[i] - 'a';

                else
                    continue;

                mark[index] = true;
            }

            for (int i = 0; i <= 25; i++)
                if (mark[i] == false)
                    return (false);

            // If all characters
            // were present
            return (true);
        }

        //Q3
        public static int MaximumWealth(int[,] accounts)
        {
            int[] wealthArray = new int[accounts.GetLength(0)];
            int richestAccount = 0;
            for (int i=0;i<accounts.GetLength(0); i++)
            {
                for(int j = 0; j < accounts.GetLength(1); j++)
                {
                    wealthArray[i] += accounts[i, j];
                }
            }
            richestAccount = wealthArray[0];
            for (int i =0; i<wealthArray.Length; i++)
            {
                if (richestAccount < wealthArray[i])
                {
                    richestAccount = wealthArray[i];
                }
            }
            return richestAccount;
        }

        //Q4
        public static int NumJewelsInStones(string jewels, string stones)
        {
            Dictionary<char, int> myDict = new Dictionary<char, int>();
            foreach (char el in jewels) myDict.Add(el, 0);
            foreach (char el in stones)
            {
                if (myDict.ContainsKey(el)) myDict[el]++;
            }

            return myDict.Values.Sum();
        }

        //Q5
        public static string RestoreString(string s, int[] indices)
        {
            if (String.IsNullOrEmpty(s))
                return "";

            char[] shufflearr = new char[s.Length];
            for (int i = 0; i < indices.Length; i++)
            {
                shufflearr[indices[i]] = s[i];
            }

            //return new String(shufflearr);
            return new String(shufflearr);
        }

        //Q6
        public static int[] CreateTargetArray(int[] nums, int[] index)
        {
            int[] targetArray = new int[nums.Length];
            for (int i = 0; i < nums.Length; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (index[j] >= index[i])
                    {
                        ++index[j];
                    }
                }
            }
            for(int i = 0; i < nums.Length; i++)
            {
                targetArray[index[i]] = nums[i];
            }
            return targetArray;
        }

    }
}

