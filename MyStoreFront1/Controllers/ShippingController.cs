using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStoreFront1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStoreFront1.Controllers
{
    public class ShippingController : Controller
    {
        private JoshTestContext _context;
        private Braintree.BraintreeGateway _braintreeGateway;

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ShippingViewModel model, string creditcardnumber, string creditcardname, string creditcardverificationvalue, string expirationmonth, string expirationyear)
        {
            //System.Text.RegularExpressions.Regex = new System.Text.RegularExpressions.Regex();


            if (ModelState.IsValid)
            {
                Braintree.TransactionRequest saleRequest = new Braintree.TransactionRequest();
                saleRequest.Amount = 10;    //Hard-coded for now
                saleRequest.CreditCard = new Braintree.TransactionCreditCardRequest
                {
                    CardholderName = creditcardname,
                    CVV = creditcardverificationvalue,
                    ExpirationMonth = expirationmonth,
                    ExpirationYear = expirationyear,
                    Number = creditcardnumber
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
