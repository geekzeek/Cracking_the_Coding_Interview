using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Cracking the Coding Interview Chapter 1
class ArraysAndStrings
{
    // 1.1 Implement an algorithm to determine if a string has all unique characters.
    public static bool isUniqueChars(string word)
    {
        bool[] charSet = new bool[256];
        foreach (char letter in word)
        {
            if (charSet[(int)letter])
            {
                return false;
            }
            else charSet[(int)letter] = true;
        }
        return true;
    }

    // 1.2 Write code to reverse a C-Style String.
    public static string reverse(string word)
    {
        int i = 0;
        string output = "";
        for (i = word.Length - 1; i >= 0; i--)
        {
            output += word[i];
        }
        Console.WriteLine(output);
        return output;
    }

    // 1.4 Write a method to decide if two strings are anagrams or not.
    public static bool isAnagram(string word1, string word2)
    {
        if (word1.Length != word2.Length) return false;
        char[] chars1, chars2;
        chars1 = word1.ToCharArray();
        chars2 = word2.ToCharArray();
        Array.Sort(chars1);
        Array.Sort(chars2);
        return String.Equals(new string(chars1), new string(chars2));
    }
}
