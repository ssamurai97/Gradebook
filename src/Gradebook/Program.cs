using System;
using System.Collections.Generic;
namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {

            IBook book = new DiskBook("Kuchlong's book");
            book.GradeAdded += onGradeAdded;
            book.GradeAdded += onGradeAdded;
        
            EnterGrade(book);
            var result = book.GetStatistics();

              Console.WriteLine($"this book is for   {book.Name}");
             Console.WriteLine($"the lowest grade is {result.Low}");
             Console.WriteLine($"the highest grade is {result.High}");
             Console.WriteLine($"the average grade is {result.Average:N1}");
             Console.WriteLine($"the average grade  is {result.Letter}");
      
       }

       static void onGradeAdded(object sender, EventArgs args){
              Console.WriteLine("GradedAdded");
       }

       private static void EnterGrade(IBook book){
           while(true){
               Console.WriteLine("Enter a grade or 'q' to quit");

               var input = Console.ReadLine();

               if(input == "q"){
                   break;
               }
               try{
                   var grade = double.Parse(input);

                   book.AddGrade(grade);

               }catch(ArgumentException ex){
                   Console.WriteLine(ex.Message);
               }catch(FormatException ex){
                   Console.WriteLine(ex.Message);
               }finally{
                    Console.WriteLine("**");
               }
           }
       }
    }
}
