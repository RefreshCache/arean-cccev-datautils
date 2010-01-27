/**********************************************************************
* Description:  Object to encapsulate a collection of validation errors
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 10/28/2009
*
* $Workfile: ValidationException.cs $
* $Revision: 1 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/ValidationException.cs   1   2009-12-28 08:15:17-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/ValidationException.cs $
*  
*  Revision: 1   Date: 2009-12-28 15:15:17Z   User: JasonO 
*  Adding ValidationException 
**********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Arena.Custom.Cccev.DataUtils
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; set; }

        public override string Message
        {
            get
            {
                return string.Join(";", Errors.ToArray());
            }
        }

        public ValidationException(IEnumerable<string> errors)
        {
            Errors = errors.ToList();
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
