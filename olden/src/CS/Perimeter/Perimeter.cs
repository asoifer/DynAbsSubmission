﻿
using System;

//
// A Java version of the <tt>perimeter</tt> Olden benchmark.
// <p/>
// The algorithm computes the total perimeter of a region
// in a binary image represented by a quadtree.  The
// algorithm was presented in the paper:
// <p/>
// <cite>
// Hanan Samet, "Computing Perimeters of Regions in Images
// Represented by Quadtrees," IEEE Transactions on Pattern
// Analysis and Machine Intelligence, PAMI-3(6), November, 1981.
// </cite>
// <p/>
// The benchmark creates an image, count the number of leaves on the
// quadtree and then computes the perimeter of the image using Samet's
// algorithm.
//
public class Perimeter
{
	//
	// The number of levels in the tree/image.
	//*/
	private static int levels = 0;
	//
	// Set to true to print the final result.
	///
	private static bool printResult = false;
	//
	// Set to true to print information messages.
	//
	private static bool printMsgs = false;
	
	//
	// The entry point to computing the perimeter of an image.
	// @param args the command line arguments
	//
	public static void Main(String[] args)
	{
		parseCmdLine(args);

		int size = 1 << levels;
		int msize = 1 << (levels - 1);
		QuadTreeNode.gcmp = size * 1024;
		QuadTreeNode.lcmp = msize * 1024;

		var start0 = System.DateTime.Now;
		QuadTreeNode tree = QuadTreeNode.createTree(msize, 0, 0, null, Quadrant.cSouthEast, levels);
		var end0 = System.DateTime.Now;
		
		var start1 = System.DateTime.Now;
		int leaves = tree.countTree();
		var end1 = System.DateTime.Now;
		
		var start2 = System.DateTime.Now;
		int perm = tree.perimeter(size);
		var end2 = System.DateTime.Now;

		if(printResult)
		{
			Console.WriteLine("Perimeter is " + perm);
			Console.WriteLine("Number of leaves " + leaves);
		}

		if (printMsgs) 
		{
		  Console.WriteLine("QuadTree alloc time " + (end0.Subtract(start0).TotalMilliseconds)/1000.0);
		  Console.WriteLine("Count leaves time " + (end1.Subtract(start1).TotalMilliseconds)/1000.0);
		  Console.WriteLine("Perimeter compute time " + (end2.Subtract(start2).TotalMilliseconds)/1000.0);
		}
		var slicingVariable1 = perm;
		var slicingVariable2 = leaves;
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

			if(arg.Equals("-l"))
			{
				if(i < args.Length)
				{
					levels = System.Int32.Parse(args[i++]);
				}
				else
				{
					throw new Exception("-l requires the number of levels");
				}
			}
			else if(arg.Equals("-p"))
			{
				printResult = true;
			}
			else if (arg.Equals("-m")) 
			  {
			printMsgs = true;
			  } 
			else if(arg.Equals("-h"))
			{
				usage();
			}
		}
		if(levels == 0) 
			usage();
	}

	//
	// The usage routine which describes the program options.
	//
	private static void usage()
	{
		Console.WriteLine("usage: java Perimeter -l <num> [-p] [-m] [-h]");
		Console.WriteLine("    -l number of levels in the quadtree (image size = 2^l)");
		Console.WriteLine("    -p (print the results)");
		Console.WriteLine("    -m (print informative messages)");
		Console.WriteLine("    -h (this message)");
		System.Environment.Exit(0);
	}
}
