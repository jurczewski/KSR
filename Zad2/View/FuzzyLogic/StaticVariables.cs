using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zad2.FuzzyLogic;
using Zad2.Membership;

namespace View.FuzzyLogic
{
    public class StaticVariables
    {
        //todo: add rest of the variables, Age and Weith are good now
        #region Age
        public static LinguisticVariable ageYoung = new LinguisticVariable
        {
            Name = "Young",
            MemberToExtract = "Age",
            Extractor = e => new TrapezoidFunction(new List<double> { 15, 16, 17, 20 }).GetMembership(e.Age),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 13, 13, 17, 20 }),
                FieldExtractor = (e) => e.Age
            }
        };
        public static LinguisticVariable ageYoungAdult = new LinguisticVariable
        {
            Name = "Adult",
            MemberToExtract = "Age",
            Extractor = e => new TrapezoidFunction(new List<double> { 19, 23, 27, 31 }).GetMembership(e.Age),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 19, 23, 27, 31 }),
                FieldExtractor = (e) => e.Age
            }
        };
        public static LinguisticVariable ageAdult = new LinguisticVariable
        {
            Name = "Old",
            MemberToExtract = "Age",
            Extractor = e => new TrapezoidFunction(new List<double> { 30, 35, 45, 51 }).GetMembership(e.Age),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 30, 35, 45, 51 }),
                FieldExtractor = (e) => e.Age
            }
        };
        #endregion
        #region Weight
        public static LinguisticVariable weightLight = new LinguisticVariable
        {
            Name = "Light",
            MemberToExtract = "BodyweightKg",
            Extractor = e => new TrapezoidFunction(new List<double> { 110, 110, 150, 155 }).GetMembership(e.Weight),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 110, 110, 150, 155 }),
                FieldExtractor = (e) => e.Weight
            }
        };
        public static LinguisticVariable weightRegular = new LinguisticVariable
        {
            Name = "Regular",
            MemberToExtract = "BodyweightKg",
            Extractor = e => new TrapezoidFunction(new List<double> { 150, 160, 190, 200 }).GetMembership(e.Weight),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 151, 160, 190, 200 }),
                FieldExtractor = (e) => e.Weight
            }
        };
        public static LinguisticVariable weightHeavy = new LinguisticVariable
        {
            Name = "Heavy",
            MemberToExtract = "BodyweightKg",
            Extractor = e => new TrapezoidFunction(new List<double> { 195, 210, 240, 255 }).GetMembership(e.Weight),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 195, 210, 240, 255 }),
                FieldExtractor = (e) => e.Weight
            }
        };
        #endregion
        //public static LinguisticVariable none = new LinguisticVariable
        //{
        //    Name = "-",
        //    MemberToExtract = "-",
        //    Extractor = (e) => new ConstantFunction().GetMembership(0.0),
        //    FuzzySet = new FuzzySet
        //    {
        //        MembershipFunction = new ConstantFunction(),
        //        FieldExtractor = (e) => 0.0
        //    }
        //};

        public static ObservableCollection<LinguisticVariable> getAllVariables()
        {
            //todo: write rest of lingustic variables
            return new ObservableCollection<LinguisticVariable>
            {
                ageYoung, ageYoungAdult, ageAdult,
                weightLight, weightRegular, weightHeavy
            };
        }
    }
}
