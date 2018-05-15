using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ngScaffolding.database.Models;
using ngScaffolding.database;

// following required for Async Methods
using Microsoft.AspNetCore.Authorization;
using ngScaffolding.Data;
using ngScaffolding.Services;

namespace ngScaffolding.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MenuItemsController : ngScaffoldingController
    {
        private readonly ngScaffoldingContext _context;
        private readonly IUserService _userService;
        private readonly IRepository<MenuItem> _menuItemRepository;

        public MenuItemsController(ngScaffoldingContext context, IUserService userService,
            IRepository<MenuItem> menuItemRepository)
        {
            _context = context;
            _userService = userService;
            _menuItemRepository = menuItemRepository;
        }

        private void AddMenuItem(ICollection<MenuItem> menuItems, MenuItem newMenuItem)
        {
            if (!newMenuItem.parentMenuItemId.HasValue)
            {
                menuItems.Add(newMenuItem);
                return;
            }
            foreach (var loopMenu in menuItems)
            {
                if (loopMenu.Id == newMenuItem.parentMenuItemId)
                {
                    loopMenu.Items.Add(newMenuItem);
                    return;
                }
                if (loopMenu.Items.Any())
                {
                    AddMenuItem(loopMenu.Items, newMenuItem);
                }
            }
        }

        // GET: api/MenuItems
        [HttpGet]
        public async Task<IEnumerable<MenuItem>> GetMenuItems()
        {
            var returnMenuItems = new List<MenuItem>();

            var menuItems = _menuItemRepository.GetAll().OrderBy(o => o.itemOrder);

            var user = await _userService.GetUser();

            foreach (var menuItem in menuItems)
            {
                if (string.IsNullOrEmpty(menuItem.Roles))
                {
                    AddMenuItem(returnMenuItems, menuItem);
                }
                else if(user.IsInRoles(menuItem.Roles))
                {
                    AddMenuItem(returnMenuItems, menuItem);
                }
            }

            return returnMenuItems;
        }

        // GET: api/MenuItems/5
        [HttpGet("{name}")]
        public async Task<IActionResult> GetMenuItem([FromRoute] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menuItem = await _context.MenuItems.SingleOrDefaultAsync(m => m.Name == name);

            if (menuItem == null)
            {
                return NotFound();
            }

            return Ok(menuItem);
        }

        // PUT: api/MenuItems/5
        [HttpPut("{name}")]
        public async Task<IActionResult> PutMenuItem([FromRoute] string name, [FromBody] MenuItem menuItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (name != menuItem.Name)
            {
                return BadRequest();
            }

            _context.Entry(menuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(name))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MenuItems
        [HttpPost]
        public async Task<IActionResult> PostMenuItem([FromBody] MenuItem menuItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuItem", new { id = menuItem.Id }, menuItem);
        }

        // DELETE: api/MenuItems/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteMenuItem([FromRoute] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menuItem = await _context.MenuItems.SingleOrDefaultAsync(m => m.Name == name);
            if (menuItem == null)
            {
                return NotFound();
            }

            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();

            return Ok(menuItem);
        }

        private bool MenuItemExists(string name)
        {
            return _context.MenuItems.Any(e => e.Name == name);
        }
    }
}