using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Assignment1_Summer2021
{
    class Program
    {
        static void Main(string[] args)
        { //Question 1 - Robot Program
            Console.WriteLine("Q1 : Enter the Moves of Robot:");
            string moves = Console.ReadLine();
            bool pos = JudgeCircle(moves);
            if (pos)
            {
                Console.WriteLine("The Robot return’s to initial Position (0,0)");
            }
            else
            {
                Console.WriteLine("The Robot doesn’t return to the Initial Postion (0,0)");
            }
            Console.WriteLine(); //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s = Console.ReadLine();
            bool flag = CheckIfPangram(s);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine(); //Question 3:
            int[] arr = { 1, 2, 3, 1, 1, 3 };
            int gp = NumIdenticalPairs(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("The number of IdenticalPairs in the array are {0}:", gp);
            //Question 4:
            int[] arr1 = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4:");
            int pivot = PivotIndex(arr1);
            if (pivot > 0)
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            Console.WriteLine(); //Question 5:
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            String merged = MergeAlternately(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);
            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();
        } /*
<summary>
/// Input: moves = "UD"
/// Output: true
/// Explanation: The robot moves up once, and then down once. All moves have the same ///magnitude, so it ended up at the origin where it started. Therefore, we return true.
</summary>
<retunrs>true/False</returns>
*/
        static bool JudgeCircle(string moves)
        {

            try
            {
                int a = 0;  // For up and down
                int b = 0;  // For right and left
                for (int i = 0; i < moves.Length; i++)
                {
                    if (moves[i] == 'U')
                    {
                        a = a + 1;  // If it goes Up the value increases by 1
                    }
                    if (moves[i] == 'D')
                    {
                        a = a - 1;   //If it goes down the value decreases by 1
                    }
                    if (moves[i] == 'L')
                    {
                        b = b - 1;   // If it goes Left the value decreases by 1
                    }
                    if (moves[i] == 'R')
                    {
                        b = b + 1;   // If it goes Right the value increases by 1
                    }
                }

                if (a == 0 && b == 0)
                { //If both a and b are 0 then the boolean is true
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }

        }/*
<summary>
A pangram is a sentence where every letter of the English alphabet appears at least once.
Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
Example 1:
Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
Output: true
Explanation: sentence contains at least one of every letter of the English alphabet.
</summary>
</returns> true/false </returns>
Note: Use of String function (Contains) and hasmap is not allowed, think of other ways how you could the numbers be represented
*/
        static bool CheckIfPangram(string s)
        {

            int i = 0;
            try
            {
                string alphabets = "abcdefghijklmnopqrstuvwxyz";
                foreach (char x in alphabets)
                { //loop through each char in alphabets
                    foreach (char y in s.ToLower())
                    {  //loop through each char from input
                        if (x == y)
                        {  //comparing both characters
                            i = i + 1;
                            break;
                        }
                    }
                }

                if (i == 26)   //If count is 26 as the num of alplabets is 26 return true
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* <summary>
        Given an array of integers nums
        A pair (i,j) is called good if nums[i] == nums[j] and i < j.
        Return the number of good pairs.
        Example:
        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        return type : int
        </summary>
        <returns>int </returns>
        */
        static int NumIdenticalPairs(int[] arr)
        {
            try
            {
                int total = 0;
                for (int i = 0; i < arr.Length - 1; i++)  //Looping through the input array  with starting from first element
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    //Looping thorugh the array element to check the next element in array
                    {
                        if (arr[i] == arr[j])
                            total++; // If both the elements are then increment the total
                    }
                }
                return total;

            }
            catch (Exception)
            {
                throw;
            }
        }
        /* <summary>
        Given an array of integers nums, calculate the pivot index of this array.The pivot index is the index where the sum of all the numbers strictly to the left of the index is equal to the sum of all the numbers strictly to the index's right.
        If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the right edge of the array.
        Return the leftmost pivot index. If no such index exists, return -1.
        Example 1:
        Input: nums = [1,7,3,6,5,6]
        Output : 3
        Explanation:
        The pivot index is 3.
        Left sum = nums[0] + nums[1] + nums[2] = 1 + 7 + 3 = 11
        Right sum = nums[4] + nums[5] = 5 + 6 = 11
        /// </summary>
        /// <param name="nums"></param>
        /// <returns>Number the index in the array</returns>
        */
        private static int PivotIndex(int[] nums)
        {
            try
            {
                int sum = 0;
                foreach (int i in nums)
                { //Calculated the sum of all elements in the array
                    sum = sum + i;
                }
                int sumLeft = 0;
                for (int x = 0; x < nums.Length; x++)
                {
                    if (sum - nums[x] == 2 * sumLeft)
                    {  //totalsum - pivot index value will be equal to the left over sum
                        return x;
                    }
                    sumLeft = sumLeft + nums[x];
                }
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }
        } /*
/// <summary>
/// You are given two strings word1 and word2. Merge the strings by adding letters /// in alternating order, starting with word1. If a string is longer than the other,
/// append the additional letters onto the end of the merged string.
/// Example 1
/// Input: word1 = "abc", word2 = "pqr"
/// Output: "apbqcr"
/// Explanation: The merged string will be merged as so:
/// word1: a b c
/// word2: p q r
/// merged: a p b q c r
/// </summary>
/// <param name="word1"></param>
///<param name="word2"></param>
/// <returns>return the merged string </returns> */
        private static string MergeAlternately(string word1, string word2)
        {
            try
            {
                string mergedString = "";
                for (int i = 0; i < word1.Length || i < word2.Length; i++)   //Looping based on both the strings
                {
                    if (i < word1.Length)
                    {
                        mergedString = mergedString + word1[i];  //Adding ith element of string a to mergedString
                    }
                    if (i < word2.Length)
                    {
                        mergedString = mergedString + word2[i];  //Adding ith element of string b to mergedString
                    }
                }
                return mergedString;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        } /*
<summary>
/// A sentence sentence is given, composed of words separated by spaces. Each word consists of lowercase and uppercase letters only.
We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.)
The rules of Goat Latin are as follows:
1) If a word begins with a vowel (a, e, i, o, or u), append "ma" to the end of the word.
For example, the word 'apple' becomes 'applema'. 2) If a word begins with a consonant (i.e. not a vowel), remove the first letter and append it to the end, then add "ma".
For example, the word "goat" becomes "oatgma". 3) Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
For example, the first word gets "a" added to the end, the second word gets "aa" added to the end and so on.
Hint : think of a string function to divide the sentence on white spaces
/// </summary>
/// <param name="sentence"></param>
/// <returns> string</returns>
*/
        private static string ToGoatLatin(string sentence)
        {
            try
            {
                StringBuilder sb = new StringBuilder();  //Using string Builder so that it increases the string concatination performance
                string[] splitArr = sentence.Split(" ");
                int x = 1;
                foreach (string str in splitArr)
                {
                    if ("aeiou".Contains(char.ToLower(str[0])))  //If contains vowel
                    {
                        sb.Append(str + "ma" + string.Concat(Enumerable.Repeat("a", x)).ToString() + " "); //Adding ma at the end and changing it t0 lower

                        }
                    else if (!str.Contains("aeiouAEIOU"))  //If not vowel removing first letter and adding it at the last with ma
                    {
                        sb.Append(str.Substring(1, str.Length - 1) + str.Substring(0, 1) + "ma" + string.Concat(Enumerable.Repeat("a", x)) + " ");
                        x++;
                    }
                }
                return sb.ToString().Trim(); //Remving the space from end and changing it to string
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

