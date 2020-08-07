using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Actual_Useful_Things_I_Wrote_For_CSharp.NumericalTools
{

    /// <summary>
    ///     It's just a class that wraps the summation of al array. 
    /// </summary>
    public static class KahanSummation {

        /// <summary>
        ///     Sums up an array of double with minimum lost on the precision. 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double Sum(double[] array)
        {
            double Result = 0; 
            {
                double RunningSum = 0, Compensator = 0;
                foreach (double D in array)
                {
                    double Temp = RunningSum + D;
                    if (Math.Abs(RunningSum) >= Math.Abs(D))
                    {
                        Compensator += (RunningSum  - Temp) + D;
                    }
                    else 
                    {
                        Compensator += (D - Temp) + RunningSum;
                    }
                }
            }
            return Result;
        }
    }

    /// <summary>
    ///     Use This class anytime when you are summing up floats in a for-loop and shit.     
    ///     <para>
    ///         This class is mutable. 
    ///     </para>
    ///     <para> 
    ///         This class uses double precision to keep track of things.     
    ///     </para>
    /// </summary>
    public class KahanRunningSum : IComparable<double>, IComparable<KahanRunningSum>
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
                // It's rounded, and the last addiction has to rouund it, so that it's accurate. 
            }
        }
        
        public int CompareTo(double other)
        {
            return Math.Sign(this.Value - other);
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj)) return true; 
            if (obj is KahanRunningSum)
            {
                KahanRunningSum other = obj as KahanRunningSum;
                return this.Value == other.Value;
            }
            if (obj is double)
            {
                return this.Value == (double)obj; 
            }
            return base.Equals(obj);
        }

        /// <summary>
        ///     It appeared just to please the IDE. 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo([AllowNull] KahanRunningSum other)
        {
            if (other is null)
            {
                return -1;
            }
            return this.CompareTo(other.Value); 
        }

        public static KahanRunningSum operator +(KahanRunningSum theSum, double beingAdded)
        {
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

        public static bool operator >=(KahanRunningSum theSum, double other)
        {
            int sign = theSum.CompareTo(other);
            return sign == 1 || sign == 0;
        }

        public static bool operator <=(KahanRunningSum theSum, double other)
        {
            return !(theSum > other);
        }

        public static bool operator >=(KahanRunningSum theSum, KahanRunningSum other)
        {
            return other <= theSum.Value;
        }

        public static bool operator <=(KahanRunningSum theSum, KahanRunningSum other)
        {
            return other >= theSum.Value; 
        }

        public static bool operator ==(KahanRunningSum theSum, double other)
        {
            return theSum.Value == other;
        }

        public static bool operator !=(KahanRunningSum theSum, double other)
        {
            return !(theSum == other);  
        }

    }

    /// <summary>
    ///     For summing up the complex numbers that is supported by CSharp. 
    /// </summary>
    public class KahanRunningSumComplex
    { 
        
    }


}
