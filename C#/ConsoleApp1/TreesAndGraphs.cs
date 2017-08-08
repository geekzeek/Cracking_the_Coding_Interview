using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TreesAndGraphs
{
    public class TreeNode<T>
    {
        public T value = default(T);
        public List<TreeNode<T>> adjacent = new List<TreeNode<T>>();
    }

    // 4.1 Implement a function to check if a tree is balanced. For the purposes of this question, 
    // a balanced tree is defined to be a tree such that no two leaf nodes differ in distance from the root by more than one.
    public bool isBalanced<T>(TreeNode<T> root)
    {
        return (maxDepth(root) - minDepth(root)) <= 1;
    }

    private int minDepth<T>(TreeNode<T> node)
    {
        if (node == null) return 0;
        int min = int.MaxValue;
        foreach(TreeNode<T> child in node.adjacent)
        {
            min = Math.Min(min, minDepth(child));
        }
        return 1 + min;
    }

    private int maxDepth<T>(TreeNode<T> node)
    {
        if (node == null) return 0;
        int max = int.MinValue;
        foreach(TreeNode<T> child in node.adjacent)
        {
            max = Math.Max(max, maxDepth(child));
        }
        return 1 + max;
    }

    // 4.2 Given a directed graph, design an algorithm to find out whether there is a route between two nodes.
    public enum State { visited, unvisited, visiting }
    public class GraphNode<T>
    {
        public T value;
        public State state = State.unvisited;
        public List<GraphNode<T>> adjacent;

    }

    public bool routeExists<T>(GraphNode<T> start, GraphNode<T> end)
    {
        Stack<GraphNode<T>> q = new Stack<GraphNode<T>>();
        GraphNode<T> current;
        start.state = State.visiting;
        q.Push(start);
        while(q.Count > 0)
        {
            current = q.Pop();
            if(current != null)
            {
                foreach(GraphNode<T> adjacent in current.adjacent)
                {
                    if(adjacent.state == State.unvisited)
                    {
                        if (adjacent == end) return true;
                        else
                        {
                            adjacent.state = State.visiting;
                            q.Push(adjacent);
                        }
                    }
                }
                current.state = State.visited;
            }
        }
        return false;
    }

}

