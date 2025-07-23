namespace Bonus_Task;
class Program
{
    public static StudentManager _School;
    public static bool AddStudent()
    {
        Console.Write("Enter Student ID: ");
        int Studentid = int.Parse(Console.ReadLine());
        Console.Write("Enter Student Name: ");
        string Studentname = Console.ReadLine();
        Console.Write("Enter Student Age: ");
        int Studentage = int.Parse(Console.ReadLine());
        Student student = new Student(Studentid, Studentname, Studentage);
        return _School.AddStudent(student);
    }
    public static bool AddInstructor()
    {
        Console.Write("Enter Instructor ID: ");
        int Instructorid = int.Parse(Console.ReadLine());
        Console.Write("Enter Instructor Name: ");
        string Instructorname = Console.ReadLine();
        Console.Write("Enter Instructor Specialization: ");
        string InstructorSpecialization = Console.ReadLine();
        Instructor instructor = new Instructor(Instructorid, Instructorname, InstructorSpecialization);
        return _School.AddInstructor(instructor);
    }
    public static bool AddCourse()
    {
        Console.WriteLine("Enter Course ID: ");
        int Courseid = int.Parse(Console.ReadLine());
        Console.Write("Enter Course Name: ");
        string CourseName = Console.ReadLine();
        Console.WriteLine("Enter Instructor ID: ");
        int Instructorid = Convert.ToInt32(Console.ReadLine());
        Course course = new Course(Courseid, CourseName, _School.FindInstructor(Instructorid));
        return _School.AddCourse(course);
    }

    public static bool EnrollStudentToCourse()
    {
        int StudentId = 0; int CourseId = 0;
        Console.Write("Enter Student ID: ");
        StudentId = int.Parse(Console.ReadLine());
        Console.Write("Enter Course ID: ");
        CourseId = int.Parse(Console.ReadLine());
        
        return _School.EnrollStudentInCourse(StudentId,CourseId);
    }
    static void Main(string[] args)
    {
        
        _School = new StudentManager();
        while (true)
        {
            ShowMenue();
            Console.WriteLine("Enter Your Choice:");
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1": 
                    if ((AddStudent()))
                       Console.WriteLine("Student added");
                    else
                       Console.WriteLine("Unexpected Error");
                    Console.ReadKey();
                    break;
                
                case "2":
                    
                    if (AddInstructor())
                        Console.WriteLine("Instructor added");
                    else
                        Console.WriteLine("Unexpected Error");
                    Console.ReadKey();
                    break;
                
                case "3":
                   if (AddCourse())
                    Console.WriteLine("Course added");
                    else
                        Console.WriteLine("Unexpected Error");
                    Console.ReadKey();
                    break;
              case "4":
                  if (EnrollStudentToCourse())
                  Console.WriteLine("Course enrolled");
                  else
                    Console.WriteLine("Unexpected Error");
                  Console.ReadKey();
                  break;
              case "5":
                    List<Student>students = _School.GetAllStudents();
                    foreach (Student student in students)
                    {
                       Console.WriteLine(student.GetStudentDetails());
                    }
                  Console.ReadKey();
                  break;
              case "6":
                  List<Course> courses = _School.GetAllCourses();
                  foreach (Course course in courses)
                  {
                      Console.WriteLine(course.GetCourseDetails());
                  }
                  Console.ReadKey();
                  break;
              case "7":
                  List<Instructor> instructors = _School.GetAllInstructors();
                  foreach (Instructor instructor in instructors)
                  {
                      Console.WriteLine(instructor.GetInstructorDetails());
                  }
                  Console.ReadKey();
                  break;
              case "8":
                    Console.Write("Enter Student ID or Name: ");
                    string studentSearch = Console.ReadLine();

                    if (int.TryParse(studentSearch, out int sid))
                    {
                        var stu = _School.FindStudent(sid);
                        Console.WriteLine(stu?.GetStudentDetails() ?? "Student not found.");
                    }
                    else
                    {
                        var stu = _School.FindStudentByName(studentSearch);
                        Console.WriteLine(stu?.GetStudentDetails() ?? "Student not found.");
                    }
                    Console.ReadKey();
                    break;
              case "9":
                    Console.Write("Enter Course ID or Name: ");
                    string courseSearch = Console.ReadLine();

                    if (int.TryParse(courseSearch, out int cid))
                    {
                        var course = _School.FindCourse(cid);
                        Console.WriteLine(course?.GetCourseDetails() ?? "Course not found.");
                    }
                    else
                    {
                        var course = _School.FindCourseByTitle(courseSearch);
                        Console.WriteLine(course?.GetCourseDetails() ?? "Course not found.");
                    }
                    Console.ReadKey();
                    break;
                case "10":
                    Console.WriteLine("Goodbye...");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
    public static void ShowMenue()
    {
        Console.WriteLine("\n--- Student Management System ---");
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Add Instructor");
        Console.WriteLine("3. Add Course");
        Console.WriteLine("4. Enroll Student in Course");
        Console.WriteLine("5. Show All Students");
        Console.WriteLine("6. Show All Courses");
        Console.WriteLine("7. Show All Instructors");
        Console.WriteLine("8. Find Student by ID or Name");
        Console.WriteLine("9. Find Course by ID or Name");
        Console.WriteLine("10. Exit");
    }
}
