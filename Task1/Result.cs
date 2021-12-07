using Commons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class Result : IResult
    {
        public dynamic ReadFromFile()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt32(cTemp)).ToList();

            return new { n, c };
        }

        public dynamic TaskToSolve()
        {
            var readData = ReadFromFile();
            var _parameters = new { n = (int)readData.n, c = (List<int>)readData.c };

            return _parameters;
        }
    }
}