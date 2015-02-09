using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeReviewLib;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Working");
            CodeReview.ThisMethod();
            CodeReview.FromThisLine();
            Console.WriteLine("Finally Working");
        }
    }
}
