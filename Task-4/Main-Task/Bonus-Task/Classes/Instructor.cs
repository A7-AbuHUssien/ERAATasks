namespace Bonus_Task;

public class Instructor
{
     public  int InstructorId { get; }
     public   string Name  { set; get; }
     public  string Specialization  { set; get; }

     public Instructor(int instructorId, string name, string specialization)
     {
          InstructorId = instructorId;
          Name = name;
          Specialization = specialization;
     }
     public string GetInstructorDetails()
     {
          return $"{InstructorId} - {Name} - {Specialization}";
     }
}