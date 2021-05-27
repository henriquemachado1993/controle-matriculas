using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleMatricula
{
    public class Program
    {
        const string fileNameMatriculasSemDv = "inscriptions-without-digit-verifying.txt";
        const string fileNameMatriculasComDv = "inscriptions-with-digit-verifying.txt";
        const string fileNameMatriculasVerificadas = "verified-subscriptions.txt";

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("============== Aperte 'Enter' para começar o processamento ==============");
                Console.WriteLine("");
                Console.ReadKey();

                var subscritionService = BuildService.CreateSubscritionService();

                // Grava matrículas iniciais sem dígito verificador
                Console.WriteLine("Gravando matrículas inciais...");
                List<string> lstMatriculasInicial = new List<string>() { "9876", "9992", "1234", "2225", "8882", "9875" };
                subscritionService.SaveSubscriptions(lstMatriculasInicial, fileNameMatriculasSemDv);

                // Ler matrículas sem dígito verificador e processa
                Console.WriteLine("Processando matrículas sem dígito verificador...");
                List<string> lstMatriculasSemDv = subscritionService.ReadSubscription(fileNameMatriculasSemDv);
                List<string> lstMatriculasComDv = subscritionService.ProcessSubscriptionsWithoutVerifyingDigit(lstMatriculasSemDv);
                subscritionService.SaveSubscriptions(lstMatriculasComDv, fileNameMatriculasComDv);

                // Ler e verifica as matrículas com dígito verificador processadas anteriormente
                Console.WriteLine("Verificando matrículas processadas...");
                List<string> lstMatriculasParaVerificar = subscritionService.ReadSubscription(fileNameMatriculasComDv);
                List<string> lstMatriculasVerificadas = subscritionService.VerifySubscriptions(lstMatriculasParaVerificar);
                subscritionService.SaveSubscriptions(lstMatriculasVerificadas, fileNameMatriculasVerificadas);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
