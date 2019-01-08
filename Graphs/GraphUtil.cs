using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Graphs
{
    public class GraphUtil
    {
        private int numOfVertices;
        private List<GraphNode> adj;

        public GraphUtil(int v)
        {
            numOfVertices = v;
            adj = new List<GraphNode>();
            for (int i = 0; i < numOfVertices; i++)
                adj.Add(new GraphNode(i));
        }
        public GraphUtil(int v, char a)
        {
            numOfVertices = v;
            adj = new List<GraphNode>();
            for (int i = 0; i <= numOfVertices; i++)
                adj.Add(new GraphNode(a-'a'));
        }
        public void addEdge(GraphNode u, GraphNode v)
        {
            adj[u.Value].Add(v);
        }
        public GraphNode GetNode(int i)
        {
            return adj[i];
        }
        

    }

    public class GraphNode
    {
        int val;
        List<GraphNode> neighbours;
        public GraphNode(int v)
        {
            val = v;
            neighbours = new List<GraphNode>();
        }
        public int Value
        {
            get {return val;}
        }
        
        public void Add(GraphNode v)
        {
            neighbours.Add(v);
        }
        public List<GraphNode> Neighbours
        {
            get { return this.neighbours; }
        }
    }
}
