using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDDxUnit.Tests.Builders
{
    public class StudentBuilder
    {
        public static StudentBuilder New()
        {
            return new StudentBuilder();
        }

    }
}