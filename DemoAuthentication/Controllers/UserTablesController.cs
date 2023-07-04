using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoAuthentication.Entities;
//Password Hashing
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Text;
using DemoAuthentication.Services;

namespace DemoAuthentication.Controllers
{
    public class UserTablesController : Controller
    {
        private readonly MyDatabaseContext _context;
        private readonly UserTableServices userTableServices;

        public UserTablesController()
        {
            _context = new MyDatabaseContext();
            userTableServices = new UserTableServices();
        }

        // GET: UserTables
        public async Task<IActionResult> Index()
        {
            var users = _context.UserTables.Select(u => new UserTableViewModel { Id = u.Id, Name = u.Name, Email = u.Email }).ToList();
            return View(users);
        }

        public IActionResult LoginHashCheck()
        {
            return View();
        }

        public IActionResult CheckHashPassword(LoginViewModel loginViewModel)
        {
            if(userTableServices.ValidateUserCredentials(loginViewModel.Id,loginViewModel.Password))
            {
                ViewBag.HashPasswordString = "Password Matched";
               
            }
            else
            {
                ViewBag.HashPasswordString = "Password Mis Matched";

            }
            return View();

        }
        public byte[] GetHashPassword(string password)
        {
            // Hash the password with the salt
            string hashedPasswordString = BCryptNet.HashPassword(password);
            byte[] hashedPasswordBytes = Encoding.UTF8.GetBytes(hashedPasswordString);
            return hashedPasswordBytes;
        }


        // GET: UserTables/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTable = await _context.UserTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTable == null)
            {
                return NotFound();
            }

            return View(userTable);
        }

        // GET: UserTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password")] UserTableHashPassword userTable)
        {
            if (ModelState.IsValid)
            {
                userTableServices.RegisterUser(userTable);
                return RedirectToAction(nameof(Index));
            }
            return View(userTable);


        }

        // GET: UserTables/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTable = await _context.UserTables.FindAsync(id);
            if (userTable == null)
            {
                return NotFound();
            }
            return View(userTable);
        }

        // POST: UserTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Email,Password")] UserTable userTable)
        {
            if (id != userTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTable);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTableExists(userTable.Id))
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
            return View(userTable);
        }

        // GET: UserTables/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTable = await _context.UserTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTable == null)
            {
                return NotFound();
            }

            return View(userTable);
        }

        // POST: UserTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userTable = await _context.UserTables.FindAsync(id);
            _context.UserTables.Remove(userTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTableExists(string id)
        {
            return _context.UserTables.Any(e => e.Id == id);
        }

        private byte[] HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hashedPassword = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);

            // Combine the salt and hashed password
            byte[] combinedHash = new byte[salt.Length + hashedPassword.Length];
            Array.Copy(salt, 0, combinedHash, 0, salt.Length);
            Array.Copy(hashedPassword, 0, combinedHash, salt.Length, hashedPassword.Length);

            return combinedHash;
        }

    }
}
