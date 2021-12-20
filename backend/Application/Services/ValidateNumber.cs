using api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public static class ValidateNumber
    {
        public static NumberInfo Execute(int number)
        {
            try
            {
                if (number <= 0)
                {
                    throw new Exception("O número deve ser um valor superior a 0");
                }
                NumberInfo info = new NumberInfo(number);

                GetFactorial(info);

                GetDivisorsNumbers(info);

                GetPrimeNumbers(info);

                return info;
            }
            catch (Exception)
            {

                throw;
            }
   
        }

        public static void GetFactorial(NumberInfo info)
        {
            List<int> factorials = new List<int>();

            int factorial_number = 2;

            int number = info.Number;

            while (number != 1)
            {
                if (number % factorial_number == 0)
                {

                    number /= factorial_number;
                    factorials.Add(factorial_number);
                    factorial_number = 2;
                }
                else
                {
                    factorial_number++;
                }
            }
            if (info.Number == 1)
                factorials.Add(1);
            info.FactorialNumbers = factorials;
        }

        public static void GetDivisorsNumbers(NumberInfo info)
        {
            List<int> divisors = new List<int>
            {
                1
            };

            foreach (int factorial in info.FactorialNumbers)
            {
                List<int> divisorsAux = new List<int>();
                foreach (int divisor in divisors)
                {
                    int numero = factorial * divisor;

                    if (!divisors.Contains(numero))
                        divisorsAux.Add(numero);
                }

                divisors.AddRange(divisorsAux);
                divisorsAux.Clear();
            }

            divisors.Sort();

            info.DivisorsNumbers = divisors;
        }

        public static void GetPrimeNumbers(NumberInfo info)
        {

            List<int> primeNumbers = new List<int>();

            foreach (int divisor in info.DivisorsNumbers)
            {
                if (divisor == 1 || divisor == 2)
                {
                    primeNumbers.Add(divisor);
                    continue;
                }
                else
                {
                    int count = 0;
                    for (int i = 2; i <= divisor; i++)
                    {
                        if (divisor % i == 0)
                            count++;
                    }

                    if (count < 2)
                    {
                        primeNumbers.Add(divisor);
                    }
                }
            }

            info.PrimeNumbers = primeNumbers;
        }
    }
}
