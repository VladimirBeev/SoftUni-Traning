namespace Book.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    public class Tests
    {
        [Test]
        public void ConstructorWorkCorrectly()
        {
            var expectedName = "Test";
            var expextedauthor = "Vlado";
            var actualData = new Book("Test", "Vlado");
            Assert.That(actualData.BookName, Is.EqualTo(expectedName));
            Assert.That(actualData.Author, Is.EqualTo(expextedauthor));
        }
        [Test]
        public void TestCount()
        {
            var actualData = new Book("Test", "Vlado");
            actualData.AddFootnote(10, "Haha");
            Assert.That(actualData.FootnoteCount, Is.EqualTo(1));
        }
        [Test]
        public void TestBookException()
        {
            string expectedNameBook = null;
            var expextedauthor = "Vlado";
            Assert.Throws<ArgumentException>(() =>
            {
                var actualData = new Book(expectedNameBook, expextedauthor);
            }, $"Invalid {expectedNameBook}!");
        }
        [Test]
        public void TestBookException1()
        {
            string expectedNameBook = String.Empty;
            var expextedauthor = "Vlado";
            Assert.Throws<ArgumentException>(() =>
            {
                var actualData = new Book(expectedNameBook, expextedauthor);
            }, $"Invalid {expectedNameBook}!");
        }
        [Test]
        public void TestBookWork()
        {
            string expectedNameBook = "Test";
            var expextedauthor = "Vlado";
            var book = new Book(expectedNameBook,expextedauthor);
            Assert.That(book.BookName,Is.EqualTo(expectedNameBook));
        }
        [Test]
        public void TestAuthorException()
        {
            string expectedNameBook = "Test";
            var expextedauthor = String.Empty;
            Assert.Throws<ArgumentException>(() =>
            {
                var actualData = new Book(expectedNameBook, expextedauthor);
            }, $"Invalid {expextedauthor}!");
        }
        [Test]
        public void TestAuthorException1()
        {
            string expectedNameBook = "Test";
            string expextedauthor = null;
            Assert.Throws<ArgumentException>(() =>
            {
                var actualData = new Book(expectedNameBook, expextedauthor);
            }, $"Invalid {expextedauthor}!");
        }
        [Test]
        public void TestAuthorWork()
        {
            string expectedNameBook = "Test";
            var expextedauthor = "Vlado";
            var book = new Book(expectedNameBook, expextedauthor);
            Assert.That(book.Author, Is.EqualTo(expextedauthor));
        }
        [Test]
        public void TestAddFootNoteException()
        {
            var footNotenumber = 10;
            var footTex = "Test";
            var actualData = new Book("Test", "Vlado");
            actualData.AddFootnote(footNotenumber, footTex);
            Assert.Throws<InvalidOperationException>(() =>
            {
                actualData.AddFootnote(footNotenumber, footTex);
            }, "Footnote already exists!");
        }
        [Test]
        public void TestAddFootNoteWork()
        {
            var footNotenumber = 10;
            var footTex = "Test";
            var actualData = new Book("Test", "Vlado");
            actualData.AddFootnote(footNotenumber, footTex);
            Assert.That(actualData.FootnoteCount, Is.EqualTo(1));
        }
        [Test]
        public void TestFindFootnoteException()
        {
            var invalidFootNetnum = 9;
            var footNotenumber = 10;
            var footTex = "Test";
            var actualData = new Book("Test", "Vlado");
            actualData.AddFootnote(footNotenumber, footTex);
            Assert.Throws<InvalidOperationException>(() =>
            {
                actualData.FindFootnote(invalidFootNetnum);
            }, "Footnote doesn't exists!");
        }
        [Test]
        public void TestFindFootnoteException1()
        {
            var invalidFootNetnum = 11;
            var footNotenumber = 10;
            var footTex = "Test";
            var actualData = new Book("Test", "Vlado");
            actualData.AddFootnote(footNotenumber, footTex);
            Assert.Throws<InvalidOperationException>(() =>
            {
                actualData.FindFootnote(invalidFootNetnum);
            }, "Footnote doesn't exists!");
        }
        [Test]
        public void TestFindFootnoteWork()
        {
            
            var footNote = new Dictionary<int, string>();
            var actualData = new Book("Test", "Vlado");
            actualData.AddFootnote(10,"Yes");
            actualData.FindFootnote(10);
            var ret = $"Footnote #10: Yes";
            Assert.That(ret,Is.EqualTo(actualData.FindFootnote(10)));
        }
        [Test]
        public void TestAlterFootnoteException()
        {
            var footNote = new Dictionary<int, string>();
            var footNotenumber = 10;
            int invalidNumber = 5;
            var footTex = "Test";
            var actualData = new Book(footTex, "Vlado");
            actualData.AddFootnote(footNotenumber, footTex);
            footNote.Add(footNotenumber, footTex);

            var text = footNote[footNotenumber];
            Assert.Throws<InvalidOperationException>(() =>
            {
                actualData.AlterFootnote(invalidNumber,footTex);
            }, "Footnote does not exists!");
        }
        [Test]
        public void TestAlterFootnoteWork()
        {
            var footNote = new Dictionary<int, string>();
            var footNotenumber = 10;
            var footTex = "Test";
            var newText = "Test1";
            var actualData = new Book(footTex, "Vlado");
            actualData.AddFootnote(footNotenumber, footTex);
            footNote.Add(footNotenumber, footTex);
            actualData.AlterFootnote(footNotenumber,newText);

            var text = footNote[footNotenumber] = newText;
            Assert.That(text, Is.EqualTo(newText));
        }
    }
}