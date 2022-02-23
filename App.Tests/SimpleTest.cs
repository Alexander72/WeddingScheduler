using Xunit;
using System.Collections.Generic;
using App.Models;

namespace App.Tests
{
    public class SimpleTest
    {
       /* [Fact]
        public void testSomething()
        {
            Assert.False(false);
        }
        */

        [Fact]
        public void guestName()
        {
            Guest guest = new Guest("Inga", new List<int>{1, 3});
            Assert.True(guest.isWorkingAt(3));
        }


    }
}