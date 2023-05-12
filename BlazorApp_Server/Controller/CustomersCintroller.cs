using BlazorApp_Server.Model;
using BlazorApp_Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp_Server.Controller;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomersController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetAll()
    {
        var customers = _customerRepository.GetAll();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> GetById(int id)
    {
        var customer = _customerRepository.GetById(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public ActionResult<Customer> Create(Customer customer)
    {
        _customerRepository.Add(customer);
        return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Customer customer)
    {
        if (id != customer.Id)
        {
            return BadRequest();
        }

        _customerRepository.Update(customer);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var customer = _customerRepository.GetById(id);
        if (customer == null)
        {
            return NotFound();
        }

        _customerRepository.Delete(customer);
        return NoContent();
    }
}
