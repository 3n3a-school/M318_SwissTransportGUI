using System;
using SwissTransportGUI.Model;
using FluentAssertions;
using GMap.NET;
using Xunit;

namespace SwissTransportGUITest
{
    public class DepartureEntryTest
    {

        [Fact]
        public void DepartureEntry()
        {
            DepartureEntry test1 = new DepartureEntry()
            {
                Direction = "Zürich",
                Platform = "2",
                DepartureTime = "20:00:00",
                Line = "S1"
            };
            test1.Should().BeOfType<DepartureEntry>();
        }
    }
}