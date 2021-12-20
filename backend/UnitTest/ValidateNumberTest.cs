using api.Domain;
using api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTest
{
    public class ValidateNumberTest
    {
        [Fact]
        public void DeveRetornarAsInformacoesDoNumero()
        {
            NumberInfo InfoExpected = new NumberInfo(18)
            {
                    DivisorsNumbers = new List<int>()
                {
                    1,2,3,6,9,18
                },

                    PrimeNumbers = new List<int>()
                {
                    1,2,3
                },

                    FactorialNumbers = new List<int>()
                {
                    2,3,3
                }
            };


            NumberInfo InfoReturned = ValidateNumber.Execute(18);

            Assert.Equal(InfoExpected.DivisorsNumbers, InfoReturned.DivisorsNumbers);
            Assert.Equal(InfoExpected.PrimeNumbers, InfoReturned.PrimeNumbers);
            Assert.Equal(InfoExpected.FactorialNumbers, InfoReturned.FactorialNumbers);

        }

        [Fact]
        public void DeveRetornarMensagemDeErroQuandoValorInvalido()
        {
            string messageExpected = "O número deve ser um valor superior a 0";

            try
            {
                NumberInfo InfoReturned = ValidateNumber.Execute(-1);
            }
            catch (Exception e)
            {
                Assert.Equal(messageExpected, e.Message);
            }


        }

        [Fact]
        public void DeveRetornarOsFatoriaisDoNumero()
        {
            NumberInfo InfoExpected = new NumberInfo(24)
            {
                FactorialNumbers = new List<int>()
                {
                    2,2,2,3
                }
            };

            NumberInfo InfoReturned = new NumberInfo(24);

            ValidateNumber.GetFactorial(InfoReturned);

            Assert.Equal(InfoExpected.FactorialNumbers, InfoReturned.FactorialNumbers);
        }

        [Fact]
        public void DeveRetornarOsDivisores()
        {
            NumberInfo InfoExpected = new NumberInfo(27)
            {
                DivisorsNumbers = new List<int>()
                {
                  1, 3, 9, 27
                }
            };

            NumberInfo InfoReturned = new NumberInfo(27);

            InfoReturned.FactorialNumbers = new List<int>
            {
                3,3,3
            };

            ValidateNumber.GetDivisorsNumbers(InfoReturned);

            Assert.Equal(InfoExpected.DivisorsNumbers, InfoReturned.DivisorsNumbers);
        }

        [Fact]
        public void DeveRetornarOsNumerosPrimos()
        {
            NumberInfo InfoExpected = new NumberInfo(100)
            {
                PrimeNumbers = new List<int>()
                {
                  1, 2, 5
                }
            };

            NumberInfo InfoReturned = new NumberInfo(100);

            InfoReturned.DivisorsNumbers = new List<int>()
            {
                1, 2, 4, 5, 10, 20, 25, 50, 100
            };

            ValidateNumber.GetPrimeNumbers(InfoReturned);

            Assert.Equal(InfoExpected.PrimeNumbers, InfoReturned.PrimeNumbers);
        }
    }
}
