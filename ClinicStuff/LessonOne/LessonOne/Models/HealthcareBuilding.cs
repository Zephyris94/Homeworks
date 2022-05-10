using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonOne.Models
{
  public abstract class HealthcareBuilding
  {
    public int FloorCount { get; protected set; }

    public int CarCount { get; protected set; }

    public int UsedCarCount { get; protected set; }

    public int MaxPatients { get; protected set; }
    public int WardsCount { get; protected set; }

    /// <summary>
    /// IS ACTIVE
    /// </summary>
    public bool IsActive
    {
      get
      {
        if (Patients.Count() <= MaxPatients)
          return true;
        else
          return false;
      }
    }

    public virtual BuildingType Type { get; }

    protected List<Patient> Patients = new List<Patient>();

    protected HealthcareBuilding(
      int floorCount, int carCount, int maxPatients)
    {
      FloorCount = floorCount;
      CarCount = carCount;
      MaxPatients = maxPatients;
    }

    public abstract void RegisterPatient(Patient patient);

    public abstract void RegisterPatients(List<Patient> patients);

    public abstract string ReturnInformation();

    public int PatientCount => Patients.Count;

    public int FreeCars => CarCount - UsedCarCount;

    // public int PatientCount {get { return Patients.Count; }}

    public void AddCar()
    {
      CarCount++;
    }

    public void AddCars(int count)
    {
      CarCount += count;
    }

    public void UseCar()
    {
      if (CarCount > UsedCarCount)
      {
        UsedCarCount++;
      }
    }

    public void ReleaseCar()
    {
      if (UsedCarCount > 0)
      {
        UsedCarCount--;
      }
    }
  }
}
