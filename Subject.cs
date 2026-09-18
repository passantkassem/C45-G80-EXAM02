using System;
using System.Collections.Generic;
using System.Text;

namespace C45_G80_EXAM02
{
    internal class Subject
    {
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam[] Exams { get; set; }
    }
}
