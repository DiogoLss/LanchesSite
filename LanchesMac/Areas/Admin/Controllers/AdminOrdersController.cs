﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LanchesMac.Context;
using LanchesMac.Models;
using Microsoft.AspNetCore.Authorization;
using ReflectionIT.Mvc.Paging;
using LanchesMac.ViewModels;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminOrdersController : Controller
    {
        private readonly AppDbContext _context;

        public AdminOrdersController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult OrderSnacks(int? id)
        {
            var order = _context.Orders
                .Include(od => od.OrderItems)
                .ThenInclude(s => s.Snack)
                .FirstOrDefault(p => p.OrderId == id);
            if(order == null)
            {
                Response.StatusCode = 404;
                return View("OrderNotFound",id.Value); 
            }
            OrderSnackViewModel orderSnacks = new OrderSnackViewModel()
            {
                Order = order,
                orderDetails = order.OrderItems
            };
            return View(orderSnacks);
        }

        // GET: Admin/AdminOrders
        //public async Task<IActionResult> Index()
        //{
        //      return View(await _context.Orders.ToListAsync());
        //}
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Name")
        {
            var result = _context.Orders.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                result = result.Where(p => p.Name.Contains(filter));
            }
            var model = await PagingList.CreateAsync(result, 5, pageindex, sort, "Name");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);
        }

        // GET: Admin/AdminOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Admin/AdminOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,Name,LastName,Address1,Address2,Cep,State,City,PhoneNumber,Email,OrderSent,OrderDelivered")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Admin/AdminOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Admin/AdminOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,Name,LastName,Address1,Address2,Cep,State,City,PhoneNumber,Email,OrderSent,OrderDelivered")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Admin/AdminOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Admin/AdminOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'AppDbContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
