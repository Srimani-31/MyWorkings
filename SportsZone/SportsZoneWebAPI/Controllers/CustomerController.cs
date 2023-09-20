using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost, Route("GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<CustomerResponseDTO>>> GetAllCustomers()
        {
            try
            {
                IEnumerable<CustomerResponseDTO> customerResponseDTOs = await _customerService.GetAllCustomers();
                return Ok(customerResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet, Route("GetCustomerByCustomerID/{email}")]
        public async Task<ActionResult> GetCustomerByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    // Invalid input: Return a BadRequest response with an error message
                    return BadRequest();
                }
                if (!await _customerService.IsAvail(email))
                {
                    return NotFound();
                }
                CustomerResponseDTO customerResponseDTO = await _customerService.GetCustomerByCustomerID(email);
                return Ok(customerResponseDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost, Route("CreateCustomer")]
        public async Task<ActionResult<CustomerRequestDTO>> CreateCustomer([FromForm] CustomerRequestDTO customerRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Model validation failed: Return a BadRequest response with validation errors
                    return BadRequest(ModelState);
                }
                if (await _customerService.IsAvail(customerRequestDTO.Email))
                {
                    return Conflict();
                }
                await _customerService.CreateCustomer(customerRequestDTO, customerRequestDTO.ProfilePhoto);
                return Ok(customerRequestDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.InnerException);
            }
        }

        [HttpPut, Route("UpdateCustomer")]
        public async Task<ActionResult<CustomerRequestDTO>> UpdateCustomer([FromBody] CustomerRequestDTO customerRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Model validation failed: Return a BadRequest response with validation errors
                    return BadRequest(ModelState);
                }
                if (!await _customerService.IsAvail(customerRequestDTO.Email))
                {
                    return NotFound();
                }
                await _customerService.UpdateCustomer(customerRequestDTO);
                return Ok(customerRequestDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost, Route("Upload image")]
        public async Task<ActionResult> UploadImage(IFormFile image, string email)
        {
            try
            {
                if (image != null && image.Length > 0)
                {
                    //Ensure the file has a valid image file extension (e.g., .jpg, .png)
                    string fileExtension = Path.GetExtension(image.FileName).ToLower();
                    if (IsImageFileExtensionValid(fileExtension))
                    {
                        //Handle the image file as needed
                        //you can save it, proces it, or return a response
                        var webRootPath = Directory.GetCurrentDirectory();
                        var uploadDirectory = Path.Combine(webRootPath, "AppData", "CustomerImages");
                        var imageFileName = email + Guid.NewGuid().ToString().Substring(0, 4) + ".jpg";
                        Directory.CreateDirectory(uploadDirectory);

                        //Example: Saving the image to a file
                        var filePath = Path.Combine(uploadDirectory, imageFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                        }
                        CustomerResponseDTO customerResponseDTO = await _customerService.GetCustomerByCustomerID(email);
                        customerResponseDTO.ProfilePhoto = filePath;
                        

                        return Ok("Image uploaded successfully");
                    }
                    else
                    {
                        return BadRequest("Invalid file format. Support formats: .jpg, .png");
                    }
                }
                else
                {
                    return BadRequest("No file uploaded");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet, Route("Get image")]
        public ActionResult DownloadFile(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    return BadRequest();
                }
                if (System.IO.File.Exists(filePath))
                {
                    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    return File(fileStream, "application/octet-stream", Path.GetFileName(filePath));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private bool IsImageFileExtensionValid(string fileExtension)
        {
            // Add valid image file extensions as needed
            return fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png";
        }

        [HttpDelete, Route("DeleteCustomerByCustomerID/{email}")]
        public async Task<ActionResult> DeleteCustomerByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    // Invalid input: Return a BadRequest response with an error message
                    return BadRequest("Input parameter 'email' is required and cannot be empty.");
                }
                if (!await _customerService.IsAvail(email))
                {
                    return NotFound();
                }
                await _customerService.DeleteCustomerByCustomerID(email);
                return Ok($"Customer with ID : {email} deleted succesfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        #region Rare use case
        //[HttpDelete, Route("DeleteAllCustomers")]
        //public async Task<ActionResult> DeleteAllCustomers()
        //{
        //    try
        //    {
        //        await _customerService.DeleteAllCustomers();
        //        return Ok("All Customers deleted succesfully");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //} 
        #endregion
    }
}
