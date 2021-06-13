using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IStripePaymentValidation
    {
        bool IsApproved(Charge charge);
    }
}
