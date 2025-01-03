using System.Collections;

namespace DsAlRankToGlory.DataStructures;

public class Graph<T> : IEnumerable<T>
	{
		#region Private Members

		private NodeList<T> nodeSet;

		#endregion Private Members

		#region Constructors

		public Graph() : this(null) { }

		public Graph(NodeList<T> nodeSet)
		{
			if (nodeSet == null)
			{
				this.nodeSet = new NodeList<T>();
			}
			else
			{
				this.nodeSet = nodeSet;
			}
		}

		#endregion Constructors

		#region Public Interface

		public void AddNode(GraphNode<T> node)
		{
			nodeSet.Add(node);
		}

		public void AddNode(T value)
		{
			nodeSet.Add(new GraphNode<T>(value));
		}

		public void AddDirectedEdge(T from, T to)
		{
			this.AddDirectedEdge(from, to, 0);
		}

		public void AddDirectedEdge(T from, T to, int cost)
		{
			GraphNode<T> fromNode = (GraphNode<T>)this.nodeSet.FindByValue(from);
			GraphNode<T> toNode = (GraphNode<T>)this.nodeSet.FindByValue(to);

			if (fromNode == null)
			{
				fromNode = new GraphNode<T>(from);
			}

			if (toNode == null)
			{
				toNode = new GraphNode<T>(to);
			}

			this.AddDirectedEdge(fromNode, toNode, cost);
		}


		public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to)
		{
			AddDirectedEdge(from, to, 0);
		}

		public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
		{
			from.Neighbors.Add(to);
			from.Costs.Add(cost);
		}

		public void AddUndirectedEdge(T from, T to)
		{
			this.AddUndirectedEdge(from, to, 0);
		}

		public void AddUndirectedEdge(T from, T to, int cost)
		{
			GraphNode<T> fromNode = (GraphNode<T>)nodeSet.FindByValue(from);
			GraphNode<T> toNode = (GraphNode<T>)nodeSet.FindByValue(to);

			if (fromNode == null)
			{
				fromNode = new GraphNode<T>(from);
			}

			if (toNode == null)
			{
				toNode = new GraphNode<T>(to);
			}

			this.AddUndirectedEdge(fromNode, toNode, cost);
		}

		public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to)
		{
			this.AddUndirectedEdge(from, to, 0);
		}

		public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
		{
			from.Neighbors.Add(to);
			from.Costs.Add(cost);

			to.Neighbors.Add(from);
			to.Costs.Add(cost);
		}

		public bool Contains(T value)
		{
			return this.nodeSet.FindByValue(value) != null;
		}

		public bool Remove(T value)
		{
			GraphNode<T> nodeToRemove = (GraphNode<T>)this.nodeSet.FindByValue(value);

			if (nodeToRemove == null)
			{
				return false;
			}

			this.nodeSet.Remove(nodeToRemove);

			foreach (GraphNode<T> node in this.nodeSet)
			{
				int index = node.Neighbors.IndexOf(nodeToRemove);

				if (index != -1)
				{
					node.Neighbors.RemoveAt(index);
					node.Costs.RemoveAt(index);
				}

			}

			return true;
		}

		public NodeList<T> NodeSet
		{
			get { return this.nodeSet; }
		}

		public int Count
		{
			get { return this.nodeSet.Count; }
		}

		#endregion Public Interface

		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}