using System.Collections.Generic;
using System;
using System.IO;

namespace Gradebook
{

    public delegate void GradedAddedDeleGate(object sender, EventArgs args);


    public class NameObject
    {
        public NameObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }


    public abstract class Book : NameObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradedAddedDeleGate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradedAddedDeleGate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt")){
                var line = reader.ReadLine();
                while(line !=null){
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradedAddedDeleGate GradeAdded;
    }
    public class InMemoryBook : Book
    {


        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddLettrGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalied value{nameof(grade)}");
            }

        }

        public override event GradedAddedDeleGate GradeAdded;

        public override Statistics GetStatistics()
        {


            var result = new Statistics();

            result.High = double.MinValue;
            result.Low = double.MaxValue;

            for (var grade = 0; grade < grades.Count; grade += 1)
            {
                result.Add(grades[grade]);

            }


            return result;
        }

        List<double> grades;
    }
}