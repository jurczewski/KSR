using System.Collections.Generic;
using System.Collections.ObjectModel;
using View.Membership;
using Zad2.FuzzyLogic;
using Zad2.Membership;

namespace View.FuzzyLogic
{
    public class StaticVariables
    {
        #region Age
        public static LinguisticVariable ageYoung = new LinguisticVariable
        {
            Name = "Young",
            MemberToExtract = "Age",
            Extractor = e => new TrapezoidFunction(new List<double> { 15, 16, 17, 20 }).GetMembership(e.Age),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 15, 16, 17, 20 }),
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

        #region Overall
        public static LinguisticVariable overallLow = new LinguisticVariable
        {
            Name = "Low Overall",
            MemberToExtract = "Overall",
            Extractor = e => new TrapezoidFunction(new List<double> { 46, 50, 55, 60 }).GetMembership(e.Overall),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 46, 50, 55, 60 }),
                FieldExtractor = (e) => e.Overall
            }
        };

        public static LinguisticVariable overallMedium = new LinguisticVariable
        {
            Name = "Medium Overall",
            MemberToExtract = "Overall",
            Extractor = e => new TrapezoidFunction(new List<double> { 59, 64, 70, 75 }).GetMembership(e.Overall),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 59, 64, 73, 80 }),
                FieldExtractor = (e) => e.Overall
            }
        };

        public static LinguisticVariable overallGood = new LinguisticVariable
        {
            Name = "Good Overall",
            MemberToExtract = "Overall",
            Extractor = e => new TrapezoidFunction(new List<double> { 74, 80, 85, 94 }).GetMembership(e.Overall),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 74, 80, 85, 94 }),
                FieldExtractor = (e) => e.Overall
            }
        };
        #endregion

        #region Value
        public static LinguisticVariable valueLow = new LinguisticVariable
        {
            Name = "Low Value",
            MemberToExtract = "Value",
            Extractor = e => new TrapezoidFunction(new List<double> { 0, 30, 60, 100 }).GetMembership(e.Value),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 0, 30, 60, 100 }),
                FieldExtractor = (e) => e.Value
            }
        };

        public static LinguisticVariable valueMedium = new LinguisticVariable
        {
            Name = "Medium Value",
            MemberToExtract = "Value",
            Extractor = e => new TrapezoidFunction(new List<double> { 99, 200, 400, 600 }).GetMembership(e.Value),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 99, 200, 400, 600 }),
                FieldExtractor = (e) => e.Value
            }
        };

        public static LinguisticVariable valueHigh = new LinguisticVariable
        {
            Name = "High Value",
            MemberToExtract = "Value",
            Extractor = e => new TrapezoidFunction(new List<double> { 599, 750, 850, 975 }).GetMembership(e.Value),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 599, 750, 850, 975 }),
                FieldExtractor = (e) => e.Value
            }
        };
        #endregion

        #region Wage
        public static LinguisticVariable wageLow = new LinguisticVariable
        {
            Name = "Low Wage",
            MemberToExtract = "Wage",
            Extractor = e => new TrapezoidFunction(new List<double> { 0, 2, 4, 6 }).GetMembership(e.Wage),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 0, 2, 4, 6 }),
                FieldExtractor = (e) => e.Wage
            }
        };

        public static LinguisticVariable wageMedium = new LinguisticVariable
        {
            Name = "Medium Wage",
            MemberToExtract = "Wage",
            Extractor = e => new TrapezoidFunction(new List<double> { 5, 7, 9, 12 }).GetMembership(e.Wage),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 5, 7, 9, 12 }),
                FieldExtractor = (e) => e.Wage
            }
        };

        public static LinguisticVariable wageHigh = new LinguisticVariable
        {
            Name = "High Wage",
            MemberToExtract = "Wage",
            Extractor = e => new TrapezoidFunction(new List<double> { 11, 50, 90, 110 }).GetMembership(e.Wage),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 11, 50, 90, 110 }),
                FieldExtractor = (e) => e.Wage
            }
        };

        public static LinguisticVariable wageVeryHigh = new LinguisticVariable
        {
            Name = "Very High Wage",
            MemberToExtract = "Wage",
            Extractor = e => new TrapezoidFunction(new List<double> { 109, 250, 400, 565 }).GetMembership(e.Wage),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 109, 250, 400, 565 }),
                FieldExtractor = (e) => e.Wage
            }
        };
        #endregion

        #region Height
        public static LinguisticVariable heightLow = new LinguisticVariable
        {
            Name = "Short",
            MemberToExtract = "Height",
            Extractor = e => new TrapezoidFunction(new List<double> { 153, 160, 167, 172 }).GetMembership(e.Height),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 153, 160, 167, 172 }),
                FieldExtractor = (e) => e.Height
            }
        };

        public static LinguisticVariable heightMedium = new LinguisticVariable
        {
            Name = "Medium Height",
            MemberToExtract = "Height",
            Extractor = e => new TrapezoidFunction(new List<double> { 171, 176, 181, 185 }).GetMembership(e.Height),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 171, 176, 181, 185 }),
                FieldExtractor = (e) => e.Height
            }
        };

        public static LinguisticVariable heightHigh = new LinguisticVariable
        {
            Name = "Tall",
            MemberToExtract = "Height",
            Extractor = e => new TrapezoidFunction(new List<double> { 184, 190, 195, 207 }).GetMembership(e.Height),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 184, 190, 200, 207 }),
                FieldExtractor = (e) => e.Height
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

        #region FKAccuracy
        public static LinguisticVariable fkaccuracyLow = new LinguisticVariable
        {
            Name = "Bad Free Kick",
            MemberToExtract = "Fk Accuracy",
            Extractor = e => new TrapezoidFunction(new List<double> { 3, 15, 30, 40 }).GetMembership(e.Fk_accuracy),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 3, 15, 30, 40 }),
                FieldExtractor = (e) => e.Fk_accuracy
            }
        };
        public static LinguisticVariable fkaccuracyMedium = new LinguisticVariable
        {
            Name = "Decent Free Kick",
            MemberToExtract = "Fk Accuracy",
            Extractor = e => new TrapezoidFunction(new List<double> { 39, 46, 58, 70 }).GetMembership(e.Fk_accuracy),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 39, 46, 58, 70 }),
                FieldExtractor = (e) => e.Fk_accuracy
            }
        };
        public static LinguisticVariable fkaccuracyHigh = new LinguisticVariable
        {
            Name = "Good Free Kick",
            MemberToExtract = "Fk Accuracy",
            Extractor = e => new TrapezoidFunction(new List<double> { 69, 75, 87, 94 }).GetMembership(e.Fk_accuracy),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 69, 75, 87, 94 }),
                FieldExtractor = (e) => e.Fk_accuracy
            }
        };
        #endregion

        #region SprintSpeed
        public static LinguisticVariable sprintLow = new LinguisticVariable
        {
            Name = "Bad Sprint",
            MemberToExtract = "Sprint Speed",
            Extractor = e => new TrapezoidFunction(new List<double> { 12, 20, 30, 40 }).GetMembership(e.Sprint_speed),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 12, 20, 30, 40 }),
                FieldExtractor = (e) => e.Sprint_speed
            }
        };
        public static LinguisticVariable sprintMedium = new LinguisticVariable
        {
            Name = "Decent Sprint",
            MemberToExtract = "Sprint Speed",
            Extractor = e => new TrapezoidFunction(new List<double> { 39, 47, 58, 68 }).GetMembership(e.Sprint_speed),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 39, 47, 58, 68 }),
                FieldExtractor = (e) => e.Sprint_speed
            }
        };
        public static LinguisticVariable sprintHigh = new LinguisticVariable
        {
            Name = "Good Sprint",
            MemberToExtract = "Sprint Speed",
            Extractor = e => new TrapezoidFunction(new List<double> { 67, 75, 85, 96 }).GetMembership(e.Sprint_speed),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 67, 75, 85, 96 }),
                FieldExtractor = (e) => e.Sprint_speed
            }
        };
        #endregion

        #region Stamina
        public static LinguisticVariable staminaLow = new LinguisticVariable
        {
            Name = "Bad Stamina",
            MemberToExtract = "Stamina",
            Extractor = e => new TrapezoidFunction(new List<double> { 12, 19, 31, 40 }).GetMembership(e.Stamina),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 12, 19, 31, 40 }),
                FieldExtractor = (e) => e.Stamina
            }
        };
        public static LinguisticVariable staminaMedium = new LinguisticVariable
        {
            Name = "Decent Stamina",
            MemberToExtract = "Stamina",
            Extractor = e => new TrapezoidFunction(new List<double> { 39, 45, 57, 68 }).GetMembership(e.Stamina),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 39, 45, 57, 68 }),
                FieldExtractor = (e) => e.Stamina
            }
        };
        public static LinguisticVariable staminaHigh = new LinguisticVariable
        {
            Name = "Good Stamina",
            MemberToExtract = "Stamina",
            Extractor = e => new TrapezoidFunction(new List<double> { 67, 76, 87, 96 }).GetMembership(e.Stamina),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 67, 76, 87, 96 }),
                FieldExtractor = (e) => e.Stamina
            }
        };
        #endregion

        #region Strength
        public static LinguisticVariable strengthLow = new LinguisticVariable
        {
            Name = "Bad Strength",
            MemberToExtract = "Strength",
            Extractor = e => new TrapezoidFunction(new List<double> { 17, 25, 36, 45 }).GetMembership(e.Strength),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 17, 25, 42, 55 }),
                FieldExtractor = (e) => e.Strength
            }
        };
        public static LinguisticVariable strengthMedium = new LinguisticVariable
        {
            Name = "Decent Strength",
            MemberToExtract = "Strength",
            Extractor = e => new TrapezoidFunction(new List<double> { 54, 65, 74, 80 }).GetMembership(e.Strength),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 54, 65, 74, 80 }),
                FieldExtractor = (e) => e.Strength
            }
        };
        public static LinguisticVariable strengthHigh = new LinguisticVariable
        {
            Name = "Good Strength",
            MemberToExtract = "Strength",
            Extractor = e => new TrapezoidFunction(new List<double> { 79, 85, 90, 97 }).GetMembership(e.Strength),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new TrapezoidFunction(new List<double> { 79, 85, 90, 97 }),
                FieldExtractor = (e) => e.Strength
            }
        };
        #endregion

        public static LinguisticVariable every = new LinguisticVariable
        {
            Name = "Every",
            MemberToExtract = "Every",
            Extractor = (e) => new ConstantFunction().GetMembership(0.0),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new ConstantFunction(),
                FieldExtractor = (e) => 0.0
            }
        };

        public static ObservableCollection<LinguisticVariable> getAllVariables()
        {
            return new ObservableCollection<LinguisticVariable>
            {
                ageYoung, ageYoungAdult, ageAdult,
                overallLow, overallMedium, overallGood,
                valueLow, valueMedium, valueHigh,
                wageLow, wageMedium, wageHigh, wageVeryHigh,
                heightLow, heightMedium, heightHigh,
                weightLight, weightRegular, weightHeavy,
                fkaccuracyLow, fkaccuracyMedium, fkaccuracyHigh, 
                sprintLow, sprintMedium, sprintHigh,
                staminaLow, staminaMedium, staminaHigh,
                strengthLow, strengthMedium, strengthHigh,
                every
            };
        }
    }
}
