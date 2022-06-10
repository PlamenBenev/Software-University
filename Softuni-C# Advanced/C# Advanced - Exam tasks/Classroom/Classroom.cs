using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public List<Student> Students { get; set; } = new List<Student>();

        public int Capacity { get; set; }
        public int Count
        {
            get { return Students.Count; }
        }

        public Classroom(int capacity)
        {
            Capacity = capacity;
        }
        public string RegisterStudent(Student student)
        {
            if (Capacity > Students.Count)
            {
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return $"No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            foreach (var item in Students)
            {
                if (item.FirstName == firstName && item.LastName == lastName)
                {
                    Students.Remove(item);
                    return $"Dismissed student {firstName} {lastName}";
                }
            }
            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            List<string> students = new List<string>();

            foreach (var item in Students)
            {
                if (item.Subject == subject)
                {
                    students.Add(item.FirstName + " " + item.LastName);
                }
            }
            if (students.Count > 0)
            {
                string returner = $"Subject: {subject}{Environment.NewLine}" +
                    $"Students: {Environment.NewLine}" +
                    $"{string.Join(Environment.NewLine, students)}";

                return returner;
            }
            return "No students enrolled for the subject";
        }
        public int GetStudentsCount()
        {
            return Students.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            Student student = null;
            foreach (var item in Students)
            {
                if (item.FirstName == firstName && item.LastName == lastName)
                {
                    student = item;
                }
            }
            return student;
        }
    }
}
