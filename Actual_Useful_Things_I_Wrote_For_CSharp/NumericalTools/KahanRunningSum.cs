using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Actual_Useful_Things_I_Wrote_For_CSharp.NumericalTools
{

    /// <summary>
    ///     Use This class anytime when you are summing up floats in a for-loop and shit. 
    ///     
    ///     <para>
    ///         This class is mutable. 
    ///     </para>
    /// </summary>
    public class KahanRunningSum : IComparable<double>
    {
        protected double _RunningSum;
        protected double _Compensator = 0;

        public KahanRunningSum(double initial = 0)
        {
            _RunningSum = initial;
        }

        

        public double Value
        {
            get {
                return Math.Round(this._RunningSum + this._Compensator, 15);
            }

        }
        
        public int CompareTo([AllowNull] double other)
        {
            return Math.Sign(this.Value - other);
        }
        
        public static KahanRunningSum operator +(KahanRunningSum theSum, double beingAdded) {
            double Temp = theSum._RunningSum + beingAdded;
            if (Math.Abs(theSum._RunningSum) >= Math.Abs(beingAdded))
            {
                theSum._Compensator += (theSum._RunningSum - Temp) + beingAdded;
            }
            else
            {
                theSum._Compensator += (beingAdded - Temp) + theSum._RunningSum;
            }
            theSum._RunningSum = Temp;
            return theSum;
        }

        public static KahanRunningSum operator -(KahanRunningSum theSum, double beingSubtradted)
        {
            return theSum + (-beingSubtradted);
        }


        public static bool operator <(KahanRunningSum theSum, KahanRunningSum other)
        {
            return theSum.Value < other.Value;   
        }

        public static bool operator >(KahanRunningSum theSum, KahanRunningSum other)
        {
            return theSum.Value > other.Value;
        }

        public static bool operator <(KahanRunningSum theSum, double other)
        {
            return theSum.CompareTo(other) == -1; 
        }

        public static bool operator > (KahanRunningSum theSum, double other)
        {
            return theSum.CompareTo(other) == 1;
        }







    }

    /// <summary>
    /// 
    ///     For summing up the complex numbers that is supported by CSharp. 
    /// </summary>
    public class KahanRunningSumComplex
    { 
        
    }


}
