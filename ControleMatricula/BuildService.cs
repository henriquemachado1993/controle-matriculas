using ControleMatricula.Contracts;
using ControleMatricula.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMatricula
{
    public static class BuildService
    {
        public static ISubscriptionService CreateSubscritionService()
        {
            return new SubscriptionService();
        }
    }
}
