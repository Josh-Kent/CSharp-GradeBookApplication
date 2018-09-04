using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            var threshold = (int) Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            var result = 'F';

            if (grades[threshold -1] <= averageGrade)
            {
                result = 'A';
            }
            else if (grades[(threshold*2)-1] <= averageGrade)
            {
                result = 'B';
            }
            else if (grades[(threshold*3)-1] <= averageGrade)
            {
                result = 'C';
            }
            else if (grades[(threshold*4)-1] <= averageGrade)
            {
                result = 'D';
            }

            return result;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in the order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }
    }
}
