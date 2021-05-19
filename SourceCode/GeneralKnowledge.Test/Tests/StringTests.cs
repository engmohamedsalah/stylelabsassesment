using System;
using System.Collections.Generic;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {
        public void Run()
        {
            // TODO
            // Complete the methods below

            AnagramTest();
            GetUniqueCharsAndCount();
        }

        /// <summary>
        /// testing anagram 
        /// </summary>
        /// <remarks></remarks>
        private void AnagramTest()
        {
            var word = "stop";
            var possibleAnagrams = new string[] { "test", "tops", "spin", "post", "mist", "step" };

            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine(string.Format("{0} > {1}: {2}", word, possibleAnagram, possibleAnagram.IsAnagram(word)));
            }
        }

        /// <summary>
        /// count the Unique chars
        /// Algorithm is time complexity O(N)
        /// </summary>
        /// <remarks></remarks>
        private void GetUniqueCharsAndCount()
        {
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzz";
            // TODO
            // Write an algorithm that gets the unique characters of the word below 
            // and counts the number of occurrences for each character found
            var charCntDic = new Dictionary<char, int>();

            //loop on the chars in the word
            for (int i = 0; i < word.Length; i++)
            {
                //if the char is counted before then increase the number
                if (charCntDic.ContainsKey(word[i]))
                    charCntDic[word[i]]++;
                else // if the char is new then added to dictionary
                    charCntDic.Add(word[i], 1);
            }
            //loop on dictionary and print the result
            foreach (var row in charCntDic)
            {
                Console.WriteLine("Char = {0} , Count = {1}", row.Key, row.Value);
            }
        }

    }
    /// <summary>
    /// extension for string to check if the two string are anagram or not
    /// /// Algorithm is time complexity O(N)
    /// </summary>
    /// <remarks></remarks>
    public static class StringExtensions
    {
        public static bool IsAnagram(this string a, string b)
        {
            // TODO
            // Write logic to determine whether a is an anagram of b
            //check the length of both string if not euqal then return false
            if (a.Length != b.Length)
                return false;
            else
            {
                //dictionary will collect the number of char occurance
                //for string a
                var charCntDic = new Dictionary<char, int>();
                for (int i = 0; i < a.Length; i++)
                {
                    if (charCntDic.ContainsKey(a[i]))
                        charCntDic[a[i]]++;
                    else
                        charCntDic.Add(a[i], 1);
                }
                //try to remove occurance of string b from dic 
                //if the count become less than 0 then 
                //this is not anagram
                //if it could remove all chars and if dic became empty
                //then the two strings are anagram
                for (int i = 0; i < a.Length; i++)
                {


                    if (charCntDic.ContainsKey(b[i]) && charCntDic[b[i]]>0)
                        charCntDic[b[i]]--;
                    else
                        return false;

                }
                //make sure that dic has no char
                foreach (var row in charCntDic)
                {
                    if (row.Value != 0)
                        return false;
                }
            }

            return true;
        }
    }
}
