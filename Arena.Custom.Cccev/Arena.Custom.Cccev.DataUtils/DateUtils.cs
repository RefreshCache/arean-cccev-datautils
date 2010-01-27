/**********************************************************************
* Description:  A collection of data-type utility classes 
* Created By:	Dallon Feldner @ Central Christian Church of the East Valley
* Date Created:	???
*
* $Workfile: DateUtils.cs $
* $Revision: 1 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/DateUtils.cs   1   2010-01-27 10:18:58-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/DateUtils.cs $
*  
*  Revision: 1   Date: 2010-01-27 17:18:58Z   User: JasonO 
*  Breaking DataUtils collection of classes into separate files. 
*  
*  Revision: 18   Date: 2009-08-19 20:21:59Z   User: nicka 
*  Updated GetFractionalAge to use 3 decimal precision to match Arena 2009.1 
*  min/max age values in Attendance Types 
*  
*  Revision: 16   Date: 2009-03-21 23:50:04Z   User: nicka 
*  Corrected another index out of range (Index and length must refer to a 
*  location within the string. Parameter name: length) issue. 
*  
*  Revision: 10   Date: 2009-02-23 16:50:51Z   User: JasonO 
*  Truncating fractional age to 2 decimal places. 
*  
*  Revision: 9   Date: 2009-01-07 01:11:16Z   User: nicka 
*  Added GetAgeInYears() 
*  
*  Revision: 8   Date: 2009-01-07 00:33:29Z   User: nicka 
*  Added GetAgeInMonths() calculation 
*
*  Revision: 5   Date: 2008-12-10 00:28:31Z   User: JasonO 
*  Updating date util class. 
*  
*  Revision: 4   Date: 2008-12-03 22:43:44Z   User: JasonO 
*  Addign DateUtils class w/ fractional age static method. 
*
**********************************************************************/

using System;

namespace Arena.Custom.Cccev.DataUtils
{
    /// <summary>
    /// Methods relating to datetime information.
    /// </summary>
    public static class DateUtils
    {
        /// <summary>
        /// Calculates fractional age based on datetime passed in.  Will return a decimal value truncated to 3 decimal places.
        /// </summary>
        /// <param name="birthdate"></param>
        /// <returns>fractional age truncated to 3 decimal places</returns>
        public static decimal GetFractionalAge(DateTime birthdate)
        {
            // get the last birthday
            DateTime today = DateTime.Now;
            int years = today.Year - birthdate.Year;
            DateTime last = birthdate.AddYears(years);
            if (last > today)
            {
                last = last.AddYears(Constants.NULL_INT);
                years--;
            }
            // get the next birthday
            DateTime next = last.AddYears(1);
            // calculate the number of days between them
            double yearDays = (next - last).Days;
            // calcluate the number of days since last birthday
            double days = (today - last).Days;
            // calculate exaxt age
            double exactAge = years + (days / yearDays);

            // now return a decimal which includes trailing zeros
            string age = exactAge.ToString("#0.00000");
            string truncatedAge = age.Substring(0, age.LastIndexOf('.') + 4);

            return decimal.Parse(truncatedAge);
        }

        /// <summary>
        /// Calculates the age in whole years for the given birthday.
        /// </summary>
        /// <param name="birthday">A birthdate</param>
        /// <returns>number of whole years</returns>
        public static int GetAgeInYears(DateTime birthday)
        {
            int monthDelta = GetDeltaInMonths(birthday, DateTime.Now);
            return monthDelta / 12;
        }

        /// <summary>
        /// Calculates the age in whole months for the given birthday.
        /// </summary>
        /// <param name="birthday">A birthdate</param>
        /// <returns>number of whole months</returns>
        public static int GetAgeInMonths(DateTime birthday)
        {
            return GetDeltaInMonths(birthday, DateTime.Now);
        }

        /// <summary>
        /// An algorthim to determine the number of whole months
        /// between two dates (by Greg Golden).
        /// </summary>
        /// <param name="then">A date.</param>
        /// <param name="now">Another date.</param>
        /// <returns>number of whole months between the two dates</returns>
        public static int GetDeltaInMonths(DateTime then, DateTime now)
        {
            int thenMonthsSince1900 = 12 * (then.Year - 1900) + then.Month;
            int nowMonthsSince1900 = 12 * (now.Year - 1900) + now.Month;

            int monthsOld = nowMonthsSince1900 - thenMonthsSince1900;

            if (now.Day < then.Day)
            {
                monthsOld--;
            }

            return monthsOld;
        }

        /// <summary>
        /// Returns the date of the starting week. This method assumes
        /// the week starts on Monday.
        /// </summary>
        /// <param name="date">DateTime to base calculation on</param>
        /// <returns>DateTime of the week's starting date</returns>
        public static DateTime GetWeekStartDate(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Tuesday:
                    return date.AddDays(-1);
                case DayOfWeek.Wednesday:
                    return date.AddDays(-2);
                case DayOfWeek.Thursday:
                    return date.AddDays(-3);
                case DayOfWeek.Friday:
                    return date.AddDays(-4);
                case DayOfWeek.Saturday:
                    return date.AddDays(-5);
                case DayOfWeek.Sunday:
                    return date.AddDays(-6);
                default:
                    return date;
            }
        }
    }
}
