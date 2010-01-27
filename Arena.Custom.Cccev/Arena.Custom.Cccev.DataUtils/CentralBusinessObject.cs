/**********************************************************************
* Description:  Common business class to standardize management of entities
*               and data context with Linq to SQL
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 12/28/2009
*
* $Workfile: CentralBusinessObject.cs $
* $Revision: 2 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/CentralBusinessObject.cs   2   2010-01-04 16:00:28-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/CentralBusinessObject.cs $
*  
*  Revision: 2   Date: 2010-01-04 23:00:28Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-12-29 17:11:22Z   User: JasonO 
**********************************************************************/

namespace Arena.Custom.Cccev.DataUtils
{
    /// <summary>
    /// Base class to manage concurrency of Entities and DataContext within 
    /// Linq to SQL.
    /// </summary>
    /// <typeparam name="TEntity">Entity Type</typeparam>
    /// <typeparam name="TContext">DataContext Type</typeparam>
    public abstract class CentralBusinessObject<TEntity, TContext>
    {
        public abstract TEntity Entity { get; set; }
        public abstract TContext Context { get; set; }
    }
}
