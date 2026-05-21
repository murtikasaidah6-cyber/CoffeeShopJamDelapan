using System;
using System.Collections.Generic;
using CoffeeShopJamDelapan.Models;

namespace CoffeeShopJamDelapan.Services
{
    public class CartService
    {
        public static CartService Instance { get; } = new CartService();
        public event EventHandler? CartChanged;
        private readonly List<CartItem> _items = new();
        public IReadOnlyList<CartItem> Items => _items.AsReadOnly();

        public void Add(CartItem item)
        {
            var existing = _items.Find(i => i.RecipeId == item.RecipeId);
            if (existing != null)
            {
                existing.Qty += item.Qty;
            }
            else
            {
                _items.Add(item);
            }
            CartChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveByRecipeId(int recipeId)
        {
            var existing = _items.Find(i => i.RecipeId == recipeId);
            if (existing != null) _items.Remove(existing);
            CartChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Clear()
        {
            _items.Clear();
            CartChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
