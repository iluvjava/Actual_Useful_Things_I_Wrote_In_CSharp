using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Actual_Useful_Things_I_Wrote_For_CSharp.NumericalTools
{
    public class BigFraction
    {
        protected BigInteger _Numerator;
        protected BigInteger _Denominator;

        /// <summary>
        ///     Construct the fraction using the numerator and denominator. 
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        public BigFraction(BigInteger numerator, BigInteger denominator)
        {
            if (denominator.Equals(BigInteger.Zero)) 
            {
                throw new ArgumentException("denominator cannot be zero. "); 
            }

        }
           
        /// <summary>
        ///     Convert the double to an instance of BigFraction
        /// </summary>
        /// <param name="value">
        ///     
        /// </param>
        public BigFraction(double value)
        { 
        
        }



    }
}
