
using System;

//
// A Java implementation of the <tt>health</tt> Olden benchmark.  The Olden
// benchmark simulates the Columbian health-care system:
// <p/>
// <cite>
// G. Lomow , J. Cleary, B. Unger, and D. West. "A Performance Study of
// Time Warp," In SCS Multiconference on Distributed Simulation, pages 50-55,
// Feb. 1988.
// </cite>
//
public class Health
{
	//
	// The size of the health-care system.
	//
	private static int maxLevel = 0;
	//
	// The maximum amount of time to use in the simulation.
	//
	private static int maxTime = 0;
	//
	// A seed value for the random no. generator.
	//
	private static int seed = 0;
	//
	// Set to true to print the results.
	//
	private static bool printResult = false;
	//
	// Set to true to print information messages.
	//
	private static bool printMsgs = false;

	//
	// The main routnie which creates the data structures for the Columbian
	// health-care system and executes the simulation for a specified time.
	// @param args the command line arguments
	//
	public static void Main(String[] args)
	{
		parseCmdLine(args);

		var start0 = System.DateTime.Now;
		Village top = Village.createVillage(maxLevel, 0, null, (int)seed);
		var end0 = System.DateTime.Now;

		if(printMsgs)
			Console.WriteLine("Columbian Health Care Simulator\nWorking...");

		var start1 = System.DateTime.Now;
		for(int i = 0; i < maxTime; i++)
		{
			if ((i % 50) == 0 && printMsgs) 
				Console.WriteLine(i);
			top.simulate();
		}

		Results r = top.getResults();

		var end1 = System.DateTime.Now;
		
		if(printResult)
		{
			Console.WriteLine("# People treated: " + (int)r.totalPatients);
			Console.WriteLine("Avg. length of stay: " + r.totalTime / r.totalPatients);
			Console.WriteLine("Avg. # of hospitals visited: " + r.totalHospitals / r.totalPatients);
		}
		if (printMsgs) 
		{
		  Console.WriteLine("Build Time " + (end0.Subtract(start0).TotalMilliseconds)/1000.0);
		  Console.WriteLine("Run Time " + (end1.Subtract(start1).TotalMilliseconds)/1000.0);
		  Console.WriteLine("Total Time " + (end1.Subtract(start0).TotalMilliseconds)/1000.0);
		}

        var slicingVariable1 = r.totalHospitals;
        var slicingVariable2 = r.totalPatients;
        var slicingVariable3 = r.totalTime;
        Console.WriteLine("Done!");
	}

	private static void parseCmdLine(String[] args)
	{
		String arg;
		int i = 0;
		while(i < args.Length && args[i].StartsWith("-"))
		{
			arg = args[i++];

			// check for options that require arguments
			if(arg.Equals("-l"))
			{
				if(i < args.Length)
					maxLevel = Int32.Parse(args[i++]);
				else
					throw new Exception("-l requires the number of levels");
			}
			else if(arg.Equals("-t"))
			{
				if(i < args.Length)
					maxTime = Int32.Parse(args[i++]);
				else
					throw new Exception("-t requires the amount of time");
			}
			else if (arg.Equals("-s")) 
		    {
			  if (i < args.Length)
			    seed = int.Parse(args[i++]);
			  else
			    throw new Exception("-s requires a seed value");
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
		if(maxTime == 0 || maxLevel == 0)
			usage();
	}

	//
	// The usage routine which describes the program options.
	//
	private static void usage()
	{
		Console.WriteLine("usage: java Health -l <levels> -t <time> -s <seed> [-p] [-m] [-h]");
		Console.WriteLine("    -l the size of the health care system");
		Console.WriteLine("    -t the amount of simulation time");
		Console.WriteLine("    -s a random no. generator seed");
		Console.WriteLine("    -p (print results)");
		Console.WriteLine("    -m (print information messages");
		Console.WriteLine("    -h (this message)");
		System.Environment.Exit(0);
	}
}
