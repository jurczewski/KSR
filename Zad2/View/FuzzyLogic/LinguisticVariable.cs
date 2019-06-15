using System;
using Zad2;
using Zad2.FuzzyLogic;
using Zad2.Membership;

namespace View.FuzzyLogic
{
    public class LinguisticVariable
    {
        public string Name { get; set; }
        public IMembershipFunction MembershipFunction { get; set; }
        public string MemberToExtract { get; set; }
        public Func<Player, double> Extractor { get; set; }
        public bool Absolute { get; set; }
        public FuzzySet FuzzySet { get; set; }

        public double GetMemebership(Player entry)
        {
            return FuzzySet.GetMembership(entry);
        }
        public string MemberAndName { get => MemberToExtract + ": " + Name; }
    }
}
