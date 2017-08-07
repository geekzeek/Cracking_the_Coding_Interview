using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Cracking the Coding Interview Chapter 2
class LinkedLists
{
    // 2.1 Write code to remove duplicates from an unsorted linked list.
    public static void RemoveDups<T>(LinkedList<T> list)
    {
        var node = list.First;
        HashSet<T> elements = new HashSet<T>();
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

    // 2.2 Implement an algorithm to find the nth to last element of a singly linked list.
    public static LinkedListNode<T> NthToLast<T>(LinkedList<T> list, int n)
    {
        int i;
        var current = list.First;
        for (i = 0; i < n; i++)
        {
            if (current.Next != null) current = current.Next;
            else return null;
        }
        return current;
    }

    // 2.3 Implement an algorithm to delete a node in the middle of a single linked list, given only access to that node.
    public static LinkedList<T> RemoveNode<T>(LinkedList<T> list, LinkedListNode<T> node)
    {
        list.Remove(node);
        return list;
    }

    // 2.4 You have two numbers represented by a linked list, where each node contains a single digit. 
    // The digits are stored in reverse order, such that the 1’s digit is at the head of the list. 
    // Write a function that adds the two numbers and returns the sum as a linked list.

    public static LinkedList<int> AddLists(LinkedList<int> list1, LinkedList<int> list2)
    {
        LinkedList<int> output = new LinkedList<int>();
        int sum = 0;
        for(int i = 0; i < Math.Max(list1.Count, list2.Count); i++)
        {
            sum += (list1.ElementAt(i) + list2.ElementAt(i)) * (int)Math.Pow(10, i);
            output.AddFirst(sum / (int)Math.Pow(10, i));
        }
        if(output.First.Value > 10)
        {
            output.First.Value %= 10;
            output.AddFirst(1);
        }
        return output;
    }
    // 2.5 Given a circular linked list, implement an algorithm which returns node at the beginning of the loop.
    public static LinkedListNode<T> FindLoopNode<T>(LinkedList<T> list)
    {
        LinkedListNode<T> node1 = list.First;
        LinkedListNode<T> node2 = list.First;

        while(node2.Next != null)
        {
            node1 = node1.Next;
            node2 = node2.Next.Next;
            if (node1 == node2) break;
        }

        if (node2.Next == null) return null;

        node1 = list.First;
        while(node1 != node2)
        {
            node1 = node1.Next;
            node2 = node2.Next;
        }
        return node2;
    }
}


