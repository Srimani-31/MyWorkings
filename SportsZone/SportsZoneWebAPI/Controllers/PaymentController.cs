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
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetPaymentMethod/{paymentID}")]
        public async Task<ActionResult<PaymentResponseDTO>> GetPaymentMethodByPaymentID(int paymentID)
        {
            try
            {
                PaymentResponseDTO paymentResponseDTO = await _paymentService.GetPaymentMethodByPaymentID(paymentID);
                return Ok(paymentResponseDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("AddNewPaymentMethod")]
        public async Task<ActionResult<PaymentRequestDTO>> AddNewPaymentMethod([FromBody] PaymentRequestDTO paymentRequestDTO)
        {
            try
            {
                await _paymentService.AddNewPaymentMethod(paymentRequestDTO);
                return Ok(paymentRequestDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdatePayment")]
        public async Task<ActionResult<PaymentRequestDTO>> UpdatePayment([FromBody] PaymentRequestDTO paymentRequestDTO)
        {
            try
            {
                await _paymentService.UpdatePayment(paymentRequestDTO);
                return Ok(paymentRequestDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete, Route("DeletePayment/{paymentID}")]
        public async Task<ActionResult> DeletePaymentByPaymentID(int paymentID)
        {
            try
            {
                await _paymentService.DeletePaymentByPaymentID(paymentID);
                return Ok($"Payment method with ID : {paymentID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
