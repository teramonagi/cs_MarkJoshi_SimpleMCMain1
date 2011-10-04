using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MyRandom
{
    private static Random rand;
    static MyRandom(){
        rand = new Random();
    }
    public static double GetOneGaussianBySummation()
    {
        double result = -6.0;

        for(int i = 0; i < 12; i++){
            result += rand.NextDouble();
        }

        return result;
    }
    public static double GetOneGaussianByBoxMuller()
    {
        double x, y, size_squared;
        do
        {
            x = 2.0 * rand.NextDouble() - 1;
            y = 2.0 * rand.NextDouble() - 1;
            size_squared = x * x + y * y;
        } while (size_squared >= 1.0);

        return (x * Math.Sqrt(-2.0 * Math.Log(size_squared) / size_squared));
    }
}