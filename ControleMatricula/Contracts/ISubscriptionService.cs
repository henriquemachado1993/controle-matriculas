using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMatricula.Contracts
{
    public interface ISubscriptionService
    {
        List<string> ReadSubscription(string fileName);
        List<string> ProcessSubscriptionsWithoutVerifyingDigit(List<string> Subscriptions);
        List<string> VerifySubscriptions(List<string> Subscriptions);
        void SaveSubscriptions(List<string> Subscriptions, string fileName);
    }
}
