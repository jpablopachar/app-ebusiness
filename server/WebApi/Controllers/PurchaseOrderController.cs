using System.Security.Claims;
using AutoMapper;
using Core.Entities.PurchaseOrder;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Errors;

namespace WebApi.Controllers
{
    [Authorize]
    public class PurchaseOrderController : ApiController
    {
        private readonly IPurchaseOrderService _purchaseOrder;
        private readonly IMapper _mapper;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrder, IMapper mapper)
        {
            _purchaseOrder = purchaseOrder;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<PurchaseOrders>> AddPurchaseOrder(PurchaseOrderDto purchaseOrderDto)
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var address = _mapper.Map<AddressDto, Address>(purchaseOrderDto.ShippingAddress);

            var purchaseOrder = await _purchaseOrder.AddShippingOrderAsync(email, purchaseOrderDto.ShippingType, purchaseOrderDto.ShoppingCartId, address);

            if (purchaseOrder == null) return BadRequest(new CodeErrorResponse(400, "Se produjo un error al crear la orden de compra"));

            return Ok(purchaseOrder);
        }
    }
}