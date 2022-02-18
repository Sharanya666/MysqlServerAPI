using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransactionProject.Model;

namespace TransactionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly TransactionDbContext atmdbcontext;
        public CustomerController(TransactionDbContext _atmDbContext)
        {
            atmdbcontext = _atmDbContext;
        }
        [HttpGet]
        public IEnumerable<CustomerDetails> GetCustomerDetails()
        {
            return atmdbcontext.customerdetails.ToList();
        }

        [HttpGet("GetAccountNumber")]
        public CustomerDetails GetAccountNumber(long AccountNumber)
        {
            return atmdbcontext.customerdetails.Find(AccountNumber);
        }
        [HttpPost("InsertCustomer")]
        public IActionResult InsertCustomer([FromBody] CustomerDetails customerDetails)
        {
            if (customerDetails.AccountNumber.ToString() != "")
            {
                atmdbcontext.customerdetails.Add(customerDetails);
                atmdbcontext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer([FromBody] CustomerDetails customerDetails)
        {
            if (customerDetails.AccountNumber.ToString() != "")
            {
                atmdbcontext.Entry(customerDetails).State = EntityState.Modified;
                atmdbcontext.SaveChanges();
                return Ok("Customer Details updated successfully!");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("DeleteCustomer")]
        public IActionResult DeleteCustomer(long AccountNumber)
        {
            //select * from CustomerDetails where AccountNumber=123
            var result = atmdbcontext.customerdetails.Find(AccountNumber);
            if (result != null)
            {
                atmdbcontext.customerdetails.Remove(result);
                atmdbcontext.SaveChanges();
                return Ok("Deleted Successfully");
            }
            else
            {
                return NotFound("Invalid Account number");
            }

        }
    }
}
