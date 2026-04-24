using System;

namespace Echo
{
    public static class MathHelper
    {
        /// <summary>
        /// Effettua una mappatura lineare di un valore da un intervallo sorgente a un intervallo destinazione,
        /// limitando il risultato all'intervallo destinazione (clamp).
        /// </summary>
        /// <param name="value">Il valore da mappare.</param>
        /// <param name="sourceMin">Il minimo dell'intervallo sorgente.</param>
        /// <param name="sourceMax">Il massimo dell'intervallo sorgente.</param>
        /// <param name="targetMin">Il minimo dell'intervallo destinazione.</param>
        /// <param name="targetMax">Il massimo dell'intervallo destinazione.</param>
        /// <returns>Il valore mappato e limitato all'intervallo destinazione.</returns>
        /// <exception cref="ArgumentException">
        /// Lanciata se <paramref name="sourceMin"/> è uguale a <paramref name="sourceMax"/>, 
        /// poiché l'intervallo sorgente non può avere lunghezza zero.
        /// </exception>
        public static double LinearMapClamp(double value, double sourceMin, double sourceMax, double targetMin, double targetMax)
        {
            if (sourceMin == sourceMax)
                throw new ArgumentException("L'intervallo sorgente non può avere lunghezza zero.", nameof(sourceMin));

            // Calcolo lineare
            double mapped = targetMin + (value - sourceMin) * (targetMax - targetMin) / (sourceMax - sourceMin);

            // Clamp nell'intervallo target
            if (targetMin < targetMax)
                return Clamp(mapped, targetMin, targetMax);
            else
                return Clamp(mapped, targetMax, targetMin);
        }

        /// <summary>
        /// Restituisce <paramref name="value"/> limitato all'intervallo inclusivo definito da <paramref name="min"/> e <paramref name="max"/>.
        /// </summary>
        /// <param name="value">Il valore da limitare.</param>
        /// <param name="min">Il limite minimo dell'intervallo.</param>
        /// <param name="max">Il limite massimo dell'intervallo.</param>
        /// <returns>Il valore <paramref name="value"/> se è compreso tra <paramref name="min"/> e <paramref name="max"/>, altrimenti il limite più vicino.</returns>
        public static double Clamp(double value, double min, double max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}
