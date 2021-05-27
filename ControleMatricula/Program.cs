using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleMatricula
{
    public class Program
    {
        const string fileNameInscriptionsWithoutDigitVerifying = "inscriptions-without-digit-verifying.txt";
        const string fileNameInscriptionsWithDigitVerifying = "inscriptions-with-digit-verifying.txt";
        const string fileNameVerifiedSubscriptions = "verified-subscriptions.txt";

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("============== Press 'Enter' to start processing ==============");
                Console.WriteLine("");
                Console.ReadKey();

                var subscritionService = BuildService.CreateSubscritionService();

                Console.WriteLine("Recording initial subscriptions...");
                var initialSubscriptions = new List<string>() { "9876", "9992", "1234", "2225", "8882", "9875" };
                subscritionService.SaveSubscriptions(initialSubscriptions, fileNameInscriptionsWithoutDigitVerifying);

                // Read entries without a check digit and process
                Console.WriteLine("Processing subscriptions without a check digit...");
                var subscriptionsWithoutVd = subscritionService.ReadSubscriptions(fileNameInscriptionsWithoutDigitVerifying);
                var subscriptionsWithVd = subscritionService.ProcessSubscriptionsWithoutVerifyingDigit(subscriptionsWithoutVd);
                subscritionService.SaveSubscriptions(subscriptionsWithVd, fileNameInscriptionsWithDigitVerifying);

                // Read and verify previously processed check digit entries
                Console.WriteLine("Checking processed subscriptions...");
                var subscriptionsToCheck = subscritionService.ReadSubscriptions(fileNameInscriptionsWithDigitVerifying);
                var verifiedSubscriptions = subscritionService.VerifySubscriptions(subscriptionsToCheck);
                subscritionService.SaveSubscriptions(verifiedSubscriptions, fileNameVerifiedSubscriptions);

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
