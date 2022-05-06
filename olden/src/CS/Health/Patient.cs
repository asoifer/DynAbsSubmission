
//
// A class that represents a patient in the health care system.
//
public class Patient
{
	public int hospitalsVisited;
	public int time;
	public int timeLeft;
	Village home;

	//
	// Construct a new patient that is from the specified village.
	// @param v the home village of the patient.
	//
	public Patient(Village v)
	{
		home = v;
		hospitalsVisited = 0;
		time = 0;
		timeLeft = 0;
	}
}
