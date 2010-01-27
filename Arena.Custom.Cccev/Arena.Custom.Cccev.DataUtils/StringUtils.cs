/**********************************************************************
* Description:  A collection of data-type utility classes 
* Created By:	Dallon Feldner @ Central Christian Church of the East Valley
* Date Created:	???
*
* $Workfile: StringUtils.cs $
* $Revision: 2 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/StringUtils.cs   2   2010-01-27 10:22:48-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/StringUtils.cs $
*  
*  Revision: 2   Date: 2010-01-27 17:22:48Z   User: JasonO 
*  
*  Revision: 1   Date: 2010-01-27 17:18:28Z   User: JasonO 
*  Adding new generic functionality to conversion of collections. 
*  
*  
*  Revision: 17   Date: 2009-03-23 21:57:45Z   User: DallonF 
*  Fixed ToInt32's handling of null strings 
*  
*  Revision: 14   Date: 2009-03-02 23:18:25Z   User: nicka 
*  Added intelligence to string.ToInt32() 
**********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Arena.Custom.Cccev.DataUtils
{
    /// <summary>
    /// Methods relating to string manipulation.
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Truncates a string	
        /// </summary>
        /// <param name="value">The string to truncate</param>
        /// <param name="length">The length at which to truncate the string</param>
        /// <returns>Returns the truncated string</returns>
        public static string GetTruncatedString(string value, int length)
        {
            if (value.Length > length)
            {
                return value.Substring(0, length - 2) + "...";
            }

            return value;
        }

        /// <summary>
        /// Splits a string of values into a collection of the given type.
        /// </summary>
        /// <typeparam name="T">Type to output</typeparam>
        /// <param name="values">Character-delimited values</param>
        /// <param name="delimiters">Array of separators</param>
        /// <param name="converter">Func to perform type conversion (ie: Convert.ToInt32)</param>
        /// <returns>Strongly typed collection of values</returns>
        public static IEnumerable<T> SplitAndConvertTo<T>(this string values, char[] delimiters, Func<string, T> converter)
        {
            return values.Split(delimiters).ConvertOutput(converter);
        }

        /// <summary>
        /// Converts a collection of values from one type to another.
        /// </summary>
        /// <typeparam name="TInput">Type to convert from</typeparam>
        /// <typeparam name="TOutput">Type to convert to</typeparam>
        /// <param name="input">Collection to convert</param>
        /// <param name="converter">Func to perform type conversion (ie: Convert.ToInt32)</param>
        /// <returns></returns>
        public static IEnumerable<TOutput> ConvertOutput<TInput, TOutput>(this IEnumerable<TInput> input, Func<TInput, TOutput> converter)
        {
            return input.Select(converter).ToList();
        }

        /// <summary>
        /// This method is deprecated. Please use SplitAndConvertTo() instead
        /// </summary>
        /// <param name="ints">Comma-delimited list of integers</param>
        /// <returns>Collection of integers</returns>
        [Obsolete("This method is deprecated and has been replaced by SplitAndConvertTo() extension method.")]
        public static IEnumerable<int> GetCommaSeperatedInts(string ints)
        {
            return ints.SplitAndConvertTo<int>(new[] { ',' }, Convert.ToInt32);

            // Formerly:
            // return ints.Split(',').Where(s => s.Trim() != String.Empty).Select(s => int.Parse(s));
        }

        /// <summary>
        /// Converts a string to an integer if possible
        /// </summary>
        /// <param name="s">The string to convert</param>
        /// <returns>The numerical value of the string, or -1 if string could not be converted.</returns>
        public static int ToInt32(this string s)
        {
            int result;

            if (s == null || !int.TryParse(s.Trim(), out result))
            {
                result = Constants.NULL_INT;
            }

            return result;
        }
    }
}
