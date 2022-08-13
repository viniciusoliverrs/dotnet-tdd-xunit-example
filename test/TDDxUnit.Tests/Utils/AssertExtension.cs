using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDDxUnit.Tests.Utils
{
    public static class AssertExtension
    {
        public static void WithMessage(this ArgumentException exception, string message)
        {
            if(exception.Message == message) Assert.True(true);
            else Assert.False(true);
        }
    }
}