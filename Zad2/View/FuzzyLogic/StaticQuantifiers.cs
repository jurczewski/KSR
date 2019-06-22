using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zad2.Membership;

namespace View.FuzzyLogic
{
    public class StaticQuantifiers
    {
        #region Relative Quantizers
        public static LinguisticVariable no = new LinguisticVariable
        {
            Name = "No",
            MembershipFunction = new TriangularFunction(new List<double> { 0, 0, 0.16 }),
            Absolute = false
        };
        public static LinguisticVariable around20Percent = new LinguisticVariable
        {
            Name = "Around 20%",
            MembershipFunction = new TriangularFunction(new List<double> { 0.14, 0.2, 0.26 }),
            Absolute = false
        };
        public static LinguisticVariable aroundOneThird = new LinguisticVariable
        {
            Name = "Around one third",
            MembershipFunction = new TriangularFunction(new List<double> { 0.25, 0.33, 0.41 }),
            Absolute = false
        };
        public static LinguisticVariable lessThanThird = new LinguisticVariable
        {
            Name = "Less than a third",
            MembershipFunction = new TrapezoidFunction(new List<double> { 0, 0, 0.3, 0.36 }),
            Absolute = false
        };
        public static LinguisticVariable around40Percent = new LinguisticVariable
        {
            Name = "Around 40%",
            MembershipFunction = new TriangularFunction(new List<double> { 0.34, 0.4, 0.46 }),
            Absolute = false
        };
        public static LinguisticVariable aroundHalf = new LinguisticVariable
        {
            Name = "Around half",
            MembershipFunction = new TriangularFunction(new List<double> { 0.4, 0.5, 0.6 }),
            Absolute = false
        };
        public static LinguisticVariable aroundThreeQuaters = new LinguisticVariable
        {
            Name = "Around three quaters",
            MembershipFunction = new TriangularFunction(new List<double> { 0.5, 0.6, 0.7 }),
            Absolute = false
        };
        public static LinguisticVariable majority = new LinguisticVariable
        {
            Name = "Majority",
            MembershipFunction = new TriangularFunction(new List<double> { 0.75, 0.8, 0.9 }),
            Absolute = false
        };
        public static LinguisticVariable almostAll = new LinguisticVariable
        {
            Name = "All",
            MembershipFunction = new TrapezoidFunction(new List<double> { 0.85, 0.9, 1, 1 }),
            Absolute = false
        };
        #endregion
        #region Absolute Quantizers
        public static LinguisticVariable lessThan1000 = new LinguisticVariable
        {
            Name = "Less than 1000",
            MembershipFunction = new TrapezoidFunction(new List<double> { 0, 0, 9990, 1000 }),
            Absolute = true
        };
        public static LinguisticVariable around1500 = new LinguisticVariable
        {
            Name = "Around 1500",
            MembershipFunction = new TriangularFunction(new List<double> { 1400, 1500, 1600 }),
            Absolute = true
        };
        public static LinguisticVariable around3000 = new LinguisticVariable
        {
            Name = "Around 3000",
            MembershipFunction = new TriangularFunction(new List<double> { 2900, 3000, 3100 }),
            Absolute = true
        };
        public static LinguisticVariable moreThan5000 = new LinguisticVariable
        {
            Name = "More than 5000",
            MembershipFunction = new TrapezoidFunction(new List<double> { 5000, 5010, 5500, 5500 }),
            Absolute = true
        };


        #endregion
        public static ObservableCollection<LinguisticVariable> getAllQuantifiers()
        {
            return new ObservableCollection<LinguisticVariable>
            {
                no,
                around20Percent,
                aroundOneThird,
                around40Percent,
                lessThanThird,
                aroundHalf,
                aroundThreeQuaters,
                majority,
                almostAll,
                lessThan1000,
                around1500,
                around3000,
                moreThan5000
            };
        }
    }
}
