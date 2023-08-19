namespace TopologicalSorting
{
    public class Graph
    {
        // No. of vertices
        private int V;

        // Adjacency List as ArrayList
        private List<List<int>> adj;

        Graph(int v)
        {
            V = v;
            adj = new List<List<int>>(v);
            for (int i = 0; i < v; i++)
                adj.Add(new List<int>());
        }

        // Function to add an edge into the graph
        public void AddEdge(int v, int w) { adj[v].Add(w); }

        // A recursive function used by topologicalSort
        void TopologicalSortUtil(int v, bool[] visited, Stack<int> stack)
        {
            // Mark the current node as visited.
            visited[v] = true;

            // Recursive for all the vertices adjacent to this vertex
            foreach (var vertex in adj[v])
            {
                if (!visited[vertex])
                    TopologicalSortUtil(vertex, visited, stack);
            }

            // Push current vertex to stack which stores result
            stack.Push(v);
        }

        // The function to do Topological Sort
        void TopologicalSort()
        {
            Stack<int> stack = new Stack<int>();
            // Mark all the vertices as not visited
            var visited = new bool[V];

            // Call the recursive function to store Topological Sort starting from all vertices one by one
            for (int i = 0; i < V; i++)
            {
                if (visited[i] == false)
                    TopologicalSortUtil(i, visited, stack);
            }

            foreach (var vertex in stack)
            {
                Console.Write(vertex + " ");
            }
        }

        public static void Main(string[] args)
        {
            //Create a graph given in the above diagram
            Graph g = new Graph(6);
            g.AddEdge(5, 2);
            g.AddEdge(5, 0);
            g.AddEdge(4, 0);
            g.AddEdge(4, 1);
            g.AddEdge(2, 3);
            g.AddEdge(3, 1);

            Console.WriteLine("Topological sort");
            g.TopologicalSort();

            Console.ReadKey();
        }
    }
}