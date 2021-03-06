
using System;

//
// A class representing a hospital in the Columbian health care system.
//
public class Hospital
{
	private int  personnel;
	private int  freePersonnel;
	private int  numWaitingPatients;
	private List waiting;
	private List assess;
	private List inside;
	private List up;

	public Hospital(int level)
	{
		personnel = 1 << (level - 1);
		freePersonnel = personnel;
		numWaitingPatients = 0;
		waiting = new List();
		assess = new List();
		inside = new List();
		up = new List();
	}


	//
	// Add a patient to this hospital
	// @param p the patient.
	//
	public void putInHospital(Patient p)
	{
		int num = p.hospitalsVisited;
		p.hospitalsVisited++;
		if (freePersonnel > 0) 
		{
		  freePersonnel--;
		  assess.add(p);
		  p.timeLeft = 3;
		  p.time += 3;
		} 
		else
		  waiting.add(p);
	}

	//
	// Check the patients inside the hospital to see if any are finished.
	// If so, then free up the personnel and and the patient to the returned
	// list.
	// @param returned a list of patients
	//
	public void checkPatientsInside(List returned)
	{
        var cur = inside.head;
        while (cur != null)
		{
			Patient p = (Patient)cur._object;
			p.timeLeft -= 1;
			if (p.timeLeft == 0) 
			{
				freePersonnel++;
				inside.delete(p);
				returned.add(p);
			}
            cur = cur.next;
        }
	}

	//
	// Asses the patients in the village.
	// @param v the village that owns the hospital
	//
	public List checkPatientsAssess(Village v)
	{
		List up = new List();
        var cur = assess.head;
        while (cur != null)
		{
			Patient p = (Patient)cur._object;
			p.timeLeft -= 1;
			if (p.timeLeft == 0) 
			{
				if (v.staysHere()) 
				{
					assess.delete(p);
					inside.add(p);
					p.timeLeft = 10;
					p.time += 10;
				} 
				else 
				{
					freePersonnel++;
					assess.delete(p);
					up.add(p);
				}
			}
            cur = cur.next;
        }
		return up;
	}

	public void checkPatientsWaiting()
	{
        var cur = waiting.head;
        while (cur != null) 
		{
			Patient p = (Patient)(cur._object);
			if (freePersonnel > 0) 
			{
				freePersonnel--;
				p.timeLeft = 3;
				p.time += 3;
				waiting.delete(p);
				assess.add(p);
			} 
			else 
			{
				p.time++;
			}
            cur = cur.next;
		}
	}
}
