/**********************************************************************
* Description:	TBD
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created:	TBD
*
* $Workfile: ObjectCopier.cs $
* $Revision: 1 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/ObjectCopier.cs   1   2009-07-21 13:39:00-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/ObjectCopier.cs $
*  
*  Revision: 1   Date: 2009-07-21 20:39:00Z   User: JasonO 
*  Adding object cloning functionality to common library. 
**********************************************************************/

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Arena.Custom.Cccev.DataUtils
{
    public static class ObjectCopier
    {
        /// <summary>
        /// Perform a deep copy of a Serializable object.
        /// See http://stackoverflow.com/questions/78536/cloning-objects-in-c for more info
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>Cloned object.</returns>
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("This type must be serializable.", "source");
            }

            if (ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            
            using (Stream stream = new MemoryStream())
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T) formatter.Deserialize(stream);
            }
        }
    }
}
