using System.Collections.Generic;

namespace Zad2.Membership
{
    public interface IMembershipFunction
    {
        double GetMembership(double x); //oblicza przynależność dla danego punktu
        List<IMembershipFunction> GetAllFunctions(); //wybranie wszystkich funkcji, potrzebme przy miarze wykorzystującej złożone sumaryzatory
        List<double> Parameters { get; set; } //a,b,c,d
        double Cardinality();
    }
}
