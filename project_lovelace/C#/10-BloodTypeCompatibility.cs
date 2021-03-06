﻿/*
 * 7/7/2020
 * 
 * https://projectlovelace.net/problems/blood-types/
 * 
 * Write a program that takes input of a patient's blood type and input of the list
 * of available blood types and determine if a compatible blood type is available.
 * 
 */
using System;
using System.Linq;

namespace BloodTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input blood type: ");
            var bloodType = Console.ReadLine();

            Console.Write("Input list of available blood types: ");
            var donatedBloodInput = Console.ReadLine();
            donatedBloodInput = donatedBloodInput.Trim('[', ']');
            var donatedBlood = donatedBloodInput.Split(new string[] {", "}, StringSplitOptions.None).Select(bt => bt.Trim('\"', '\"')).ToArray();

            Console.WriteLine("Output survivability: " + survive(bloodType, donatedBlood));
        }

        public static bool survive(string bloodType, string[] donatedBlood)
        {
            var compatibleBloodTypes = getCompatibleBloodTypes(bloodType);

            for (int i = 0; i < donatedBlood.Length; i++)
            {
                for (int j = 0; j < compatibleBloodTypes.Length; j++)
                {
                    if (donatedBlood[i] == compatibleBloodTypes[j])
                    {
                        // Matching blood type found. Person can be saved.
                        return true;
                    }
                }
            }

            // Matching blood type not found. Person can not be saved.
            return false;
        }

        public static string[] getCompatibleBloodTypes(string bloodType)
        {
            string[] oNegCompatible = { "O-" };
            string[] oPosCompatible = { "O+", "O-" };
            string[] aNegCompatible = { "O-", "A-" };
            string[] aPosCompatible = { "O+", "O-", "AB+", "A+" };
            string[] bNegCompatible = { "O-", "B-" };
            string[] bPosCompatible = { "O+", "O-", "B+", "B-" };
            string[] abNegCompatible = { "O-", "A-", "B-", "AB-" };
            string[] abPosCompatible = { "O+", "O-", "A+", "A-", "B+", "B-", "AB+", "AB-" };
            var compatibleBloodTypes = new string[0];

            switch (bloodType)
            {
                case "\"O-\"":
                    return oNegCompatible;
                case "\"O+\"":
                    return oPosCompatible;
                case "\"A-\"":
                    return aNegCompatible;
                case "\"A+\"":
                    return aPosCompatible;
                case "\"B-\"":
                    return bNegCompatible;
                case "\"B+\"":
                    return bPosCompatible;
                case "\"AB-\"":
                    return abNegCompatible;
                case "AB+":
                    return abPosCompatible;
                default:
                    throw new Exception("There was an input error.");
            }
        }
    }
}