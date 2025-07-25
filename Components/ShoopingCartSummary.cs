﻿using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Components
{
    public class ShoopingCartSummary :ViewComponent
    {
        private readonly IShoppingCart _shoppingCart;
        public ShoopingCartSummary(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        public IViewComponentResult Invoke()
        {
            var items = new List<ShoppingCartItem>() { new ShoppingCartItem(), new ShoppingCartItem() };

            //var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }
    }

}
