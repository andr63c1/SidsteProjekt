using System;
using Xunit;
using BookingSystem2;
using BookingSystem2.Models;

namespace BookingSystemTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Customer user = new Customer();
            // Customer returnedUser = AddUser(user);
            //Assert.AreEqual(user, returnedUser);
        }

        [Fact]
        public void Test2()
        {
            //TODO kunde login
        }
        
        [Fact]
        public void Test3()
        {
            Customer user = new Customer();
            // Customer returnedUser = EditUser(user);
            //Assert.AreEqual(user, returnedUser);
        }

    }
}
