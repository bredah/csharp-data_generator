using System;
using Xunit;

namespace DataGenerator.Tests
{
    public class RandNumber
    {
        private int _initValue = 1;
        private int _maxValue = 5;

        /// <summary>
        ///     Sum the range
        /// </summary>
        /// <param name="initValue">Min value</param>
        /// <param name="maxValue">Max value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>Result from the sum</returns>
        private static int SumRange(int initValue, int maxValue)
        {
            if (initValue >= maxValue)
                throw new ArgumentException(
                    $"The initial value {initValue.ToString()} is over them max value {maxValue.ToString()}");
            var resultValues = 0;
            for (var i = initValue; i <= maxValue; i++) resultValues += i;
            return resultValues;
        }

        [Fact]
        public void InvalidRange_Exception()
        {
            _initValue = 3;
            _maxValue = 1;
            Exception ex = Assert.Throws<ArgumentException>(() => SumRange(_initValue, _maxValue));
            Assert.Equal($"The initial value {_initValue.ToString()} is over them max value {_maxValue.ToString()}",
                ex.Message);
        }

        [Fact]
        public void ValidRange()
        {
            _initValue = 1;
            _maxValue = 1000000;
            var resultValues = SumRange(_initValue, _maxValue);
            Assert.Equal(1784293664, resultValues);
        }
    }
}