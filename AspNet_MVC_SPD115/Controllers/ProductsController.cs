﻿using AspNet_MVC_SPD115.Helpers;
using AspNet_MVC_SPD115.Models;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNet_MVC_SPD115.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly Shop115DbContext ctx;
        private readonly IFileService fileService;

        public ProductsController(Shop115DbContext ctx, IFileService fileService)
        {
            this.ctx = ctx;
            this.fileService = fileService;
        }

        private void LoadCategories()
        {
            this.ViewBag.Categories = new SelectList(ctx.Categories.ToList(), "Id", "Name");
        }

        // show all products
        [AllowAnonymous]
        public IActionResult Index()
        {
            // get products from db
            var products = ctx.Products.ToList();
            
            return View(products); // set view mode
        }

        // GET: show creation form
        [HttpGet]
        public IActionResult Create()
        {
            // Ways of sending data to View
            // 1 - using View(model)
            // 2 - using TemoData: this.TempData["key"] = value
            // 3 - using ViewBag: this.ViewBag.Property = value
            LoadCategories();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductModel model)
        {
            // validate model
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(model);
            }

            var product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Discount = model.Discount,
                CategoryId = model.CategoryId,
                InStock = model.InStock,
                Price = model.Price,
                ImageUrl = await fileService.SaveFileAsync(model.ImageFile)
            };

            // create product in db
            ctx.Products.Add(product);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: show edit product page
        public IActionResult Edit(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) return NotFound(); // 404

            LoadCategories();

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            // validate model
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(product);
            }

            // update product in db
            ctx.Products.Update(product);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        // delete product by ID
        public IActionResult Delete(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) return NotFound(); // 404

            ctx.Products.Remove(item);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
