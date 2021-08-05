using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs;

namespace Sorts
{
    public class TopologicalSort
    {
        
        public TopologicalSort(int v)
        {
            Stack<int> st = new Stack<int>();
            GraphUtil graph = MakeGraph(v);
            bool[] visited = new bool[v];
            for (int i = 0; i < v; i++)
            {
                if (!visited[i])
                    EnhancedDFS(i, visited, graph, st);
            }
            
            while (st.Count > 0)
                Console.Write(st.Pop() + " ");
        }
        public TopologicalSort(string[] words, int k)
        {
            Stack<int> st = new Stack<int>();
            GraphUtil graph = new GraphUtil(k);
            bool[] visited = new bool[k];
            for (int i = 1; i < words.Length; i++)
            {
                for (int j = 0; j < Math.Min(words[i - 1].Length, words[i].Length); j++)
                {
                    if (words[i - 1][j] != words[i][j])
                    {
                        graph.addEdge(graph.GetNode(words[i - 1][j] - 'a'), graph.GetNode(words[i][j] - 'a'));
                        break;
                    }
                }
            }
            for (int i = 0; i < k; i++)
            {
                if (!visited[i])
                    EnhancedDFS(i, visited, graph, st);
            }
            while (st.Count > 0)
                Console.Write((char)(st.Pop()+'a') + " ");
        }

        private void EnhancedDFS(int i, bool[] visited, GraphUtil graph, Stack<int> st)
        {
            // new NotImplementedException();
            visited[i] = true;
            foreach (GraphNode node in graph.GetNode(i).Neighbours)
            {
                int j = node.Value;
                if (!visited[j])
                    EnhancedDFS(j, visited, graph, st);
            }
            st.Push(i);
        }

        public GraphUtil MakeGraph(int v)
        {
            GraphUtil graph = new GraphUtil(v);
            graph.addEdge(graph.GetNode(5), graph.GetNode(2));
            graph.addEdge(graph.GetNode(5), graph.GetNode(0));
            graph.addEdge(graph.GetNode(4), graph.GetNode(0));
            graph.addEdge(graph.GetNode(4), graph.GetNode(1));
            graph.addEdge(graph.GetNode(2), graph.GetNode(3));
            graph.addEdge(graph.GetNode(3), graph.GetNode(1));
            return graph;
        }

    }
}
