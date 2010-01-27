/**********************************************************************
* Description:	TBD
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created:	TBD
*
* $Workfile: Constants.cs $
* $Revision: 5 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/Constants.cs   5   2009-12-09 10:22:31-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/Constants.cs $
*  
*  Revision: 5   Date: 2009-12-09 17:22:31Z   User: JasonO 
*  Adding constant for zero value 
*  
*  Revision: 4   Date: 2009-07-08 18:30:47Z   User: JasonO 
*  
*  Revision: 3   Date: 2009-07-06 15:47:27Z   User: JasonO 
*  
*  Revision: 2   Date: 2009-06-10 21:33:09Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-06-10 17:11:25Z   User: JasonO 
**********************************************************************/

using System;

namespace Arena.Custom.Cccev.DataUtils
{
    public static class Constants
    {
        public const string NULL_STRING = "";
        public const decimal NULL_AMOUNT = 0M;
        public const decimal NULL_DECIMAL = -1M;
        public const int NULL_INT = -1;
        public const bool NULL_BOOLEAN = false;
        public static readonly DateTime NULL_DATE = DateTime.Parse("1/1/1900");
        public const int ZERO = 0;
    }
}
