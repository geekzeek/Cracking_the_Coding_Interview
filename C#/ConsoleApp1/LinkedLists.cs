using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Cracking the Coding Interview Chapter 2
class LinkedLists
{
    // 2.1 Write code to remove duplicates from an unsorted linked list.
    public static void removeDups(LinkedList<string> list)
    {
        var node = list.First;
        HashSet<string> elements = new HashSet<string>();
        elements.Add(node.Value);
        while (node.Next != null)
        {
            var current = node.Next;
            if (elements.Contains(current.Value))
            {
                list.Remove(current);
            }
            else
            {
                elements.Add(current.Value);
            }
        }
    }
}
