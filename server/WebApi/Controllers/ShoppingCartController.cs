using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ShoppingCartController : ApiController
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> GetShoppingCartById(string id) {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartAsync(id);

            return Ok(shoppingCart ?? new ShoppingCart(id));
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateShoppingCart(ShoppingCart shoppingCart) {
            var updatedShoppingCart = await _shoppingCartRepository.UpdateShoppingCartAsync(shoppingCart);

            return Ok(updatedShoppingCart);
        }

        [HttpDelete]
        public async Task DeleteShoppingCart(string id) {
            await _shoppingCartRepository.DeleteShoppingCartAsync(id);
        }
    }
}