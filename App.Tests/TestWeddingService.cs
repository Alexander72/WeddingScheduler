using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using App.Models;
using App.Services;

namespace App.Tests
{
    public class TestWeddingService
    {
        [Fact]
        public void testDayIndexWhenEveryoneCanCome_SundayAndSaturdayAreFree()
        {
            List<Guest> guests = new List<Guest>();
            guests.Add(new Guest("Inga", new List<int>{1, 3}));
            guests.Add(new Guest("Sasha", new List<int>{1, 2, 3, 4, 5}));

            WeddingService weddingService = new WeddingService();
            int dayIndex = weddingService.dayIndexWhenEveryoneCanCome(guests);
            Assert.Equal(7, dayIndex);
        }

        [Fact]
        public void testDayIndexWhenEveryoneCanCome_onlyMondayIsFree()
        {
            List<Guest> guests = new List<Guest>();
            guests.Add(new Guest("Inga", new List<int>{3, 7, 6}));
            guests.Add(new Guest("Sasha", new List<int>{2, 3, 4, 5}));

            WeddingService weddingService = new WeddingService();
            int dayIndex = weddingService.dayIndexWhenEveryoneCanCome(guests);
            Assert.Equal(1, dayIndex);
        }

        [Fact]
        public void testDayIndexWhenEveryoneCanCome_allBusy()
        {
            List<Guest> guests = new List<Guest>();
            guests.Add(new Guest("Inga", new List<int>{1, 6, 7}));
            guests.Add(new Guest("Sasha", new List<int>{2, 3, 4, 5}));

            WeddingService weddingService = new WeddingService();
            int dayIndex = weddingService.dayIndexWhenEveryoneCanCome(guests);
            Assert.Equal(0, dayIndex);
        }

        [Fact]
        public void testDayIndexWhenEveryoneCanCome_AllBusyEveryday()
        {
            List<Guest> guests = new List<Guest>();

            guests.Add(new Guest("Inga", new List<int>{1, 2, 3, 4, 5, 6, 7}));
            guests.Add(new Guest("Sasha", new List<int>{1, 2, 3, 4, 5, 6, 7}));

            WeddingService weddingService = new WeddingService();
            int dayIndex = weddingService.dayIndexWhenEveryoneCanCome(guests);
            Assert.Equal(0, dayIndex);
        }

        [Fact]
        public void testDayIndexWhenEveryoneCanCome_allFree()
        {
            List<Guest> guests = new List<Guest>();
            guests.Add(new Guest("Inga", new List<int>{}));
            guests.Add(new Guest("Sasha", new List<int>{}));

            WeddingService weddingService = new WeddingService();
            int dayIndex = weddingService.dayIndexWhenEveryoneCanCome(guests);
            Assert.Equal(7, dayIndex);
        }

        [Fact]
        public void testDayIndexWhenEveryoneCanCome_noGuests()
        {
            List<Guest> guests = new List<Guest>();

            WeddingService weddingService = new WeddingService();
            int dayIndex = weddingService.dayIndexWhenEveryoneCanCome(guests);
            Assert.Equal(7, dayIndex);
        }

        [Fact]
        public void testGetTheMostInconvenientGuests_poisitiveOneInconvenientGuest()
        {
            List<Guest> guests = new List<Guest>();
            guests.Add(new Guest("Inga", new List<int>{1, 2, 3, 4, 7}));
            guests.Add(new Guest("Sasha", new List<int>{5, 6, 7}));

            List<Guest> expectedResult = new List<Guest>();
            expectedResult.Add(guests.ElementAt(1));

            WeddingService weddingService = new WeddingService();

            List<Guest> actualResult = weddingService.getTheMostInconvenientGuests(guests);

            foreach (var guest in expectedResult)
            {
                Assert.Contains(guest, actualResult);
            }
            Assert.Single(actualResult);
            
        }

        [Fact]
        public void testGetTheMostInconvenientGuests_poisitiveTwoInconvenientGuests()
        {
            List<Guest> guests = new List<Guest>();
            guests.Add(new Guest("Inga", new List<int>{1, 2, 3, 4, 5, 6, 7}));
            guests.Add(new Guest("Sasha", new List<int>{1, 2, 3, 4, 5, 6, 7}));
            guests.Add(new Guest("Lola", new List<int>{5, 6, 7}));

            List<Guest> expectedResult = new List<Guest>();
            expectedResult.Add(guests.ElementAt(0));
            expectedResult.Add(guests.ElementAt(1));

            WeddingService weddingService = new WeddingService();

            List<Guest> actualResult = weddingService.getTheMostInconvenientGuests(guests);

            foreach (var guest in expectedResult)
            {
                Assert.Contains(guest, actualResult);
            }
            Assert.Equal(2, actualResult.Count);
        }


        [Fact]
        public void testGetTheMostInconvenientGuests_negativeAllFree()
        {
            List<Guest> guests = new List<Guest>();
            guests.Add(new Guest("Inga", new List<int>{}));
            guests.Add(new Guest("Sasha", new List<int>{}));

            WeddingService weddingService = new WeddingService();

            List<Guest> actualResult = weddingService.getTheMostInconvenientGuests(guests);

            Assert.Empty(actualResult);
            
        }

        [Fact]
        public void testGetTheMostInconvenientGuests_negativeAllBusyEveryday()
        {
            List<Guest> guests = new List<Guest>();

            WeddingService weddingService = new WeddingService();
            guests.Add(new Guest("Inga", new List<int>{1, 2, 3, 4, 5, 6, 7}));
            guests.Add(new Guest("Sasha", new List<int>{1, 2, 3, 4, 5, 6, 7}));

            List<Guest> expectedResult = new List<Guest>();
            expectedResult.Add(guests.ElementAt(0));
            expectedResult.Add(guests.ElementAt(1));

            List<Guest> actualResult = weddingService.getTheMostInconvenientGuests(guests);

            foreach (var guest in expectedResult)
            {
                Assert.Contains(guest, actualResult);
            }
            Assert.Equal(2, actualResult.Count);
            
        }

        [Fact]
        public void testGetTheMostInconvenientGuests_negativeNoGuests()
        {
            List<Guest> guests = new List<Guest>();

            WeddingService weddingService = new WeddingService();

            List<Guest> actualResult = weddingService.getTheMostInconvenientGuests(guests);

            Assert.Empty(actualResult);
            
        }
    }
}