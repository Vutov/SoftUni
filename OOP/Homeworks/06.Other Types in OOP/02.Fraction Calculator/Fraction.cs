using System;
using System.Numerics;

namespace _02.Fraction_Calculator
{
    public struct Fraction
    {
        private long denomerator;

        public Fraction(long numerator, long denomerator)
            : this()
        {
            this.Numerator = numerator;
            this.Denomerator = denomerator;
        }

        public long Numerator { get; set; }

        public long Denomerator
        {
            get
            {
                return this.denomerator;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Denomerator cannot be 0");
                }

                this.denomerator = value;
            }
        }


        public static Fraction operator +(Fraction fractionA, Fraction fractionB)
        {
            BigInteger resultNumerator = ((BigInteger)fractionA.Numerator * fractionB.Denomerator) +
                                         ((BigInteger)fractionA.Denomerator * fractionB.Numerator);

            BigInteger resultDenominator = (BigInteger)fractionA.Denomerator * fractionB.Denomerator;

            BigInteger gcd = GetGreatestCommonDivisor(resultNumerator, resultDenominator);

            if (gcd > 1)
            {
                resultNumerator /= gcd;
                resultDenominator /= gcd;
            }

            if (resultNumerator < long.MinValue || long.MaxValue < resultNumerator)
            {
                throw new ArithmeticException("Numerator of resulting fraction is either too large or too small.");
            }

            if (resultDenominator > long.MaxValue)
            {
                throw new ArithmeticException("Denominator of resulting fraction is too large.");
            }

            return new Fraction((long)resultNumerator, (long)resultDenominator);
        }

        public static Fraction operator -(Fraction fractionA, Fraction fractionB)
        {
            Fraction result = fractionA + new Fraction(fractionB.Numerator * -1, fractionB.Denomerator);
            return result;
        }


        public override string ToString()
        {
            double value = (double)this.Numerator / this.Denomerator;
            return value.ToString();
        }

        private static long GetGreatestCommonDivisor(BigInteger numerator, BigInteger denominator)
        {
            if (numerator < 0)
            {
                numerator *= -1;
            }

            if (denominator < 0)
            {
                denominator *= -1;
            }

            while (denominator != 0)
            {
                BigInteger tempDenominator = denominator;
                denominator = numerator % denominator;
                numerator = tempDenominator;
            }

            return (long)numerator;
        }
    }
}