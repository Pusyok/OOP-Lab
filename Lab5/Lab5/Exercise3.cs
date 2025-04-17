namespace Lab5;

class Student : IComparable<Student>
{
    public string Name { get; set; }
    public int Grade { get; set; }

    public int CompareTo(Student other)
    {
        return Grade.CompareTo(other.Grade);
    }
}