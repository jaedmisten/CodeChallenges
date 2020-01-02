/*
 * 1/1/2020
 * 
 * https://projectlovelace.net/problems/flight-paths/
 * 
 * Write a program that takes two input points of latitude and longitude and calcualates the 
 * distance between the points in kilometers using the haversine formula.
 * 
 * Haversine formula:
 *      a = sin²(Δφ/2) + cos φ1 ⋅ cos φ2 ⋅ sin²(Δλ/2)
 *      c = 2 * atan2( √a, √(1−a) )
 *      d = R * c
 *      where φ is latitude, λ is longitude, R is earth’s radius (mean radius = 6,372.1km);
 *      note that angles need to be in radians to pass to trig functions.  
 */
using System;

namespace FlightPaths
{
    class Program
    {
        static void Main(string[] args)
        {
            bool retryLatInput = true, retryLongInput = true;
            float lat1Degree = 0, long1Degree = 0, lat2Degree = 0, long2Degree = 0;

            Console.WriteLine("Latitudes go from -90 to 90. Longitudes go from -180 to 180.");

            // Get point 1.
            do
            {
                Console.Write("Input point 1 (latitude, longitude) : ");
                string input1 = Console.ReadLine();
                String[] point1 = input1.Split(',');
                
                if (point1.Length == 2)
                { 
                    if (float.TryParse(point1[0], out lat1Degree))
                    {
                        if (lat1Degree >= -90 && lat1Degree <= 90)
                        {
                            retryLatInput = false;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Latitude Input. Latitude must be between -90 to 90");
                            retryLatInput = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Latitude input. Input must be numbers separated by a comma.");
                        retryLatInput = true;
                    }


                    if (float.TryParse(point1[1], out long1Degree))
                    {
                        if (long1Degree >= -180 && long1Degree <= 180)
                        {
                            retryLongInput = false;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Longitude Input. Longitude must be between -180 to 180");
                            retryLongInput = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Longitude input. Input must be numbers separated by a comma.");
                        retryLongInput = true;
                    }
                 } 
                else
                {
                    Console.WriteLine("Incorrect input. Input must be two numbers separated by a comma.");
                    retryLatInput = true;
                    retryLongInput = true;
                } 

                if (retryLatInput || retryLongInput)
                {
                    Console.WriteLine("");
                }
            } while (retryLatInput || retryLongInput);

            // Get point 2.
            do
            {
                Console.Write("Input point 2 (latitude, longitude) : ");
                string input2 = Console.ReadLine();
                String[] point2 = input2.Split(',');

                if (point2.Length == 2)
                {
                    if (float.TryParse(point2[0], out lat2Degree))
                    {
                        if (lat2Degree >= -90 && lat2Degree <= 90)
                        {
                            retryLatInput = false;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Latitude Input. Latitude must be between -90 to 90");
                            retryLatInput = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Latitude input. Input must be numbers separated by a comma.");
                        retryLatInput = true;
                    }


                    if (float.TryParse(point2[1], out long2Degree))
                    {
                        if (long2Degree >= -180 && long2Degree <= 180)
                        {
                            retryLongInput = false;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Longitude Input. Longitude must be between -180 to 180");
                            retryLongInput = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Longitude input. Input must be numbers separated by a comma.");
                        retryLongInput = true;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input. Input must be two numbers separated by a comma.");
                    retryLatInput = true;
                    retryLongInput = true;
                }

                if (retryLatInput || retryLongInput)
                {
                    Console.WriteLine("");
                }
            } while (retryLatInput || retryLongInput);


            // Convert points from degrees to radians.
            double lat1 = lat1Degree * (Math.PI / 180);
            double lon1 = long1Degree * (Math.PI / 180);
            double lat2 = lat2Degree * (Math.PI / 180);
            double lon2 = long2Degree * (Math.PI / 180);

            double distance = HaversineDistance(lat1, lon1, lat2, lon2);
            Console.WriteLine("\nOutput distance: " + Math.Round(distance, 3) + " kilometers");
        }

        public static double HaversineDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double distance = 2 * 6372.1 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin((lat2 - lat1) / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin((lon2 - lon1) / 2), 2)));
            return distance;
        }
    }
}
