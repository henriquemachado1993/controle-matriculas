using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleMatricula
{
    public class Program
    {
        const string path = @"c:\temp";
        const string fileNameMatriculasSemDv = "matriculasSemDV.txt";
        const string fileNameMatriculasComDv = "matriculasComDv.txt";
        const string fileNameMatriculasVerificadas = "matriculasVerificadas.txt";

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("============== Aperte 'Enter' para começar o processamento ==============");
                Console.WriteLine("");
                Console.ReadKey();

                // Grava matrículas iniciais sem dígito verificador
                Console.WriteLine("Gravando matrículas inciais...");
                List<string> lstMatriculasInicial = new List<string>() { "9876", "9992", "1234", "2225", "8882", "9875" };                
                GravarMatriculas(lstMatriculasInicial, fileNameMatriculasSemDv);

                // Ler matrículas sem dígito verificador e processa
                Console.WriteLine("Processando matrículas sem dígito verificador...");
                List<string> lstMatriculasSemDv = LerMatriculas(fileNameMatriculasSemDv);
                List<string> lstMatriculasComDv = ProcessaListaMatriculaSemDv(lstMatriculasSemDv);
                GravarMatriculas(lstMatriculasComDv, fileNameMatriculasComDv);

                // Ler e verifica as matrículas com dígito verificador processadas anteriormente
                Console.WriteLine("Verificando matrículas processadas...");
                List<string> lstMatriculasParaVerificar = LerMatriculas(fileNameMatriculasComDv);
                List<string> lstMatriculasVerificadas = VerificarMatriculas(lstMatriculasParaVerificar);
                GravarMatriculas(lstMatriculasVerificadas, fileNameMatriculasVerificadas);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public static List<string> ProcessaListaMatriculaSemDv(List<string> lstMatricula)
        {
            if (!lstMatricula.Any())
                throw new MissingFieldException($"Não foi possível processar matrículas, nenhuma encontrada!");
            var lstMatriculaComDv = new List<string>();
            foreach (string matricula in lstMatricula)
            {
                string digitoVerificador = ProcessaDv(matricula);
                string mtrDv = $"{matricula}-{digitoVerificador}";
                Console.WriteLine($"Matrícula processada: {matricula} => {mtrDv}");                
                lstMatriculaComDv.Add(mtrDv);
            }
            Console.WriteLine("");
            return lstMatriculaComDv;
        }

        public static string ProcessaDv(string matricula)
        {
            var lstCaracterMtr = matricula.ToList();
            if(lstCaracterMtr.Count != 4)
                throw new MissingFieldException($"Não foi possível processar o dígito verificador, número de caracters não atigido!");
            var lstNumMult = new List<int>();
            var lstNumCalc = new List<int>() { 5, 4, 3, 2};
            for (int i = 0; i < lstCaracterMtr.Count; i++)
            {
                lstNumMult.Add(Convert.ToInt32(lstCaracterMtr[i]) * lstNumCalc[i]);
            }
            var total = lstNumMult.Sum();
            var resto = total % 16;
            var dv = resto.ToString("X");            
            return dv.ToUpper();
        }

        public static List<string> VerificarMatriculas(List<string> lstMatricula)
        {
            if (!lstMatricula.Any())
                throw new MissingFieldException($"Não foi possível verificar matrículas, nenhuma encontrada!");
            string mtrVerificada = string.Empty;
            var lstMtrVerificadas = new List<string>();
            foreach (var mtr in lstMatricula)
            {
                if(mtr.Length != 6)
                {
                    mtrVerificada = $"{mtr} falso";
                    lstMtrVerificadas.Add(mtrVerificada);
                    Console.WriteLine($"Matrícula verificada: {mtrVerificada}");
                    continue;
                }
                string mtrSemDv = mtr.Substring(0, mtr.Length-2);
                string dvMtr = mtr.Substring(5, 1);
                string dvValido = ProcessaDv(mtrSemDv);                
                if (dvMtr != dvValido || dvMtr == "0")
                {
                    mtrVerificada = $"{mtr} falso";
                    lstMtrVerificadas.Add(mtrVerificada);
                }
                else
                {
                    mtrVerificada = $"{mtr} verdadeiro";
                    lstMtrVerificadas.Add(mtrVerificada);
                }                   
                Console.WriteLine($"Matrícula verificada: {mtrVerificada}");
            }
            Console.WriteLine("");
            return lstMtrVerificadas;
        }

        public static List<string> LerMatriculas(string nameFile)
        {
            return FileUtil.Read(nameFile, path);
        }

        public static void GravarMatriculas(List<string> lstMatriculas, string nameFile)
        {
            if (!lstMatriculas.Any())
                throw new MissingFieldException($"Não foi possível gravar matrículas, nenhuma encontrada!");
            FileUtil.Save(nameFile, path, lstMatriculas);
            Console.WriteLine($"Matrículas gravadas em: {path}\\{nameFile}");
            Console.WriteLine("");
        }
    }
}
