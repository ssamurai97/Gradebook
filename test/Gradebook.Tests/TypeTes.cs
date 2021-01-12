using System;
using Xunit;

namespace Gradebook.Tests
{
    public class TypeTests{

            
            [Fact]
        public void Test1()
            {
                var x =GetInt();

                SetInt(ref x);
                 
    

                Assert.Equal(89, x);
            
            }
        [Fact]
        public void StringBehaveLikeValueType()
        {
            string name ="Kuchlong";

            name = MakeUpperCaste(name);

            Assert.Equal("KUCHLONG", name);
        }

        private string MakeUpperCaste(string v)
        {
             return v.ToUpper();
        }

        private void SetInt(ref int x)
        {
            x = 89;
        }

        private int GetInt()
        {
             return 6;
        }

        [Fact]
        public void PassByReference()
        {
        //Given
         var book1 = GetBook("Book 1");

         GetBookSetName(ref book1, "NewBook");

         Assert.Equal("NewBook", book1.Name);
        }

        public void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
          
          [Fact]
        public void PassByValue()
        {
        //Given
         var book1 = GetBook("Book 1");

         GetBookSetName(book1, "NewBook");

         Assert.Equal("Book 1", book1.Name);
        }

        public void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
        //Given
         var book1 = GetBook("Book 1");

         SetName(book1, "New name");

         Assert.Equal("New name", book1.Name);
        }

        public void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnDifferentObjects()
        {
        //Given
         var book1 = GetBook("Book 1");
         var book2 = GetBook("Book 2");

         Assert.Equal("Book 1", book1.Name);
         Assert.Equal("Book 2", book2.Name);
        }

         [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
        //Given
         var book1 = GetBook("Book 1");
         var book2 = book1;

         Assert.Same(book1, book2);
        }

        InMemoryBook GetBook(string book)
        {
            return new InMemoryBook(book);
        }
    }
}
