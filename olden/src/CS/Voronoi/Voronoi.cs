
using System;


//*
// A Java implementation of the <tt>voronoi</tt> Olden benchmark. Voronoi
// generates a random set of points and computes a Voronoi diagram for
// the points.
// <p>
// <cite>
// L. Guibas and J. Stolfi.  "General Subdivisions and Voronoi Diagrams"
// ACM Trans. on Graphics 4(2):74-123, 1985.
// </cite>
// <p>
// The Java version of voronoi (slightly) differs from the C version
// in several ways.  The C version allocates an array of 4 edges and
// uses pointer addition to implement quick rotate operations.  The
// Java version does not use pointer addition to implement these
// operations.
//
public class Voronoi
{
	//*
   // The number of points in the diagram
   //
	private static int points = 0;
	//*
   // Set to true to print informative messages
   //
	private static bool printMsgs = false;
    //*
   // Set to true to print the voronoi diagram and its dual,
   // the delaunay diagram
   //
	private static bool printResults = false;

	//*
   // The main routine which creates the points and then performs
   // the delaunay triagulation.
   // @param args the command line parameters
   //
	public static void Main(string[] args)
	{
		parseCmdLine(args);
		
		if (printMsgs)
			System.Console.Out.WriteLine("Getting " + points + " points");
		
		var start0 = System.DateTime.Now;
		Vertex.seed = 1023;
		Vertex extra = Vertex.createPoints(1, new MyDouble(1.0), points);
		Vertex point = Vertex.createPoints(points - 1, new MyDouble(extra.X()), points - 1);
		var end0 = System.DateTime.Now;
		
		if (printMsgs)
			System.Console.Out.WriteLine("Doing voronoi on " + points + " nodes");
		
		var start1 = System.DateTime.Now;
		Edge edge = point.buildDelaunayTriangulation(extra);
		var end1 = System.DateTime.Now;
		
		if (printResults)
			edge.outputVoronoiDiagram();
		
		if (printMsgs)
		{
			System.Console.Out.WriteLine("Build time " + (end0.Subtract(start0).TotalMilliseconds) / 1000.0);
			System.Console.Out.WriteLine("Compute  time " + (end1.Subtract(start1).TotalMilliseconds) / 1000.0);
			System.Console.Out.WriteLine("Total time " + (end1.Subtract(start0).TotalMilliseconds) / 1000.0);
		}

        var slicingVariable1 = edge;
        var slicingVariable2 = edge.quadList;
        var slicingVariable3 = edge.quadList[0];
        var slicingVariable4 = edge.listPos;
        var slicingVariable5 = edge.vertex;
        var slicingVariable6 = edge.next;
        System.Console.Out.WriteLine("Done!");
	}

	//*
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
			
			if (arg.Equals("-n"))
			{
				if (i < args.Length)
				{
					points = System.Convert.ToInt32(args[i++]);
				}
				else
					throw new System.Exception("-n requires the number of points");
			}
			else if (arg.Equals("-p"))
			{
				printResults = true;
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
		if (points == 0)
			usage();
	}

	//*
   // The usage routine which describes the program options.
   //
	private static void usage()
	{
		System.Console.Error.WriteLine("usage: java Voronoi -n <points> [-p] [-m] [-h]");
		System.Console.Error.WriteLine("    -n the number of points in the diagram");
		System.Console.Error.WriteLine("    -p (print detailed results/messages - the voronoi diagram>)");
		System.Console.Error.WriteLine("    -v (print informative message)");
		System.Console.Error.WriteLine("    -h (this message)");
		System.Environment.Exit(0);
	}
}
