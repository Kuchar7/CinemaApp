using IBL;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StripePaymentValidation : IStripePaymentValidation
    {
        public bool IsApproved(Charge charge)
        {
            if(charge.Status != "succeeded")
            {
                return false;
            }
            return true;
        }
    }
}
