using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicMoq.DAL;
using Moq;
using System.Collections.Generic;

namespace MagicMoq.Tests.DAL
{
    [TestClass]
    public class QuestionsTests
    {
        private Mock<Answers> mockAnswers { get; set; }

        private Mock<Questions> mockQuestions { get; set; }

        private Questions questions { get; set; }

        // Runs before every test
        [TestInitialize]
        public void Setup()
        {
            mockAnswers = new Mock<Answers>();
            mockQuestions = new Mock<Questions>();
            questions = new Questions(mockAnswers.Object);
        }

        // Runs after every test
        [TestCleanup]
        public void Cleanup()
        {
            mockAnswers = null;
        }

        [TestMethod]
        public void EnsureICanCreateQuestionsInstance()
        {
            Assert.IsNotNull(mockQuestions);
        }

        [TestMethod]
        public void EnsureICanCreateAnswersInstance()
        {
            Assert.IsNotNull(mockAnswers);
        }

        [TestMethod]
        public void EnsureQuestionsReturnsAnswersInstance()
        { 
            Assert.IsNotNull(questions.Wand);
        }

        [TestMethod]
        public void EnsureQuestionsReturnsInjectedAnswersInstance()
        {
            Assert.IsNotNull(questions.Wand);
        }

        [TestMethod]
        public void EnsureSayHelloReturnsHelloWorld()
        {
            // Add code that mocks the "HelloWorld" method response
            mockAnswers.Setup(a => a.HelloWorld()).Returns("Hello World");

            // Act
            string expected_result = "Hello World";
            string actual_result = questions.SayHelloWorld();

            // Assert
            Assert.AreEqual(expected_result, actual_result);
            
            // Methods used in this test
            mockAnswers.Verify(a => a.HelloWorld());
        }

        [TestMethod]
        public void EnsureOneMinusOneReturnsZero()
        {
            mockAnswers.Setup(a => a.One()).Returns(0);

            // Act
            int expected_result = 0;
            int actual_result = questions.OneMinusOne();

            // Assert
            Assert.AreEqual(expected_result, actual_result);
            
            // Methods used in this test
            mockAnswers.Verify(a => a.One());
        }

        [TestMethod]
        public void EnsureOnePlusOneReturnsTwo()
        {
            mockAnswers.Setup(a => a.One()).Returns(1);

            // Act
            int expected_result = 2;
            int actual_result = questions.OnePlusOne();

            // Assert
            Assert.AreEqual(expected_result, actual_result);

            // Methods used in this test
            mockAnswers.Verify(a => a.One());
        }

        [TestMethod]
        public void EnsureOnePlusTwoReturnsThree()
        {
            mockAnswers.Setup(a => a.One()).Returns(1);
            mockAnswers.Setup(a => a.Two()).Returns(2);

            int expectedResult = 3;
            int actualResult = questions.OnePlusTwo();

            Assert.AreEqual(expectedResult, actualResult);
            
            // Ensures the proper tests were run
            mockAnswers.Verify(a => a.One());
            mockAnswers.Verify(a => a.Two());
        }

        [TestMethod]
        public void EnsureThisReturnsTrue()
        {
            mockAnswers.Setup(a => a.True()).Returns(true);
            // Act
            bool expected_result = true;
            bool actual_result = questions.ReturnTrue();

            // Assert
            Assert.AreEqual(expected_result, actual_result);

            // Methods used in this test
            mockAnswers.Verify(a => a.True());
        }

        [TestMethod]
        public void EnsureThisReturnsFalse()
        {
            mockAnswers.Setup(a => a.False()).Returns(false);
            // Act
            bool expected_result = false;
            bool actual_result = questions.ReturnFalse();

            // Assert
            Assert.AreEqual(expected_result, actual_result);

            // Methods used in this test
            mockAnswers.Verify(a => a.False());
        }

        [TestMethod]
        public void EnsureSayNothingReturnsEmptyString()
        {
            mockAnswers.Setup(a => a.EmptyString()).Returns("");

            // Act
            string expected_result = "";
            string actual_result = questions.SayNothing();
            
            // Assert
            Assert.AreEqual(expected_result, actual_result);

            // Methods used in this test
            mockAnswers.Verify(a => a.EmptyString());
        }

        [TestMethod]
        public void EnsureTwoPlusTwoReturnsFour()
        {
            mockAnswers.Setup(a => a.Two()).Returns(2);

            int expectedResult = 4;
            int actualResult = questions.TwoPlusTwo();

            Assert.AreEqual(expectedResult, actualResult);

            // Methods used in this test
            mockAnswers.Verify(a => a.Two());
        }

