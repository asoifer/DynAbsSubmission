using System;
using System.Collections.Generic;
using System.Text;

//
// Java implementation of the <tt>em3d</tt> Olden benchmark.  This Olden
// benchmark models the propagation of electromagnetic waves through
// objects in 3 dimensions. It is a simple computation on an irregular
// bipartite graph containing nodes representing electric and magnetic
// field values.
// <p><cite>
// D. Culler, A. Dusseau, S. Goldstein, A. Krishnamurthy, S. Lumetta, T. von
// Eicken and K. Yelick. "Parallel Programming in Split-C".  Supercomputing
// 1993, pages 262-273.
// </cite>
//
public class Em3d
{
	//
   // The number of nodes (E and H) 
   //
	static int nodect = 0;
	//
   // The out-degree of each node.
   //
	static int conn = 0;
	//
	// The number of compute iterations 
    //
	static int numiter = 0;
	//
	// Should we print the results and other runtime messages
	//
	private static bool printResult = false;
	//
    // Print information messages?
    //
	private static bool printMsgs = false;

	//
	// The main roitine that creates the irregular, linked data structure
	// that represents the electric and magnetic fields and propagates the
	// waves through the graph.
	// @param args the command line arguments
	//
	public static void Main(String[] args)
	{
		parseCmdLine(args);

		if(printMsgs)
			Console.WriteLine("Initializing em3d random graph...");
		var start0 = DateTime.Now;
		BiGraph graph = BiGraph.create(nodect, conn, printResult);
		var end0 = DateTime.Now;
		
		// compute a single iteration of electro-magnetic propagation
		if(printMsgs)
			Console.WriteLine("Propagating field values for " + numiter + " iteration(s)...");
		var start1 = DateTime.Now;
		for(int i = 0; i < numiter; i++)
			graph.compute();
		var end1 = DateTime.Now;
		
		// print current field values
		if(printResult)
			System.Console.WriteLine(graph.toString());

		if (printMsgs) 
		{
		  Console.WriteLine("EM3D build time " + (end0.Subtract(start0).TotalMilliseconds)/1000.0);
		  Console.WriteLine("EM3D compute time " + (end1.Subtract(start1).TotalMilliseconds)/1000.0);
		  Console.WriteLine("EM3D total time " + (end1.Subtract(start0).TotalMilliseconds)/1000.0);
		}
        var slicingVariable1 = graph.eNodes.value;
        var slicingVariable2 = graph.eNodes.coeffs;
        var slicingVariable3 = graph.eNodes.coeffs[0];
        var slicingVariable4 = graph.eNodes.fromCount;
        var slicingVariable5 = graph.eNodes.fromLength;
        Console.WriteLine("Done!");
	}

	//
    // Parse the command line options.
    // @param args the command line options.
    //
	private static void parseCmdLine(String[] args)
	{
		int i = 0;
		String arg;

		while(i < args.Length && args[i].StartsWith("-"))
		{
			arg = args[i++];

			// check for options that require arguments
			if(arg.Equals("-n"))
			{
				if(i < args.Length)
				{
					nodect = Int32.Parse(args[i++]);
				}
				else 
					throw new Exception("-n requires the number of nodes");
			}
			else if(arg.Equals("-d"))
			{
				if(i < args.Length)
				{
					conn = Int32.Parse(args[i++]);
				}
				else 
					throw new Exception("-d requires the out degree");
			}
			else if(arg.Equals("-i"))
			{
				if(i < args.Length)
				{
					numiter = Int32.Parse(args[i++]);
				}
				else 
					throw new Exception("-i requires the number of iterations");
			}
			else if(arg.Equals("-p"))
			{
				printResult = true;
			}
			else if(arg.Equals("-m"))
			{
				printMsgs = true;
			}
			else if(arg.Equals("-h"))
			{
				usage();
			}
		}
		if(nodect == 0 || conn == 0)
			usage();
	}

	//
	// The usage routine which describes the program options.
	//
	private static void usage()
	{
		Console.WriteLine("usage: java Em3d -n <nodes> -d <degree> [-p] [-m] [-h]");
		Console.WriteLine("    -n the number of nodes");
		Console.WriteLine("    -d the out-degree of each node");
		Console.WriteLine("    -i the number of iterations");
		Console.WriteLine("    -p (print detailed results)");
		Console.WriteLine("    -m (print informative messages)");
		Console.WriteLine("    -h (this message)");
		System.Environment.Exit(0);
	}
}
