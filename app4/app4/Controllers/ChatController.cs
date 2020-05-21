using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app4.Models;
using app4.Models.ApplicationContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace app4.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        readonly ApplicationContext _context;
        readonly UserManager<User> _userManager;
        public ChatController(ApplicationContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUserName = currentUser.UserName;
            var messages = await _context.Messages.ToListAsync(); 
            
            return View(messages);
        }
        public async Task<IActionResult> Create(Message message)
        {
            if(ModelState.IsValid)
            {
                var sender = await _userManager.GetUserAsync(User);
                message.UserId = sender.Id;
                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return View("Error");
        }
    }
}