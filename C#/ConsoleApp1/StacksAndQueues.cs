using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StacksAndQueues
{
    // 3.2 How would you design a stack which, in addition to push and pop, also has a function min which returns the minimum element? 
    // Push, pop and min should all operate in O(1) time.
    class StackWithMin
    {
        class thisNode
        {
            public int value;
            public int minBelow = int.MaxValue;
        }

        Stack<thisNode> thisStack = new Stack<thisNode>();

        public void push(int value)
        {
            thisNode newNode = new thisNode();
            newNode.value = value;
            if (thisStack.Count == 0)
            {
                newNode.minBelow = value;
            }
            else
            {
                newNode.minBelow = Math.Min(value, thisStack.Peek().minBelow);
            }
            thisStack.Push(newNode);
        }

        public int pop()
        {
            return thisStack.Pop().value;
        }


        public int min()
        {
            return thisStack.Peek().minBelow;
        }

    }

    // 3.5 Implement a MyQueue class which implements a queue using two stacks.
    class MyQueue<T>
    {
        Stack<T> s1 = new Stack<T>();
        Stack<T> s2 = new Stack<T>();

        public void push(T value)
        {
            s1.Push(value);
        }

        public T pop()
        {
            if (s2.Count == 0) UpdateStacks();
            return s2.Pop();
        }

        public T peek()
        {
            if (s2.Count == 0) UpdateStacks();
            return s2.Peek();
        }

        public int Count()
        {
            return s1.Count + s2.Count;
        }

        private void UpdateStacks()
        {
            while (s1.Count < 0)
            {
                s2.Push(s1.Pop());
            }
        }
    }

    // 3.6 Write a program to sort a stack in ascending order.You should not make any assumptions about how the stack is implemented.
    // The following are the only functions that should be used to write this program: push | pop | peek | isEmpty.
    
    public Stack<T> SortStackAscending<T>(Stack<T> stack)
    {
        List<T> buffer = new List<T>();
        while(stack.Count > 0) // equivalent to isEmpty()
        {
            buffer.Add(stack.Pop());
        }

        buffer.Sort();

        while(buffer.Count > 0)
        {
            stack.Push(buffer.First());
            buffer.Remove(buffer.First());
        }
        return stack;
    }
}