        [TestMethod]
        public void EnsureFourMinusTwoPlusOneReturnsThree()
        {
            mockAnswers.Setup(a => a.Four()).Returns(4);
            mockAnswers.Setup(a => a.Two()).Returns(2);
            mockAnswers.Setup(a => a.One()).Returns(1);

            int expectedResult = 3;
            int actualResult = questions.FourMinusTwoPlusOne();

            Assert.AreEqual(expectedResult, actualResult);

            // Methods used in this test
            mockAnswers.Verify(a => a.Four());
            mockAnswers.Verify(a => a.Two());
            mockAnswers.Verify(a => a.One());
        }

        [TestMethod]
        public void EnsureFourMinusTwoReturnsTwo()
        {
            mockAnswers.Setup(a => a.Four()).Returns(4);
            mockAnswers.Setup(a => a.Two()).Returns(2);

            int expectedResult = 2;
            int actualResult = questions.FourMinusTwo();

            Assert.AreEqual(expectedResult, actualResult);

            // Methods used in this test
            mockAnswers.Verify(a => a.Four());
            mockAnswers.Verify(a => a.Two());
        }

        [TestMethod]
        public void EnsureCountToFiveReturnsListOfFiveInts()
        {
            mockAnswers.Setup(a => a.ListOfNInts(It.Is<int>(i => i == 5))).Returns(new List<int> { 1, 2, 3, 4, 5});

            List<int> expectedResult = new List<int> {1, 2, 3, 4, 5};
            List<int> actualResult = questions.CountToFive();

            CollectionAssert.AreEqual(expectedResult, actualResult);

            // Methods used in this test
            mockAnswers.Verify(a => a.ListOfNInts(It.IsAny<int>()));
        }

        [TestMethod]
        public void EnsureFirstThreeEvenIntsReturnsListOfThreeEvenInts()
        {
            mockAnswers.Setup(a => a.Two()).Returns(2);
            mockAnswers.Setup(a => a.Four()).Returns(4);

            List<int> expectedResult = new List<int> { 2, 4, 6 };
            List<int> actualResult = questions.FirstThreeEvenInts();

            CollectionAssert.AreEqual(expectedResult, actualResult);

            // Methods used in this test
            mockAnswers.Verify(a => a.Two());
            mockAnswers.Verify(a => a.Four());
        }

        [TestMethod]
        public void EnsureFirstThreeOddIntsReturnsListOfThreeOddInts()
        {
            mockAnswers.Setup(a => a.One()).Returns(1);
            mockAnswers.Setup(a => a.Two()).Returns(2);
            mockAnswers.Setup(a => a.Three()).Returns(3);

            List<int> expectedResult = new List<int> { 1, 3, 5 };
            List<int> actualResult = questions.FirstThreeOddInts();

            CollectionAssert.AreEqual(expectedResult, actualResult);

            // Methods used in this test
            mockAnswers.Verify(a => a.One());
            mockAnswers.Verify(a => a.Two());
            mockAnswers.Verify(a => a.Three());
        }

        [TestMethod]
        public void EnsureZeroPlusZeroReturnsZero()
        {
            mockAnswers.Setup(a => a.Zero()).Returns(0);

            int expectedResult = 0;
            int actualResult = questions.ZeroPlusZero();

            Assert.AreEqual(expectedResult, actualResult);

            // Methods used in this test
            mockAnswers.Verify(a => a.Zero());
        }

        [TestMethod]
        public void EnsureFourPlusZeroReturnsFour()
        {
            mockAnswers.Setup(a => a.Zero()).Returns(0);
            mockAnswers.Setup(a => a.Four()).Returns(4);

            int expectedResult = 4;
            int actualResult = questions.FourPlusZero();

            Assert.AreEqual(expectedResult, actualResult);

            // Ensures the proper tests were run
            mockAnswers.Verify(a => a.Zero());
            mockAnswers.Verify(a => a.Four());
        }

        [TestMethod]
        public void EnsureTwoMinusZeroReturnsTwo()
        {
            mockAnswers.Setup(a => a.Zero()).Returns(0);
            mockAnswers.Setup(a => a.Two()).Returns(2);

            int expectedResult = 2;
            int actualResult = questions.TwoMinusZero();

            Assert.AreEqual(expectedResult, actualResult);

            // Ensures the proper tests were run
            mockAnswers.Verify(a => a.Zero());
            mockAnswers.Verify(a => a.Two());
        }

    }
}
