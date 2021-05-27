using ControleMatricula.Contracts;
using ControleMatricula.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMatricula.Service
{
    public class SubscriptionService : ISubscriptionService
    {
        const string path = @"c:\temp";
        
        public List<string> ProcessSubscriptionsWithoutVerifyingDigit(List<string> Subscriptions)
        {
            if (!Subscriptions.Any())
                throw new MissingFieldException($"Unable to process subscriptons, none found!");
            var subscriptionsVd = new List<string>();
            foreach (string subscription in Subscriptions)
            {
                string verifyingDigit = ProcessVerifyDigit(subscription);
                string subVd = $"{subscription}-{verifyingDigit}";
                Console.WriteLine($"Processed subscriptions: {subscription} => {subVd}");
                subscriptionsVd.Add(subVd);
            }
            Console.WriteLine("");
            return subscriptionsVd;
        }

        public List<string> ReadSubscription(string fileName)
        {
            return FileHelper.Read(fileName, path);
        }

        public List<string> VerifySubscriptions(List<string> Subscriptions)
        {
            if (!Subscriptions.Any())
                throw new MissingFieldException($"Unable to process subscriptons, none found!");
            string subscritionVerifyed = string.Empty;
            var subscritionsVerifyed = new List<string>();
            foreach (var sub in Subscriptions)
            {
                if (sub.Length != 6)
                {
                    subscritionVerifyed = $"{sub} false";
                    subscritionsVerifyed.Add(subscritionVerifyed);
                    Console.WriteLine($"Subscrition verifyed: {subscritionVerifyed}");
                    continue;
                }
                string subscritionsWithoutVd = sub.Substring(0, sub.Length - 2);
                string subVd = sub.Substring(5, 1);
                string validVd = ProcessVerifyDigit(subscritionsWithoutVd);
                if (subVd != validVd || subVd == "0")
                {
                    subscritionVerifyed = $"{sub} false";
                    subscritionsVerifyed.Add(subscritionVerifyed);
                }
                else
                {
                    subscritionVerifyed = $"{sub} true";
                    subscritionsVerifyed.Add(subscritionVerifyed);
                }
                Console.WriteLine($"Subscrition verifyed: {subscritionVerifyed}");
            }
            Console.WriteLine("");
            return subscritionsVerifyed;
        }

        private static string ProcessVerifyDigit(string subscription)
        {
            var inscriptionCharacters = subscription.ToList();
            if (inscriptionCharacters.Count != 4)
                throw new MissingFieldException($"It was not possible to process the check digit, number of characters not reached!");
            var nunsMult = new List<int>();
            var nunsCalc = new List<int>() { 5, 4, 3, 2 };
            for (int i = 0; i < inscriptionCharacters.Count; i++)
            {
                nunsMult.Add(Convert.ToInt32(inscriptionCharacters[i]) * nunsCalc[i]);
            }
            var total = nunsMult.Sum();
            var rest = total % 16;
            var vd = rest.ToString("X");
            return vd.ToUpper();
        }

        public void SaveSubscriptions(List<string> Subscriptions, string fileName)
        {
            if (!Subscriptions.Any() || string.IsNullOrEmpty(fileName))
                throw new MissingFieldException($"error !");
            FileHelper.Save(fileName, path, Subscriptions);
            Console.WriteLine($"Inscriptions recorded in: {path}\\{fileName}");
            Console.WriteLine("");
        }
    }
}
