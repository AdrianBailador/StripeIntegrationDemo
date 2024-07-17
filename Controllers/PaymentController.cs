using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using StripeIntegrationDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PaymentController : Controller
{
    private readonly StripeSettings _stripeSettings;

    public PaymentController(IOptions<StripeSettings> stripeSettings)
    {
        _stripeSettings = stripeSettings.Value;
    }

    [HttpGet]
    public IActionResult Checkout()
    {
        ViewBag.PublishableKey = _stripeSettings.PublishableKey;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCheckoutSession()
    {
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = 2000,
                        Currency = "eur",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Test Product",
                        },
                    },
                    Quantity = 1,
                },
            },
            Mode = "payment",
            SuccessUrl = Url.Action("Success", "Payment", null, Request.Scheme),
            CancelUrl = Url.Action("Cancel", "Payment", null, Request.Scheme),
        };

        try
        {
            var service = new SessionService();
            Session session = await service.CreateAsync(options);

            return Json(new { id = session.Id });
        }
        catch (StripeException e)
        {
            // Log the error and return a bad request response
            // You can use a logging library like Serilog or NLog for better logging
            return BadRequest(new { error = e.Message });
        }
    }

    public IActionResult Success()
    {
        return View();
    }

    public IActionResult Cancel()
    {
        return View();
    }
}
