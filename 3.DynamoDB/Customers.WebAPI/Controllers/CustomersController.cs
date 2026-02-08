using Customers.WebAPI.DTOs;
using Customers.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customers.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CustomersController(CustomerRepository customerRepository) : ControllerBase
{
	[HttpPost]
	public async Task<IActionResult> Create(CreateCustomerDto request)
	{
		bool result = await customerRepository.CreateAsync(request);
		return NoContent();
	}

	[HttpPost]
	public async Task<IActionResult> Update(UpdateCustomerDto request, DateTime requestStarted)
	{
		bool result = await customerRepository.UpdateAsync(request, requestStarted);
		return NoContent();
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteById(Guid id)
	{
		bool result = await customerRepository.DeleteByIdAsync(id);
		return NoContent();
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		IEnumerable<CustomerDto> customers = await customerRepository.GetAllAsync();
		return Ok(customers);
	}
}
