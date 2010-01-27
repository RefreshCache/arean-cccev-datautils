/**********************************************************************
* Description:  A collection of data-type utility classes 
* Created By:	Dallon Feldner @ Central Christian Church of the East Valley
* Date Created:	???
*
* $Workfile: EmailUtils.cs $
* $Revision: 1 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/EmailUtils.cs   1   2010-01-27 10:18:58-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/EmailUtils.cs $
*  
*  Revision: 1   Date: 2010-01-27 17:18:58Z   User: JasonO 
*  Breaking DataUtils collection of classes into separate files. 
**********************************************************************/

using System.Text.RegularExpressions;

namespace Arena.Custom.Cccev.DataUtils
{
    /// <summary>
    /// Methods relating to email and email addresses.
    /// </summary>
    public class EmailUtils
    {
        /// <summary>
        /// Returns true if the given string is a valid email address.
        /// </summary>
        /// <param name="email">The string to validate</param>
        /// <returns>true if valid email, false otherwise</returns>
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }
    }
}
