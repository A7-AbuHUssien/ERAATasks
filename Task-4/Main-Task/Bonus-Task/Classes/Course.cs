namespace Bonus_Task;

public class Course
{
     public int CourseId { get; }
     public  string Title{ set; get; }
     public  Instructor Instructor{ set; get; }

     public Course(int courseId, string title, Instructor instructor)
     {
          CourseId = courseId;
          Title = title;
          Instructor = instructor;
     }
     public string GetCourseDetails()
     {
          return $"{CourseId} - {Title} - {Instructor.Name}";
     }
}