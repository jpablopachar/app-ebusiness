using System.Text.Json;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;

namespace BusinessLogic.Logic
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IDatabase _database;

        public ShoppingCartRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteShoppingCartAsync(string shoppingCartId)
        {
            return await _database.KeyDeleteAsync(shoppingCartId);
        }

        public async Task<ShoppingCart?> GetShoppingCartAsync(string shoppingCartId)
        {
            var item = await _database.StringGetAsync(shoppingCartId);

            return item.IsNullOrEmpty ? null : JsonSerializer.Deserialize<ShoppingCart>(item);
        }

        public async Task<ShoppingCart?> UpdateShoppingCartAsync(ShoppingCart shoppingCart)
        {
            var status = await _database.StringSetAsync(shoppingCart.Id, JsonSerializer.Serialize(shoppingCart), TimeSpan.FromDays(30));

            if (!status) return null;

            return await GetShoppingCartAsync(shoppingCart.Id);
        }
    }
}