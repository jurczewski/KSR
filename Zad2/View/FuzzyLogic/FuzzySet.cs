using System;
using System.Collections.Generic;
using Zad2.Membership;

namespace Zad2.FuzzyLogic
{
    public class FuzzySet
    {
        public IMembershipFunction MembershipFunction { get; set; }
        public Func<Player, double> FieldExtractor { get; set; }

        public virtual double GetMembership(Player entry)
        {
            return MembershipFunction.GetMembership(FieldExtractor(entry));
        }

        private List<Player> Support(List<Player> entries, IMembershipFunction function)
        {
            List<Player> result = new List<Player>();
            entries.ForEach((e) => {
                if (function.GetMembership(FieldExtractor(e)) > 0)
                {
                    result.Add(e);
                }
            });
            return result;
        }

        public virtual List<Player> Support(List<Player> entries)
        {
            return Support(entries, MembershipFunction);
        }

        private double DegreeOfFuzziness(List<Player> entries, IMembershipFunction function)
        {
            return (double)Support(entries, function).Count / (double)entries.Count;
        }

        public virtual double DegreeOfFuzziness(List<Player> entries)
        {
            return DegreeOfFuzziness(entries, MembershipFunction);
        }

        public virtual double Cardinality()
        {
            return MembershipFunction.Cardinality();
        }

        public virtual List<FuzzySet> GetAllFuzzySets()
        {
            return new List<FuzzySet> { this };
        }

        public virtual void SetAllFuzzySets(List<FuzzySet> sets) { }
    }
}
