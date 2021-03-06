﻿using System;
using System.Collections.Generic;

namespace Zad2.Membership
{
    public class TrapezoidFunction : IMembershipFunction
    {
        private double a, b, c, d;
        public TrapezoidFunction(List<double> parameters)
        {
            Parameters = parameters;
        }
        public List<double> Parameters
        {
            get => new List<double> { a, b, c, d };
            set
            {
                if (value.Count != 4)
                    throw new ArgumentException("invalid amount of arguments");
                a = value[0];
                b = value[1];
                c = value[2];
                d = value[3];
            }
        }

        public List<IMembershipFunction> GetAllFunctions()
        {
            return new List<IMembershipFunction> { this };
        }

        public double Cardinality()
        {
            return ((d - a) + (c - b)) / 2;
        }

        public double GetMembership(double x)
        {
            if (x < a)
                return 0.0;
            else if (a <= x && x < b)
                return (x - a) / (b - a);
            else if (b <= x && x <= c)
                return 1.0;
            else if (c < x && x <= d)
                return (d - x) / (d - c);
            else
                return 0.0;
        }
    }
}
