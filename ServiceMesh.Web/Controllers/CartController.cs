﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using ServiceMesh.Services.Web.Models.DTO;
using ServiceMesh.Web.Models;
using ServiceMesh.Web.Service.IService;

namespace ServiceMesh.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public CartController(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;
        }

        [Authorize]
        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }

        [HttpPost]
        [ActionName("Checkout")]
        public async Task<IActionResult> Checkout(CartDto cartDto)
        {
            CartDto cart = await LoadCartDtoBasedOnLoggedInUser();
            cart.CartHeader.Phone = cartDto.CartHeader.Phone;
            cart.CartHeader.Name = cartDto.CartHeader.Name;
            cart.CartHeader.Email = cartDto.CartHeader.Email;

            var response = await _orderService.CreateOrder(cart);
            OrderHeaderDto orderHeaderDto = JsonConvert.DeserializeObject<OrderHeaderDto>(Convert.ToString(response.Result));

            if(response != null && response.IsSuccess)
            {
                //get striped session and redirect to stripe
            }
            return View();
        }

        public async Task<IActionResult> Remove(int cartDetailsId)
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            ResponseDto? response = await _cartService.RemoveFromCartAsync(cartDetailsId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Cart Updated Successfully";
                return RedirectToAction(nameof(CartIndex));
            }
            //return RedirectToAction(nameof(CartIndex));
            return View();
        }

        private async Task<CartDto> LoadCartDtoBasedOnLoggedInUser()
        {
            var userId = User.Claims.Where(u=> u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            ResponseDto? response = await _cartService.GetCartByUserIdAsync(userId);
            if(response!= null && response.IsSuccess)
            {
                CartDto cartDto = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(response.Result));
                return cartDto;
            }
            return new CartDto();
        }

        [HttpPost]
        public async Task<IActionResult> ApplyCoupon(CartDto cartDto)
        {
            ResponseDto? response = await _cartService.ApplyCouponAsync(cartDto);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Coupon Applied!";
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmailCart(CartDto cartDto)
        {
            CartDto cart = await LoadCartDtoBasedOnLoggedInUser();
            cart.CartHeader.Email = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Email)?.FirstOrDefault()?.Value;
            ResponseDto? response = await _cartService.EmailCart(cart);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Email will be sent shortly!";
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCoupon(CartDto cartDto)
        {
            cartDto.CartHeader.CouponCode = "";
            ResponseDto response = await _cartService.ApplyCouponAsync(cartDto);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Coupon Applied!";
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }
    }
}
