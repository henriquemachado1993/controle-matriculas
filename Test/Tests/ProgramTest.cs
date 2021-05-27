using System;
using System.Collections.Generic;
using ControleMatricula;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void ProcessaListaMatriculaSemDv_retorno_lista_de_matriculas()
        {
            List<string> lstMatriculas = new List<string>() { "9876", "9992" };
            var lstMtrComDv = Program.ProcessaListaMatriculaSemDv(lstMatriculas);

            Assert.IsNotNull(lstMtrComDv);
        }

        [TestMethod]
        public void ProcessaListaMatriculaSemDv_exception()
        {
            Exception expectedExcetpion = null;
            try
            {
                List<string> lstMatriculas = new List<string>() { };
                Program.ProcessaListaMatriculaSemDv(lstMatriculas);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex; 
            }

            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod]
        public void ProcessaDv_retorno_digito_verificador()
        {
            var dvProcessado = "E";
            var dv = Program.ProcessaDv("9876");

            Assert.AreEqual(dv, dvProcessado);
        }

        [TestMethod]
        public void ProcessaDv_exception()
        {
            Exception expectedExcetpion = null;
            try
            {
                Program.ProcessaDv("9876e32f");
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod]
        public void VerificarMatriculas_retorno_lista_de_matriculas_verificadas()
        {
            List<string> lstMatriculas = new List<string>() { "9876-E", "9992-0", "9992584-E" };
            var lstMtrVerficadas = Program.VerificarMatriculas(lstMatriculas);

            Assert.IsNotNull(lstMtrVerficadas);
        }

        [TestMethod]
        public void VerificarMatriculas_exception()
        {
            Exception expectedExcetpion = null;
            try
            {
                Program.VerificarMatriculas(new List<string>() { });
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
            var lstMatricula = Program.LerMatriculas("matriculasSemDV.txt");

            Assert.IsNotNull(lstMatricula);
        }

        [TestMethod]
        public void LerMatriculas_exception()
        {
            Exception expectedExcetpion = null;
            try
            {
                Program.LerMatriculas("matriculasSemDVqweqweqweqweqwe.txt");
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
            Program.GravarMatriculas(lstMatriculas, "matriculasSemDV.txt");
        }

        [TestMethod]
        public void GravarMatriculas_exception()
        {
            Exception expectedExcetpion = null;
            try
            {
                Program.GravarMatriculas(new List<string>() {}, "matriculasSemDV.txt");
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod]
        public void FileUtil_delete()
        {
            FileUtil.Delete("matriculasSemDV.txt", @"c:\temp");
        }

        [TestMethod]
        public void FileUtil_delete_exception()
        {
            Exception expectedExcetpion = null;
            try
            {
                FileUtil.Delete("matriculasSemDV.txt", @"c:\temp342fdsfsdf");
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }
    }
}
