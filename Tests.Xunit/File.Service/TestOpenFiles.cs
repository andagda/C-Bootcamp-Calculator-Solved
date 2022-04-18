using Xunit;
using File.Service;
using System;

namespace Tests.Xunit.File.Service
{
    public class TestOpenFiles
    {
        [Fact]
        public void OpenJson_ShouldThrowException_WhenInvalidJSONFileIsOpened()
        {
            // Arrange
            var inputFile = "calculatorinputinvalid.json";

            // Act  and Assert
            Assert.ThrowsAny<Exception>(() => OpenFiles.OpenJson(inputFile));
            
        }

        [Fact]
        public void OpenJson_ShouldNotThrow_WhenValidJSONFileIsOpened()
        {
            // Arrange
            var inputFile = "calculatorinput.json";

            //Act
            var exception = Record.Exception(() => OpenFiles.OpenJson(inputFile));

            //Assert
            Assert.Null(exception);

        }

        [Fact]
        public void OpenJson_ShouldThrowException_WhenValidJSONFileWithACharacterInDecimalArray()
        {
            // Arrange
            var inputFile = "calculatorinputinvalidvalues.json";

            // Act  and Assert
            Assert.ThrowsAny<Exception>(() => OpenFiles.OpenJson(inputFile));

        }
    }
}
