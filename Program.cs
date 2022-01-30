﻿using System;
using System.Linq;

namespace LinqPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context=new LinqDbContext();
            var students=_context.Students.ToList<Student>();

            //Find
            Console.WriteLine("*****Find*****");
            var student=_context.Students.Where(s => s.StudentId==1).FirstOrDefault();
            student=_context.Students.Find(1);
            Console.WriteLine(student.Name);

            //FirstOrDefault
            Console.WriteLine();
            Console.WriteLine("*****FirstOrDefault*****");
            student=_context.Students.Where(s => s.Surname=="Arda").FirstOrDefault();
            Console.WriteLine(student.Name);

            student=_context.Students.FirstOrDefault(x=>x.Surname=="Arda");
            Console.WriteLine(student.Name);

            //SingleOrDefault
            Console.WriteLine();
            Console.WriteLine("*****SingleOrDefault*****");
            student=_context.Students.SingleOrDefault(s=>s.Name=="Deniz");
            //student=_context.Students.SingleOrDefault(s=>s.Name=="Arda");//hata fırlatır
            Console.WriteLine(student.Surname);
            //ToList
            Console.WriteLine();
            Console.WriteLine("*****ToList*****");
            var studentList=_context.Students.Where(s=> s.ClassId==2).ToList();
            Console.WriteLine(studentList.Count);
            //OrderBy
            Console.WriteLine();
            Console.WriteLine("*****OrderBy*****");
            students=_context.Students.OrderBy(x=>x.StudentId).ToList();
            foreach (var s in students){
                Console.WriteLine(s.StudentId+"-"+s.Name+"-"+s.Surname);
            }

            //OrderByDescending
            Console.WriteLine();
            Console.WriteLine("*****OrderByDescending*****");
            students=_context.Students.OrderByDescending(x=>x.StudentId).ToList();
            foreach (var s in students){
                Console.WriteLine(s.StudentId+"-"+s.Name+"-"+s.Surname);
            }

            //Anonymous Object Result
            Console.WriteLine();
            Console.WriteLine("*****Anonymous Object Result*****");
            var anonymousObject=_context.Students.Where(x=>x.ClassId==2)
            .Select(x=> new{Id=x.StudentId, FullName=x.Name+" "+x.Surname}
            );
            foreach (var obj in anonymousObject)
            {
                Console.WriteLine(obj.Id+"-"+obj.FullName);
            }
        }
    }
}
