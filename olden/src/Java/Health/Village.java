
import java.util.Enumeration;

/**
 * A class represnting a village in the Columbian health care system
 * simulation.
 **/
class Village
{
  private Village[] forward;
  private Village   back;
  private List      returned;
  private Hospital  hospital;
  private int       label;
  private int       seed;

  private final static int    IA   = 16807;
  private final static float   IM   = 2147483647;
  private final static float  AM   = ((float)1.0/IM);
  private final static int    IQ   = 127773;
  private final static int    IR   = 2836;
  private final static int   MASK = 123459876;

  /**
   * Construct an empty village.
   * @param level the 
   * @param lab the unique label for the village
   * @param p a reference to the "parent" village
   * @param s the user supplied seed value
   **/
  Village(int level, int l, Village p, int s)
  {
    back = p;
    label = l;
    forward = new Village[4];
    seed = label * (IQ + s);
    hospital = new Hospital(level);
    returned = new List();
  }

  /**
   * Add a connection from this village to the specifed village.
   * Each village contains connections to four other ones.
   *
   * @param i the village number
   * @param c the village to add
   **/
  void addVillage(int i, Village c)
  {
    forward[i] = c;
  }

  /**
   * Return true if a patient should stay in this village or
   * move up to the "parent" village.
   * @return true if a patient says in this village
   **/
  final boolean staysHere()
  {
    float rand = myRand(seed);
    seed = (int)(rand * IM);
    return (rand > 0.1 || back == null);
  }

  /**
   * Create a set of villages.  Villages are represented as a quad tree.
   * Each village contains references to four other villages.  Users
   * specify the number of levels.
   *
   * @param level the number of level of villages.
   * @param label a unique label for the village
   * @param back a link to the "parent" village
   * @param seed the user supplied seed value.
   * @return the village that was created
   **/
  static final Village createVillage(int level, int label, Village back, int seed)
  {
    if (level == 0)
      return null;
    else 
	{
		Village village = new Village(level, label, back, seed);
		for (int i = 3; i >= 0; i--) 
		{
			Village child = createVillage(level - 1, (label * 4) + i + 1, village, seed);
			village.addVillage(i, child);
      }
      return village;
    }
  }

  /**
   * Simulate the Columbian health care system for a village.
   * @return a list of patients refered to the next village
   **/
  List simulate()
  {
    // the list of patients refered from each child village
    List val[] = new List[4];

    for (int i = 3; i >= 0; i--) 
	{
		Village v = forward[i];
		if (v != null)
			val[i] = v.simulate();
    }
    
    for (int i = 3; i >= 0; i--) 
	{
		List l = val[i];
		if (l != null) 
		{
			ListNode cur = l.head;
            while (cur != null)
			{
                Patient q = (Patient)cur.object;
                hospital.putInHospital(q);
                cur = cur.next;
            }
		}
    }
    
    hospital.checkPatientsInside(returned);
    List up = hospital.checkPatientsAssess(this);
    hospital.checkPatientsWaiting();

    // generate new patients
    Patient p = generatePatient();
    if (p != null)
      hospital.putInHospital(p);

    return up;
  }

  /**
   * Summarize results of the simulation for the Village
   * @return a summary of the simulation results for the village
   **/
  Results getResults()
  {
    Results fval[] = new Results[4];
    for (int i = 3; i >=0 ; i--) 
	{
		Village v = forward[i];
		if (v != null)
			fval[i] = v.getResults();
    }

    Results r = new Results();
    for (int i = 3; i >= 0; i--) 
	{
		if (fval[i] != null) 
		{
			r.totalHospitals += fval[i].totalHospitals;
			r.totalPatients += fval[i].totalPatients;
			r.totalTime += fval[i].totalTime;
		}
    }

    ListNode cur = returned.head;
    while (cur != null)
	{
		Patient p = (Patient)cur.object;
        r.totalHospitals += (float)p.hospitalsVisited;
		r.totalTime += (float)p.time;
		r.totalPatients += 1.0;
        cur = cur.next;
    }

    return r;
  }

  /**
   * Try to generate more patients for the village.
   * @return a new patient or null if a new patient isn't created
   **/
  private Patient generatePatient()
  {
    float rand = myRand(seed);
    seed = (int)(rand * IM);
    Patient p = null;
    if (rand > 0.666)
      p = new Patient(this);
    return p;
  }

  public String toString()
  {
    return (new Integer(label)).toString();
  }
    
  /**
   * Random number generator.
   **/
  static float myRand(int idum) 
  {
    idum ^= MASK;
    int k = idum / IQ;
    idum = IA * (idum - k * IQ) - IR * k;
    idum ^= MASK;
    if (idum < 0) 
      idum += IM;
    float answer = AM * idum;
    return answer;
  }
}
