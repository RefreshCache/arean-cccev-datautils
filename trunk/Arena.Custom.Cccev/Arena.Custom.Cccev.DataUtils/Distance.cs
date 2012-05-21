/**********************************************************************
* Description:  Distance Calculations
* Created By:	Nick Airdo @ Central Christian Church AZ (Cccev)
* Date Created:	5/7/2012
*
* $Workfile: Distance.cs $
* $Revision: 1 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/Distance.cs   1   2012-05-21 14:26:48-07:00   nicka $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/Distance.cs $
*  
*  Revision: 1   Date: 2012-05-21 21:26:48Z   User: nicka 
*  Changes for smart phone checkin by coordinates 
*  http://redmine.refreshcache.com/issues/463 
*
**********************************************************************/
using System;

namespace Arena.Custom.Cccev.DataUtils
{
	public static class Distance
	{
		/// <summary> 
		/// Convert degrees to Radians 
		/// </summary> 
		/// <param name="x">Degrees</param> 
		/// <returns>The equivalent in radians</returns> 
		private static double Radians( double x )
		{
			return x * Math.PI / 180;
		}

		/// <summary>
		/// Returns the approximate distance in miles between the two points.
		/// </summary>
		/// <param name="lat1">Latitude of start point</param>
		/// <param name="long1">Longitude of start point</param>
		/// <param name="lat2">Latitude of end point</param>
		/// <param name="long2">Longitude of end point</param>
		/// <returns>number of miles between to points</returns>
		public static double DistanceBetweenPlaces( double lat1, double long1, double lat2, double long2 )
		{
			double EarthMeanRadius = 3960; // miles

			double dlon = Radians( long2 - long1 );
			double dlat = Radians( lat2 - lat1 );

			double a = ( Math.Sin( dlat / 2 ) * Math.Sin( dlat / 2 ) ) + Math.Cos( Radians( lat1 ) ) * Math.Cos( Radians( lat2 ) ) * ( Math.Sin( dlon / 2 ) * Math.Sin( dlon / 2 ) );
			double angle = 2 * Math.Atan2( Math.Sqrt( a ), Math.Sqrt( 1 - a ) );
			return angle * EarthMeanRadius;
		}
	}
}
