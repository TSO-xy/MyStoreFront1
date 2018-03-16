using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MyStoreFront1.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStoreFront1.Controllers
{
    public class ShippingController : Controller
    {
        private OrderViewModel orderModel;
        private ShippingViewModel model;
        private JoshTestContext _context;
        private SignInManager<ApplicationUser> _signInManager;
        private Braintree.BraintreeGateway _braintreeGateway;
        private SmartyStreets.USStreetApi.Client _usStreetClient;

        public ShippingController(JoshTestContext context, Braintree.BraintreeGateway braintreeGateway, SignInManager<ApplicationUser> signInManager, SmartyStreets.USStreetApi.Client usStreetClient)
        {
            _context = context;
            _braintreeGateway = braintreeGateway;
            _signInManager = signInManager;
            _usStreetClient = usStreetClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string cartId;
            Guid trackingNumber;
            OrderViewModel order = new OrderViewModel();

            if (Request.Cookies.TryGetValue("cartId", out cartId) && Guid.TryParse(cartId, out trackingNumber) && _context.Cart.Any(x => x.TrackingNumber == trackingNumber))
            {
                var cart = _context.Cart.Include(x => x.CartProducts).ThenInclude(y => y.Products).Single(x => x.TrackingNumber == trackingNumber);
                order.CartProducts = cart.CartProducts.ToArray();
            }

            return View(order);
        }

        public IActionResult ValidateAddress(string street = "222 W Ontario", string city = "Chicago", string state = "IL")
        {
            SmartyStreets.USStreetApi.Lookup lookup = new SmartyStreets.USStreetApi.Lookup();
            _usStreetClient.Send(lookup);
            lookup.Street = street;
            lookup.City = city;
            lookup.State = state;
            return Json(lookup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ShippingViewModel model)
        {
            //System.Text.RegularExpressions.Regex = new System.Text.RegularExpressions.Regex();


            if (ModelState.IsValid)
            {
                Braintree.TransactionRequest saleRequest = new Braintree.TransactionRequest();
                saleRequest.Amount = 10;    //Hard-coded for now
                saleRequest.CreditCard = new Braintree.TransactionCreditCardRequest
                {
                    CardholderName = model.CreditCardName,
                    CVV = model.CVV,
                    ExpirationMonth = model.ExpMonth,
                    ExpirationYear = model.ExpYear,
                    Number = model.CreditCardNumber
                        
                };
                saleRequest.BillingAddress = new Braintree.AddressRequest
                {
                    StreetAddress = model.BillingStreet,
                    PostalCode = model.BillingZipCode,
                    Region = model.BillingState,
                    Locality = model.BillingCity,
                    CountryName = "United States of America",
                    CountryCodeAlpha2 = "US",
                    CountryCodeAlpha3 = "USA",
                    CountryCodeNumeric = "840"
                };
                var result = await _braintreeGateway.Transaction.SaleAsync(saleRequest);

                if (result.IsSuccess())
                {
                    return this.RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors.All())
                {
                    ModelState.AddModelError(error.Code.ToString(), error.Message);
                }
            }
                return View(model);
        }
    }
}
