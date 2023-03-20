using SE2___Lab1;
using System;
using Xunit;

namespace StringCalculatorTestProject
{
    public class UnitTest1
    {
        StringCalculator SC = new StringCalculator();
        [Fact]
        public void Test1()
        {
            Assert.Equal(0, SC.Calculate(""));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(3, SC.Calculate("3"));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(7, SC.Calculate("3,4"));
        }

        [Fact]
        public void Test4()
        {
            Assert.Equal(18, SC.Calculate("4\n4,10"));
            Assert.Equal(18, SC.Calculate("4,04\n10"));
        }

        [Fact]
        public void Test5()
        {
            //Negative
            Action action = () => SC.Calculate("-3,2");
            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("Negative numbers are not allowed!", exception.Message);
            
        }

        [Fact]
        public void Test6()
        {
            Assert.Equal(1007, SC.Calculate("3,4,1000"));
            Assert.Equal(7, SC.Calculate("3,4,1001"));
        }

        [Fact]
        public void Test7()
        {
            Assert.Equal(17, SC.Calculate("//%3,4%10"));
            Assert.Equal(7, SC.Calculate("//#3#4#1001"));
            Assert.Equal(17, SC.Calculate("//,3,4,10"));
        }

        [Fact]
        public void Test8()
        {
            Assert.Equal(107, SC.Calculate("//[#%#]3#%#4\n100"));
            Assert.Equal(7, SC.Calculate("3#%#4#%#1001"));
            Assert.Equal(107, SC.Calculate("3#%#4#%#100"));
        }

        [Fact]
        public void Test9()
        {
            Assert.Equal(107, SC.Calculate("//[%][#]3%4%100"));
            Assert.Equal(150, SC.Calculate("//[#%#][#][%][^$&]5#%#5%100#35^$&5#"));
            Assert.Equal(150, SC.Calculate("//[#%#][#][%][^$&]5#%#5%100#35^$&5#@5"));
            Assert.Equal(160, SC.Calculate("//[#%#][#][%][^$&]5#%#5%100#35^$&5#10"));
        }
    }
}
