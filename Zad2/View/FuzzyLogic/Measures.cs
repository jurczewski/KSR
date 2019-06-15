using System;
using System.Collections.Generic;
using System.Linq;
using Zad2;

namespace View.FuzzyLogic
{
    public class Measures
    {
        //todo: update functions definistions
        public static double WeightedMeasure(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<Player> entries, out List<double> values)
        {
            List<double> measureValues = new List<double>()
            {
                DegreeOfTruth(quantificator, qualifier, summarizer, entries),
                DegreeOfImprecision(quantificator, qualifier, summarizer, entries),
                DegreeOfCovering(quantificator, qualifier, summarizer, entries),
                DegreeOfAppropriateness(quantificator, qualifier, summarizer, entries),
                LengthOfSummary(quantificator, qualifier, summarizer, entries),
                DegreeOfQuantifierImprecision(quantificator, qualifier, summarizer, entries),
                DegreeOfQuantifierCardinality(quantificator, qualifier, summarizer, entries),
                DegreeOfSummarizerCardinality(quantificator, qualifier, summarizer, entries),
                DegreeOfQualifierImprecision(quantificator, qualifier, summarizer, entries),
                DegreeOfQualifierCardinality(quantificator, qualifier, summarizer, entries),
                LengthOfQualifier(quantificator, qualifier, summarizer, entries)
            };

            //todo: update weights
            List<double> weightedValues = new List<double>
            {
                (7.0 / 10) *   measureValues[0],
                (3.0 / 100) *  measureValues[1],
                (3.0 / 100) *  measureValues[2],
                (3.0 / 100) *  measureValues[3],
                (3.0 / 100) *  measureValues[4],
                (3.0 / 100) *  measureValues[5],
                (3.0 / 100) *  measureValues[6],
                (3.0 / 100) *  measureValues[7],
                (3.0 / 100) *  measureValues[8],
                (3.0 / 100) *  measureValues[9],
                (3.0 / 100) *  measureValues[10]
            };
            values = measureValues;
            return weightedValues.Sum();
        }

        //T1
        public static double DegreeOfTruth(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<Player> entries)
        {
            double up = 0;
            double down = 0;
            foreach (Player e in entries)
            {
                up += Math.Min(qualifier.GetMemebership(e), summarizer.GetMemebership(e));
                down += qualifier.Extractor(e);
            }
            if (quantificator.Absolute)
                return quantificator.MembershipFunction.GetMembership(up);
            return quantificator.MembershipFunction.GetMembership(up / down);
        }

        //T2
        public static double DegreeOfImprecision(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<Player> entries)
        {
            double ret = 1;
            var fuzzySets = summarizer.FuzzySet.GetAllFuzzySets();
            foreach (var set in fuzzySets)
            {
                ret *= set.DegreeOfFuzziness(entries);
            }
            ret = Math.Pow(ret, 1 / fuzzySets.Count);
            return 1 - ret;
        }

        //T3
        public static double DegreeOfCovering(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<Player> entries)
        {
            double up = 0;
            double down = 0;

            foreach (var Player in entries)
            {
                var qualVal = qualifier.GetMemebership(Player);
                var sumVal = summarizer.GetMemebership(Player);
                if (qualVal > 0)
                {
                    down++;
                    if (sumVal > 0)
                    {
                        up++;
                    }
                }
            }

            return up / down;
        }

        //T4
        public static double DegreeOfAppropriateness(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<Player> entries)
        {
            double ret = 0;
            var sets = summarizer.FuzzySet.GetAllFuzzySets();
            double t3 = DegreeOfCovering(quantificator, qualifier, summarizer, entries);
            foreach (var set in sets)
            {
                ret += (set.Support(entries).Count() / entries.Count()) - t3;
            }
            return Math.Abs(ret);
        }

        //T5
        public static double LengthOfSummary(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<Player> entries)
        {
            var nOfSummarizers = summarizer.FuzzySet.GetAllFuzzySets().Count;
            return 2 * Math.Pow(1.0 / 2.0, nOfSummarizers);
        }

        //T6
        public static double DegreeOfQuantifierImprecision(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<Player> entries)
        {
            var ret = quantificator.MembershipFunction.Cardinality();

            if (quantificator.Absolute)
            {
                ret /= (double)entries.Count;
            }
            return 1 - ret;
        }

        //T7
        public static double DegreeOfQuantifierCardinality(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<Player> entries)
        {
            double ret = quantificator.MembershipFunction.Cardinality();
            if (quantificator.Absolute)
            {
                ret /= (double)entries.Count;
            }
            return 1 - ret;
        }

        //T8
        public static double DegreeOfSummarizerCardinality(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<Player> entries)
        {
            double ret = 1;
            var fuzzySets = summarizer.FuzzySet.GetAllFuzzySets();
            foreach (var set in fuzzySets)
            {
                ret *= set.Cardinality() / entries.Count;
            }
            ret = Math.Pow(ret, 1.0 / fuzzySets.Count);
            return 1 - ret;
        }

        //T9
        public static double DegreeOfQualifierImprecision(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<Player> entries)
        {
            return 1 - qualifier.FuzzySet.DegreeOfFuzziness(entries);
        }

        //T10
        public static double DegreeOfQualifierCardinality(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<Player> entries)
        {
            return 1 - (qualifier.FuzzySet.Cardinality() / entries.Count);
        }

        //T11
        public static double LengthOfQualifier(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<Player> entries)
        {
            var nOfSummarizers = qualifier.FuzzySet.GetAllFuzzySets().Count;
            return 2 * Math.Pow(1.0 / 2.0, nOfSummarizers);
        }
    }
}
