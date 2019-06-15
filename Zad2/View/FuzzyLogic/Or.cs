using System;
using System.Collections.Generic;
using System.Linq;
using Zad2;
using Zad2.FuzzyLogic;

namespace View.FuzzyLogic
{
    public class Or : FuzzySet
    {
        public FuzzySet fuzzySet1;
        public FuzzySet fuzzySet2;

        public override double GetMembership(Player Player)
        {
            return Math.Max(fuzzySet1.GetMembership(Player), fuzzySet2.GetMembership(Player));
        }

        public override List<Player> Support(List<Player> entries)
        {
            return fuzzySet1.Support(entries).Concat(fuzzySet2.Support(entries)).Distinct().ToList();
        }

        public override double DegreeOfFuzziness(List<Player> entries)
        {
            return fuzzySet1.DegreeOfFuzziness(entries) * fuzzySet2.DegreeOfFuzziness(entries);
        }

        public override List<FuzzySet> GetAllFuzzySets()
        {
            return fuzzySet1.GetAllFuzzySets().Concat(fuzzySet2.GetAllFuzzySets()).ToList();
        }

        public override void SetAllFuzzySets(List<FuzzySet> sets)
        {
            fuzzySet1 = sets[0];
            fuzzySet2 = sets[1];
        }

    }
}
