using System;
using Xunit;

namespace Gradebook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            var book = new InMemoryBook("");

            book.AddGrade(98.4);
            book.AddGrade(55.6);
            book.AddGrade(87.4);

            //act
            var result = book.GetStatistics();

            //assert

            Assert.Equal(98.4, result.High, 1);
            Assert.Equal(55.6, result.Low, 1);
            Assert.Equal(80.5, result.Average, 1);
        }
    }
}
