/**********************************************************************
* Description:  A collection of data-type utility classes 
* Created By:	Dallon Feldner @ Central Christian Church of the East Valley
* Date Created:	???
*
* $Workfile: StringUtils.cs $
* $Revision: 4 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/StringUtils.cs   4   2010-11-30 15:17:31-07:00   nicka $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/StringUtils.cs $
*  
*  Revision: 4   Date: 2010-11-30 22:17:31Z   User: nicka 
*  Added Jason's handy TruncateTitle string utility. 
*  
*  Revision: 3   Date: 2010-08-04 21:35:58Z   User: JasonO 
*  Adding extension method to determine whether a list of intergers is valid 
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
		/// Intelligently truncates a string by words -- useful when truncating titles.
		/// </summary>
		/// <param name="title">The text to truncate</param>
		/// <param name="length">The maximum length at which to truncate the string</param>
		/// <returns>Returns the truncated title </returns>
		public static string GetTruncateTitle( string title, int length )
		{
			string retval = "";
			string[] titleArray = title.Split( new char[] { ' ' } );

			foreach ( string word in titleArray )
			{
				if ( ( retval.Length + word.Length + 1 ) <= length )
				{
					retval += " " + word;
				}
				else
				{
					break;
				}
			}

			return retval;
		}

        /// <summary>
        /// Truncates a string and appends a '...'
        /// </summary>
        /// <param name="value">The string to truncate</param>
        /// <param name="length">The length at which to truncate the string</param>
        /// <returns>Returns the truncated string with '...' appended</returns>
        public static string GetTruncatedString(string value, int length)
        {
			return GetTruncatedString( value, length, "..." );
        }

		/// <summary>
		/// Truncates a string	
		/// </summary>
		/// <param name="value">The string to truncate</param>
		/// <param name="length">The length at which to truncate the string</param>
		/// <param name="append">The string to append to the end of the returned value</param>
		/// <returns>Returns the truncated string</returns>
		public static string GetTruncatedString( string value, int length, string append )
		{
			if ( value.Length > length )
			{
				return value.Substring( 0, length - 2 ) + append;
			}

			return value;
		}

        /// <summary>
        /// Will attempt to determine if a string is a valid list of intergers
        /// </summary>
        /// <param name="idList">string to parse</param>
        /// <returns>true/false depending on outcome of attempted parsing to int</returns>
        public static bool IsValidIDList(this string idList)
        {
            try
            {
                if (!string.IsNullOrEmpty(idList))
                {
                    idList.SplitAndConvertTo<int>(new[] { ',', ' ', ';', '|' }, Convert.ToInt32);
                }

                return true;
            }
            catch
            {
                return false;
            }
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
