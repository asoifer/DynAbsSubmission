using System;
using System.IO;
using System.Text;
using System.Collections.Generic;













public class BH
{
	//
    // The user specified number of bodies to create.
    //
	private static int nbody = 0;

	//
	// The maximum number of time steps to take in the simulation
	//
	private static int nsteps = 0;

	//
	// Should we print information messsages
	//
	private static bool printMsgs = false;
	//
	// Should we print detailed results
	//
	private static bool printResults = false;

	public static double DTIME = 0.0125;
	private static double TSTOP = 2.0;

	public static void Main(string[] args)
	{
		parseCmdLine(args);

		if(printMsgs)
			Console.WriteLine("nbody = " + nbody);

		var start0 = System.DateTime.Now;
		BTree root = new BTree();
		root.createTestData(nbody);
		var end0 = System.DateTime.Now;
		if(printMsgs)
			Console.WriteLine("Bodies created");

		var start1 = System.DateTime.Now;
		double tnow = 0.0;
		int i = 0;
		while ((tnow < TSTOP + 0.1*DTIME) && (i < nsteps)) 
		{
			root.stepSystem(i++);
			tnow += DTIME;
		}
		var end1 = System.DateTime.Now;
		
		if(printResults)
		{
			int j = 0;
			Body current = root.bodies();
		    while(current != null) 
		    {
			  Console.WriteLine("body " + j++ + " -- " + current.pos);
			  current = (Body)current.getNext();
		    }
		}
		
		if (printMsgs) 
		{
            Console.WriteLine("Build Time " + (end0.Subtract(start0).TotalMilliseconds)/1000.0);
            Console.WriteLine("Compute Time " + (end1.Subtract(start1).TotalMilliseconds)/1000.0);
            Console.WriteLine("Total Time " + (end1.Subtract(start0).TotalMilliseconds)/1000.0);
		}

        var slicingVariable1 = root.bodyTab.pos;
        var slicingVariable2 = root.bodyTab.pos.data[0];
        var slicingVariable3 = root.bodyTab.vel;
        var slicingVariable4 = root.bodyTab.vel.data[0];
        var slicingVariable5 = root.bodyTab.acc;
        var slicingVariable6 = root.bodyTab.acc.data[0];
        Console.WriteLine("Done!");
	}

	//
	// Random number generator used by the orignal BH benchmark.
	// @param seed the seed to the generator
	// @return a random number
	//
	public static double myRand(double seed)
	{
		double t = 16807.0 * seed + 1.0;

		seed = t - (2147483647.0 * Math.Floor(t / 2147483647.0));
		return seed;
	}

	//
	// Generate a floating point random number.  Used by
	// the original BH benchmark.
	// @param xl lower bound
	// @param xh upper bound
	// @param r  seed
	// @return a floating point randon number
	//
	public static double xRand(double xl, double xh, double r)
	{
		double res = xl + (xh - xl) * r / 2147483647.0;
		return res;
	}

	//
    // Parse the command line options.
    // @param args the command line options.
    //
	private static void parseCmdLine(String[] args)
	{
		int i = 0;
		string arg;

		while(i < args.Length && args[i].StartsWith("-"))
		{
			arg = args[i++];

			// check for options that require arguments
			if(arg.Equals("-b"))
			{
				if(i < args.Length)
				{
					nbody = Int32.Parse(args[i++]);
				}
				else
				{
					throw new Exception("-l requires the number of levels");
				}
			}
			else if(arg.Equals("-s"))
			{
				if(i < args.Length)
				{
					nsteps = Int32.Parse(args[i++]);
				}
				else
				{
					throw new Exception("-l requires the number of levels");
				}
			}
			else if(arg.Equals("-m"))
			{
				printMsgs = true;
			}
			else if(arg.Equals("-p"))
			{
				printResults = true;
			}
			else if(arg.Equals("-h"))
			{
				usage();
			}
		}
		if(nbody == 0)
			usage();
	}

	//
	// The usage routine which describes the program options.
	//
	private static void usage()
	{
		Console.WriteLine("usage: java BH -b <size> [-s <steps>] [-p] [-m] [-h]");
		Console.WriteLine("    -b the number of bodies");
		Console.WriteLine("    -s the max. number of time steps (default=10)");
		Console.WriteLine("    -p (print detailed results)");
		Console.WriteLine("    -m (print information messages");
		Console.WriteLine("    -h (this message)");
		System.Environment.Exit(0);
	}
}
