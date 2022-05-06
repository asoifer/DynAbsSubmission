
using System;

//*
// A Java implementation of the <tt>tsp</tt> Olden benchmark, the traveling
// salesman problem.
// <p>
// <cite>
// R. Karp, "Probabilistic analysis of partitioning algorithms for the 
// traveling-salesman problem in the plane."  Mathematics of Operations Research 
// 2(3):209-224, August 1977
// </cite>
//*/
public class TSP
{
	//*
	// Number of cities in the problem.
	//*/
	private static int cities;
	//*
	// Set to true if the result should be printed
	//*/
	private static bool printResult = false;
	//*
	// Set to true to print informative messages
	//*/
	private static bool printMsgs = false;

	//*
	// The main routine which creates a tree and traverses it.
	// @param args the arguments to the program
	///
	public static void Main(String[] args)
	{
		parseCmdLine(args);

		if(printMsgs)
			Console.WriteLine("Building tree of size " + cities);

		var start0 = System.DateTime.Now;
		Tree t = Tree.buildTree(cities, false, 0.0, 1.0, 0.0, 1.0);
		var end0 = System.DateTime.Now;

		var start1 = System.DateTime.Now;
		t.tsp(150);
		var end1 = System.DateTime.Now;

		if(printResult)
		{
			// if the user specifies, print the final result
			t.printVisitOrder();
		}

		if (printMsgs) 
		{
		  Console.WriteLine("Tsp build time  " + (end0.Subtract(start0).TotalMilliseconds)/1000.0);
		  Console.WriteLine("Tsp time " + (end1.Subtract(start1).TotalMilliseconds)/1000.0);
		  Console.WriteLine("Tsp total time " + (end1.Subtract(start0).TotalMilliseconds)/1000.0);
		}
        var slicingVariable1 = t.x;
        var slicingVariable2 = t.y;
        var slicingVariable3 = t.next;
        var slicingVariable4 = t.next.x;
        var slicingVariable5 = t.next.y;
        Console.WriteLine("Done!");
	}

	//*
   // Parse the command line options.
   // @param args the command line options.
   //*/
	private static void parseCmdLine(String[] args)
	{
		int i = 0;
		String arg;

		while(i < args.Length && args[i].StartsWith("-"))
		{
			arg = args[i++];

			if(arg.Equals("-c"))
			{
				if(i < args.Length)
					cities = System.Int32.Parse(args[i++]);
				else 
					throw new Exception("-c requires the size of tree");
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
		if(cities == 0) 
			usage();
	}

	//*
	// The usage routine which describes the program options.
	//*/
	private static void usage()
	{
		Console.WriteLine("usage: java TSP -c <num> [-p] [-m] [-h]");
		Console.WriteLine("    -c number of cities (rounds up to the next power of 2 minus 1)");
		Console.WriteLine("    -p (print the final result)");
		Console.WriteLine("    -m (print informative messages)");
		Console.WriteLine("    -h (print this message)");
		System.Environment.Exit(0);
	}
}
