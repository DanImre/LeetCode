using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_399
    {
        public Medium_399()
        {

        }
        private class Node
        {
            public string variable;
            public Dictionary<string, (Node node, double mul)> connections;
            public Node(string variable, Dictionary<string, (Node node, double mul)> connections)
            {
                this.variable = variable;
                this.connections = connections;
            }
            public Node(string variable)
            {
                this.variable = variable;
                connections = new Dictionary<string, (Node node, double mul)>();
            }
        }
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            double[] solution = new double[queries.Count];

            Dictionary<string, Node> nodes = new Dictionary<string, Node>();
            for (int i = 0; i < equations.Count; i++)
            {
                Node left = null;
                if (nodes.ContainsKey(equations[i][0]))
                    left = nodes[equations[i][0]];
                else
                {
                    left = new Node(equations[i][0]);
                    nodes.Add(equations[i][0], left);
                }

                Node right = null;
                if (nodes.ContainsKey(equations[i][1]))
                    right = nodes[equations[i][1]];
                else
                {
                    right = new Node(equations[i][1]);
                    nodes.Add(equations[i][1], right);
                }

                if (left.connections.ContainsKey(equations[i][1]))
                    continue;

                left.connections.Add(equations[i][1], (right, values[i]));
                right.connections.Add(equations[i][0], (left, Math.Pow(values[i], -1)));
            }

            for (int i = 0; i < queries.Count; i++)
                if (nodes.ContainsKey(queries[i][0]) && nodes.ContainsKey(queries[i][1]))
                    solution[i] = Calc(nodes[queries[i][0]], nodes[queries[i][1]]);
                else
                    solution[i] = -1;

            return solution;
        }
        private double Calc(Node left, Node right)
        {
            Queue<(Node node, double mul)> q = new Queue<(Node node, double mul)>();
            q.Enqueue((left,1));

            HashSet<Node> visited = new HashSet<Node>();
            while(q.Count != 0)
            {
                var curr = q.Dequeue();
                if (!visited.Add(curr.node))
                    continue;

                if (curr.node.connections.ContainsKey(right.variable))
                    return curr.node.connections[right.variable].mul * curr.mul;

                foreach (var item in curr.node.connections)
                    q.Enqueue((item.Value.node, curr.mul * item.Value.mul));
            }

            return -1;
        }
    }
}
