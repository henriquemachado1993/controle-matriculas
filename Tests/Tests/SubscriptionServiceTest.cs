using System;
using System.Collections.Generic;
using ControleMatricula.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.BuildServe;

namespace Tests.Tests
{
    [TestClass]
    public class SubscriptionServiceTest
    {
        private ISubscriptionService subService { get; set; }

        public SubscriptionServiceTest()
        {
            subService = BuildService.CreateSubscritionService();
        }

        [TestMethod]
        public void ProcessaListaMatriculaSemDv_retorno_lista_de_matriculas()
        {
            List<string> lstMatriculas = new List<string>() { "9876", "9992" };
            var lstMtrComDv = subService.ProcessSubscriptionsWithoutVerifyingDigit(lstMatriculas);

            Assert.IsNotNull(lstMtrComDv);
        }
                
        [TestMethod]
        public void VerificarMatriculas_retorno_lista_de_matriculas_verificadas()
        {
            List<string> lstMatriculas = new List<string>() { "9876-E", "9992-0", "9992584-E" };
            var lstMtrVerficadas = subService.VerifySubscriptions(lstMatriculas);

            Assert.IsNotNull(lstMtrVerficadas);
        }

        [TestMethod]
        public void VerificarMatriculas_exception()
        {
            Exception expectedExcetpion = null;
            try
            {
                subService.VerifySubscriptions(new List<string>() { });
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod]
        public void LerMatriculas_retorna_lista_de_matriculas()
        {
            var lstMatricula = subService.ReadSubscriptions("inscriptions-without-digit-verifying.txt");

            Assert.IsNotNull(lstMatricula);
        }

        [TestMethod]
        public void LerMatriculas_exception()
        {
            Exception expectedExcetpion = null;
            try
            {
                subService.ReadSubscriptions("qweqweqweqweqwe.txt");
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod]
        public void GravarMatriculas()
        {
            List<string> lstMatriculas = new List<string>() { "9876", "9992" };
            subService.SaveSubscriptions(lstMatriculas, "inscriptions-without-digit-verifying.txt");
        }

        [TestMethod]
        public void GravarMatriculas_exception()
        {
            Exception expectedExcetpion = null;
            try
            {
                subService.SaveSubscriptions(new List<string>() { }, "inscriptions-without-digit-verifying.txt");
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }
    }
}
