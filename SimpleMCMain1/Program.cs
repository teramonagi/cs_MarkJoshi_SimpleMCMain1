using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMCMain1
{
    class Program
    {
        static double SimpleMonteCarlo1(double expiry,
                                        double strike,
                                        double spot,
                                        double vol,
                                        double r,
                                        ulong number_of_paths)
        {
            double variance = vol * vol * expiry;
            double root_variance = Math.Sqrt(variance);
            double moved_spot = spot * Math.Exp(r * expiry - 0.5 * variance);

            double this_spot;
            double running_sum = 0;
            for (ulong i = 0; i < number_of_paths; i++)
            {
                double this_gaussian = MyRandom.GetOneGaussianByBoxMuller();
                this_spot = moved_spot * Math.Exp(root_variance * this_gaussian);
                double this_payoff = Math.Max(this_spot - strike, 0);
                running_sum += this_payoff;
            }
            return Math.Exp(- r * expiry) * (running_sum / number_of_paths);
        }
        static void Main(string[] args)
        {
            //parameters
            double expiry = 1.0;
            double strike = 50.0;
            double spot = 49.0;
            double vol = 0.2;
            double r = 0.01;
            
            //input number of montecarlo paths
            ulong number_of_paths = 10000;
            Console.Write("Enter number of montecarlo paths : ");
            number_of_paths = ulong.Parse(Console.ReadLine());

            //montecarlo simulation
            double result = SimpleMonteCarlo1(expiry, strike, spot, vol, r, number_of_paths);

            //output result
            Console.WriteLine("the price is " + result.ToString());
        }
    }
}
