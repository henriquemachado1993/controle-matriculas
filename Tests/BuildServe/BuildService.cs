using ControleMatricula.Contracts;
using ControleMatricula.Service;

namespace Tests.BuildServe
{
    public static class BuildService
    {
        public static ISubscriptionService CreateSubscritionService()
        {
            return new SubscriptionService();
        }
    }
}
