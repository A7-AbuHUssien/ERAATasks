namespace Bonus_Task;

public class StudentManager
{
    private List<Student>  _Students;
    private List<Course> _Courses;
    private List<Instructor> _Instructors;
    public StudentManager()
    {
        _Students = new List<Student>();
        _Courses = new List<Course>();
        _Instructors = new List<Instructor>();
    }

    public bool AddStudent(Student student)
    {
        if (_Students.Any(s => s.StudentId == student.StudentId))
            return false;
        _Students.Add(student);
        return true;
    }

    public bool AddCourse(Course course)
    {
        if (_Courses.Any(c => c.CourseId == course.CourseId) || !_Instructors.Contains(course.Instructor))
            return false;
        _Courses.Add(course);
        return true;
    }

    public bool AddInstructor(Instructor instructor)
    {
        if (_Instructors.Any(x=>x.InstructorId == instructor.InstructorId))
            return false;
        _Instructors.Add(instructor);
        return true;
    }

    public Student FindStudent(int studentId)
    {
        return _Students.FirstOrDefault(s => s.StudentId == studentId);
    }

    public Course FindCourse(int courseId)
    {
        return _Courses.FirstOrDefault(c => c.CourseId == courseId);
    }

    public Instructor FindInstructor(int instructorId)
    {
        return _Instructors.FirstOrDefault(i => i.InstructorId == instructorId);
    }

    public bool EnrollStudentInCourse(int studentId, int courseId)
    {
        Student student = FindStudent(studentId);
        Course course = FindCourse(courseId);
        
        if (student == null || course == null)
            return false;
        if (student.Courses.Contains(course))
            return false;
        
        if (student.Enroll(course))
            return true;
        
        return false;
    }

    public List<Student> GetAllStudents()
    {
        return _Students;
    }

    public List<Course> GetAllCourses()
    {
        return _Courses;
    }

    public List<Instructor> GetAllInstructors()
    {
        return _Instructors;
    }

    public Student FindStudentByName(string name)
    {
        return _Students.Find(s=>s.Name == name);
    }
    public Course FindCourseByTitle(string title)
    {
        return _Courses.Find(c=>c.Title == title);
    }
}