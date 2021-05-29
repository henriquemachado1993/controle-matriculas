using System.Collections.Generic;

namespace ControleMatricula.Contracts
{
    public interface ISubscriptionService
    {
        List<string> ReadSubscriptions(string fileName);
        List<string> ProcessSubscriptionsWithoutVerifyingDigit(List<string> Subscriptions);
        List<string> VerifySubscriptions(List<string> Subscriptions);
        void SaveSubscriptions(List<string> Subscriptions, string fileName);
    }
}
