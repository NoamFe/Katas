using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _persons;

        public Finder(List<Person> persons)
        {
            _persons = persons;
        }

        public Result Find(TimeSpanFilter timeSpanFilter)
        {
            if (_persons.Count < 2)
                return new Result();

            if (_persons.Count == 2)
                return new Result { Person1 = _persons[0], Person2 = _persons[1] };


            var orderedByBirthday = _persons.OrderBy(e => e.BirthDate).ToList();

            return timeSpanFilter == TimeSpanFilter.Furthest ?
                new Result() { Person1 = orderedByBirthday.FirstOrDefault(), Person2 = orderedByBirthday.Last() }
                : FindClosest(orderedByBirthday);
        }

        private static Result FindClosest(IList<Person> orderedByBirthday)
        {
            var result = new Result() { Person1 = orderedByBirthday[0], Person2 = orderedByBirthday[1] };

            for (var i = 1; i < orderedByBirthday.Count - 1; i++)
            {
                var next = new Result() { Person1 = orderedByBirthday[i], Person2 = orderedByBirthday[i + 1] };
                if (result.TimeGap > next.TimeGap)
                {
                    result = next;
                }
            }

            return result;
        }
    }
}