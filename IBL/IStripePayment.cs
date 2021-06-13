using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IStripePayment
    {
        Charge CreateCharge(string stripeToken, int reservationId);
    }
}
