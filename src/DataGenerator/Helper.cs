using System;
using System.IO;

namespace DataGenerator
{
    /// <summary>
    /// Helper methods
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Full path from the output dir (bin/obj)
        /// </summary>
        public static readonly string OutputPath = Directory.GetCurrentDirectory();

        /// <summary>
        /// Get a random value from a generic Enum
        /// </summary>
        /// <typeparam name="T">The Enum object</typeparam>
        /// <returns>The Enum value</returns>
        public static T RandomEnumValue<T>()
        {
            var values = Enum.GetValues(typeof(T));
            var random = new Random().Next(0, values.Length);
            return (T) values.GetValue(random);
        }

        /// <summary>
        /// Capitalize the first letter from the word
        /// </summary>
        /// <param name="word">Word to change</param>
        /// <returns>String with capitalize char</returns>
        public static string CapitalizeFirstLetter(string word)
        {
            if (string.IsNullOrEmpty(word)) return word;

            return word.Length == 1 ? word.ToUpper() : $"{word.Remove(1).ToUpper()}{word.Substring(1)}";
        }
    }
}