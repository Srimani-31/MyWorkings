using Microsoft.AspNetCore.Mvc;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet, Route("GetAllPaymentMethods")]
        public async Task<ActionResult<IEnumerable<PaymentResponseDTO>>> GetAllPaymentMethods()
        {
            try
            {
                IEnumerable<PaymentResponseDTO> paymentResponseDTOs = await _paymentService.GetAllPaymentMethods();
                return Ok(paymentResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet, Route("GetPaymentMethod/{paymentID}")]
        public async Task<ActionResult<PaymentResponseDTO>> GetPaymentMethodByPaymentID(int paymentID)
        {
            try
            {
                if (paymentID == 0)
                {
                    return BadRequest();
                }
                if (!await _paymentService.IsAvail(paymentID))
                {
                    return NotFound();
                }
                PaymentResponseDTO paymentResponseDTO = await _paymentService.GetPaymentMethodByPaymentID(paymentID);
                return Ok(paymentResponseDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost, Route("AddNewPaymentMethod")]
        public async Task<ActionResult<PaymentRequestDTO>> AddNewPaymentMethod([FromBody] PaymentRequestDTO paymentRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _paymentService.IsAvail(paymentRequestDTO.PaymentID))
                {
                    return Conflict();
                }
                await _paymentService.AddNewPaymentMethod(paymentRequestDTO);
                return Ok(paymentRequestDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut, Route("UpdatePayment")]
        public async Task<ActionResult<PaymentRequestDTO>> UpdatePayment([FromBody] PaymentRequestDTO paymentRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!await _paymentService.IsAvail(paymentRequestDTO.PaymentID))
                {
                    return NotFound();
                }
                await _paymentService.UpdatePayment(paymentRequestDTO);
                return Ok(paymentRequestDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete, Route("DeletePayment/{paymentID}")]
        public async Task<ActionResult> DeletePaymentByPaymentID(int paymentID)
        {
            try
            {
                if (paymentID == 0)
                {
                    return BadRequest("Input parameter 'paymentID' is required and cannot be empty.");
                }
                if (!await _paymentService.IsAvail(paymentID))
                {
                    return NotFound();
                }
                await _paymentService.DeletePaymentByPaymentID(paymentID);
                return Ok($"Payment method with ID : {paymentID} deleted succesfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
