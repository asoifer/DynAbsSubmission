using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

//
// A Java implementation of the <tt>bisort</tt> Olden benchmark.  The Olden
// benchmark implements a Bitonic Sort as described in :
// <p><cite>
// G. Bilardi and A. Nicolau, "Adaptive Bitonic Sorting: An optimal parallel
// algorithm for shared-memory machines." SIAM J. Comput. 18(2):216-228, 1998.
// </cite>
// <p/>
// The benchmarks sorts N numbers where N is a power of 2.  If the user provides
// an input value that is not a power of 2, then we use the nearest power of
// 2 value that is less than the input value.
///
public class BiSort
{
	//
    // The number of values to sort.
    //
	private static int treesize = 0;
	
	//
    // Print information messages
    //
	private static bool printMsgs = false;
	//
    // Print the tree after each step
    //
	private static bool printResults = false;

	//*
	// The main routine which creates a tree and sorts it a couple of times.
	// @param args the command line arguments
	///
	public static void Main(String[] args)
	{
		parseCmdLine(args);

		if(printMsgs)
			Console.WriteLine("Bisort with " + treesize + " values");

		var start2 = System.DateTime.Now;
		Value tree = Value.createTree(treesize, 12345768);
		var end2 = System.DateTime.Now;
		int sval = Value.random(245867) % Value.RANGE;

		if(printResults)
		{
			tree.inOrder();
			Console.Write(sval);
		}

		if(printMsgs)
			Console.WriteLine("BEGINNING BITONIC SORT ALGORITHM HERE");

		var start0 = System.DateTime.Now;
		sval = tree.bisort(sval, Value.FORWARD);
        var end0 = System.DateTime.Now;
		
		if(printResults)
		{
			tree.inOrder();
			Console.Write(sval);
		}

        var start1 = System.DateTime.Now;
		sval = tree.bisort(sval, Value.BACKWARD);
		var end1 = System.DateTime.Now;
		
		if(printResults)
		{
			tree.inOrder();
			Console.Write(sval);
		}

		if (printMsgs) 
		{
		  Console.WriteLine("Creation time: " + (end2.Subtract(start2).TotalMilliseconds)/1000.0);
          Console.WriteLine("Time to sort forward = " + (end0.Subtract(start0).TotalMilliseconds) /1000.0);
          Console.WriteLine("Time to sort backward = " + (end1.Subtract(start1).TotalMilliseconds) /1000.0);
		  Console.WriteLine("Total: " + (end1.Subtract(start0).TotalMilliseconds) /1000.0);
		}
        var slicingVariable1 = sval;
        var slicingVariable2 = tree.value;
        var slicingVariable3 = tree.left.value;
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
			if(arg.Equals("-s"))
			{
				if(i < args.Length)
					treesize = Int32.Parse(args[i++]);
				else
					throw new Exception("-l requires the number of levels");
			}
			else if(arg.Equals("-p"))
				printResults = true;
			else if(arg.Equals("-m"))
				printMsgs = true;
			else if(arg.Equals("-h"))
				usage();
		}
		if(treesize == 0)
			usage();
	}

	//*
	// The usage routine which describes the program options.
	//*/
	private static void usage()
	{
		Console.WriteLine("usage: java BiSort -s <size> [-p] [-i] [-h]");
		Console.WriteLine("    -s the number of values to sort");
		Console.WriteLine("    -m (print informative messages)");
		Console.WriteLine("    -p (print the binary tree after each step)");
		Console.WriteLine("    -h (print this message)");
		System.Environment.Exit(0);
	}
}
