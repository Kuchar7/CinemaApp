using DAL;
using IBL;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StripePayment : IStripePayment
    {
        readonly DatabaseContext dbContext;
        public StripePayment(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            StripeConfiguration.SetApiKey("pk_test_51IzgmiK6Drh2LRZD71XV1Kt6v7iApTUT3LJkDz4JW51f0irYnL8ilFwUdURsUQEVy7CS1LRMl45wfmhKZwUGpBcG00yWUMuJsw");
            StripeConfiguration.ApiKey = "sk_test_51IzgmiK6Drh2LRZDXaJC06rKy2ETj3EVblfrVecsevxgSSU1gWnsJ0pAVLkvfcKKKywe50IgP48ZmaSUppWQZq2w00870Pj7Ps";
        }
        public Charge CreateCharge(string stripeToken, int reservationId)
        {
            var chargeDetails = dbContext.Reservations.Where(x => x.Id == reservationId).Select(x => new { FullPrice = x.Price,
                MovieTitle = x.Screening.Movie.Title }).FirstOrDefault();
            ChargeCreateOptions chargeOptions = new ChargeCreateOptions
            {
                Currency = "PLN",
                Source = stripeToken,
                Description = chargeDetails.MovieTitle,
                Amount = Convert.ToInt64(chargeDetails.FullPrice*100)
            };
            ChargeService chargeService = new ChargeService();
            Charge charge = chargeService.Create(chargeOptions);
            return charge;
        }
    }
}
