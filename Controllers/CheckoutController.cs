using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketCheckout.Services;
using System;

namespace SupermarketCheckout.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly CheckoutServices _checkout;

        public CheckoutController(CheckoutServices checkout)
        {
            _checkout = checkout;
        }

        [HttpGet("{skus}")]
        public IActionResult Checkout(string skus)
        {
            try
            {
                int totalPrice = _checkout.Checkout(skus);
                return Ok(totalPrice);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
