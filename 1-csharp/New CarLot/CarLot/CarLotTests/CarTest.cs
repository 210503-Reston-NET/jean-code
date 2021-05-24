using System;
using Xunit;
using CarLotModels;
namespace CarLotTests
{
    public class CarTest
    {
        [Fact]
        public void ModelShouldSetValidData()
        {
            string model = "Honda";
            Car test = new Car();

            test.Model = model;

            Assert.Equal(model, test.Model);
        }
        [Theory]
        [InlineData("2345678i")]
        [InlineData("beahfhr1")]
        public void ModelShouldNotSetInvalidData(string input)
        {
            Car test = new Car();

            Assert.Throws<Exception>(() => test.Model = input);
        }
    }
}