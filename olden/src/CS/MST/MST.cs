using System;

//
// A Java implementation of the <tt>mst</tt> Olden benchmark.  The Olden
// benchmark computes the minimum spanning tree of a graph using
// Bentley's algorithm.
// <p><cite>
// J. Bentley. "A Parallel Algorithm for Constructing Minimum Spanning Trees"
// J. of Algorithms, 1:51-59, 1980.
// </cite>
// <p>
// As with the original C version, this one uses its own implementation
// of hashtable.
//
public class MST
{
	//
   // The number of vertices in the graph.
   //
	private static int vertices = 0;
	//
   // Set to true to print the final result.
   //
	private static bool printResult = false;
	//
   // Set to true to print information messages and timing values
   //
	private static bool printMsgs = false;

	public static void Main(string[] args)
	{
		parseCmdLine(args);
		
		if (printMsgs)
			System.Console.Out.WriteLine("Making graph of size " + vertices);
		var start0 = System.DateTime.Now;
		Graph graph = new Graph(vertices);
		var end0 = System.DateTime.Now;
		
		if (printMsgs)
			System.Console.Out.WriteLine("About to compute MST");
		var start1 = System.DateTime.Now;
		int dist = computeMST(graph, vertices);
		var end1 = System.DateTime.Now;
		
		if (printResult || printMsgs)
			System.Console.Out.WriteLine("MST has cost " + dist);
		
		if (printMsgs)
		{
			System.Console.Out.WriteLine("Build graph time " + (end0.Subtract(start0).TotalMilliseconds) / 1000.0);
			System.Console.Out.WriteLine("Compute time " + (end1.Subtract(start1).TotalMilliseconds) / 1000.0);
			System.Console.Out.WriteLine("Total time " + (end1.Subtract(start0).TotalMilliseconds) / 1000.0);
		}

        var slicingVariable1 = dist;
		System.Console.WriteLine("Done!");
	}

	//
  // The method to compute the minimum spanning tree.
  // @param graph the graph data structure 
  // @param numvert the number of vertices in the graph
  // @return the minimum spanning tree cost
  //
	internal static int computeMST(Graph graph, int numvert)
	{
		int cost = 0;
		
		// Insert first node
		Vertex inserted = graph.firstNode();
		Vertex tmp = inserted.Next();
		MyVertexList = tmp;
		numvert--;
		
		// Annonunce insertion and find next one
		while (numvert != 0)
		{
			//System.out.println("numvert= " +numvert);
			BlueReturn br = doAllBlueRule(inserted);
			inserted = br.getVert();
			int dist = br.getDist();
			numvert--;
			cost += dist;
		}
		return cost;
	}

	private static BlueReturn BlueRule(Vertex inserted, Vertex vlist)
	{
		BlueReturn retval = new BlueReturn();
		
		if (vlist == null)
		{
			retval.setDist(999999);
			return retval;
		}
		
		Vertex prev = vlist;
		retval.setVert(vlist);
		retval.setDist(vlist.Mindist());
		Hashtable hash = vlist.Neighbors();
		object o = hash.get(inserted);
		if (o != null)
		{
			int dist = ((int)o);
			if (dist < retval.getDist())
			{
				vlist.setMindist(dist);
				retval.setDist(dist);
			}
		}
		else
			System.Console.WriteLine("Not found");
		
		int count = 0;
		// We are guaranteed that inserted is not first in list
		for (Vertex tmp = vlist.Next(); tmp != null; prev = tmp, tmp = tmp.Next())
		{
			count++;
			if (tmp == inserted)
			{
				Vertex next = tmp.Next();
				prev.SetNext(next);
			}
			else
			{
				hash = tmp.Neighbors();
				int dist2 = tmp.Mindist();
				o = hash.get(inserted);
				if (o != null)
				{
					int dist = ((int)o);
					if (dist < dist2)
					{
						tmp.setMindist(dist);
						dist2 = dist;
					}
				}
				else
					System.Console.WriteLine("Not found");
				
				if (dist2 < retval.getDist())
				{
					retval.setVert(tmp);
					retval.setDist(dist2);
				}
			}
		}
		return retval;
	}

	private static Vertex MyVertexList = null;

	private static BlueReturn doAllBlueRule(Vertex inserted)
	{
		if (inserted == MyVertexList)
			MyVertexList = MyVertexList.Next();
		return BlueRule(inserted, MyVertexList);
	}

	//
  // Parse the command line options.
  // @param args the command line options.
  //
	private static void parseCmdLine(string[] args)
	{
		int i = 0;
		string arg;
		while (i < args.Length && args[i].StartsWith("-"))
		{
			arg = args[i++];
			if (arg.Equals("-v"))
			{
				if (i < args.Length)
				{
					vertices = System.Convert.ToInt32(args[i++]);
				}
				else
					throw new System.Exception("-v requires the number of vertices");
			}
			else if (arg.Equals("-p"))
			{
				printResult = true;
			} 
			else if (arg.Equals("-m"))
			{
				printMsgs = true;
			}
			else if (arg.Equals("-h"))
			{
				usage();
			}
		}
		if (vertices == 0)
			usage();
	}

	//
  // The usage routine which describes the program options.
  //
	private static void usage()
	{
		System.Console.Error.WriteLine("usage: java MST -v <levels> [-p] [-m] [-h]");
		System.Console.Error.WriteLine("    -v the number of vertices in the graph");
		System.Console.Error.WriteLine("    -p (print the result>)");
		System.Console.Error.WriteLine("    -m (print informative messages)");
		System.Console.Error.WriteLine("    -h (this message)");
		System.Environment.Exit(0);
	}
}

//
// Not really sure what this is for?
//
internal class BlueReturn
{
	private Vertex vert;
	private int dist;

	public virtual Vertex getVert()
	{
		return vert;
	}

	public virtual void setVert(Vertex v)
	{
		vert = v;
	}

	public virtual int getDist()
	{
		return dist;
	}

	public virtual void setDist(int d)
	{
		dist = d;
	}
}
