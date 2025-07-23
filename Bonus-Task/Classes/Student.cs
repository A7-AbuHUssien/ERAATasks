namespace Bonus_Task;

public class Student
{
     public int StudentId { get; }
     public string Name  { get; set; }
     public int Age   { get; set; }
     public List<Course> Courses  { get; set; }

     public Student(int studentId, string name, int age)
     {
          StudentId = studentId;
          Name = name;
          Age = age;
          Courses = new List<Course>();
     }

     public  bool Enroll(Course course)
     {
         if (Courses.Contains(course) || Courses.Any(x=>x.CourseId == course.CourseId))
         {
             return false;
         }
         Courses.Add(course);
         return true;
     }

     public string GetStudentDetails()
     {
         string courses = "";
         foreach (var course in Courses)
         {
             courses += course.Title + ", ";
         }
         courses = courses.TrimEnd(' ', ',');
         return ($" {StudentId} - {Name} - {Age} years old - [{courses}]");
     }
}