﻿using System;
using System.Collections.Generic;

namespace InterpolDatabaseProject.Model
{
    [Serializable]
    public class Crime
    {
        public CrimeType Type { get; set; }
        public DateTime Date { get; set; }
        public Country CommitmentCountry { get; set; }
        public string CommitmentPlace { get; set; }
        public string AdditionalData { get; set; }

        public Crime()
        {
            Type = new CrimeType(0);
            CommitmentCountry = new Country(0);
            CommitmentPlace = "Unknown";
            AdditionalData = "No data";
        }
        public Crime(CrimeType type, DateTime date, Country commitmentCountry, string commitmentPlace, string additionalData)
        {
            Type = type;
            Date = date;
            CommitmentCountry = commitmentCountry;
            CommitmentPlace = commitmentPlace;
            AdditionalData = additionalData;
        }

        public struct CrimeType
        {
            private int _id;

            static CrimeType()
            {
                CrimeTypes = new Dictionary<int, string> { { 0, "Unknown" } };
            }

            public CrimeType(int id):this()
            {
                Id = id;
            }

            public static Dictionary<int, string> CrimeTypes { get; set; }
            public int Id
            {
                get
                {
                    return _id;
                }
                set
                {
                    if (CrimeTypes.ContainsKey(value))
                        _id = value;
                    else throw new ArgumentOutOfRangeException();
                }
            }
            public override string ToString()
            {
                return CrimeTypes[Id];
            }
        }
        
    }
}