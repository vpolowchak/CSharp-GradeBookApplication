using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradebook : BaseGradeBook
    {
        public RankedGradebook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students");
            }

            var threshold = (int)Math.Ceiling(Students.Count * .2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[threshold - 1] <= averageGrade)
            {
                return 'A';
            }
            else if (grades[(threshold * 2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[(threshold * 3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[(threshold * 4) - 1] <= averageGrade)
            {
                return 'D';
            }

            return 'F';

            //double ARange = Students.Count * .2;
            //double BRange = Students.Count * .4;
            //double CRange = Students.Count * .6;
            //double DRange = Students.Count * .8;


            //// Get all average grades
            //List<double> averages = new List<double>();
            //foreach (var student in Students)
            //{
            //    averages.Add(student.AverageGrade);
            //}

            //// Put the average grades in order
            //averages.Sort();

            //// Compare this average grade to the others and figure out where it fits
            //double rank = 1;
            //for (int i = 0; i < Students.Count; i++)
            //{
            //    if (averageGrade < averages[i])
            //    {
            //        rank++;
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}


            //// If averageGrade is in the top 20%, return A
            //if (rank >= ARange)
            //{
            //    return 'A';
            //}

            //// If averageGrade is between the top 20% & 40%, return B
            //if (rank >= BRange)
            //{
            //    return 'B';
            //}

            //// If averageGrade is between the top 40% & 60%, return C
            //if (rank >= CRange)
            //{
            //    return 'C';
            //}

            //// If averageGrade is between  the top 60% & 80%, return D
            //if (rank >= DRange)
            //{
            //    return 'D';
            //}

            //return 'F';
        }
    }
}
