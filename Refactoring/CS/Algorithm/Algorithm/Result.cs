using System;

namespace Algorithm
{
    public class Result
    {
        public Person Person1 { get; set; }
        public Person Person2 { get; set; }

        public TimeSpan TimeGap => Person2.BirthDate - Person1.BirthDate;
    }
}