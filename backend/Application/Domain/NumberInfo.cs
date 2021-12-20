using System.Collections.Generic;

namespace api.Domain
{
    public class NumberInfo
    {

        public NumberInfo(int _number)
        {
            Number = _number;
            DivisorsNumbers = new List<int>();
            PrimeNumbers = new List<int>();
        }

        /// <summary>
        /// Número informado
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Lista de divisores
        /// </summary>
        public List<int> DivisorsNumbers { get; set; }

        /// <summary>
        /// Lista de números primos
        /// </summary>
        public List<int> PrimeNumbers { get; set; }


        /// <summary>
        /// Lista de fatores
        /// </summary>
        public List<int> FactorialNumbers { get; set; }
    }
}
