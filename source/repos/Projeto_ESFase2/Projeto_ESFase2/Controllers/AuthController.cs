using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_ESFase2.Data;

using Projeto_ESFase2.Models;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Session;
using Projeto_ESFase2.Services;

namespace Projeto_ESFase2.Controllers
{
    public class AuthController : Controller
    {
        private readonly ES2Context _context;
        private readonly UserServices _userServices;



        public AuthController(ES2Context context, UserServices userServices)
        {
            _context = context;
            _userServices = userServices;



        }
        
        public void Update(IObservable observable)
        {
            if (observable == null)
            {
                Console.WriteLine("There are no competitions to be observed");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(IFormCollection user)
        {
            List<User> users = new List<User>();
            var iterateUsers = await _context.Users.ToListAsync();


            foreach (var item in iterateUsers)
            {
                if (item.Email == user["Email"] && item.Password == Encrypt(user["Password"]))
                {
                    
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                    UsersServices.setUserInfo(item.Id, item.Name, item.Email, item.IsAdmin);
                    return RedirectToAction("Index", "Competition");
                }
            }
            ViewData["Error"] = "Os dados introduzidos não estão corretos. Tente novamente.";
            return View();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View(_context.Users.ToList());
        }
        public IActionResult Register()
        {
            return View();
        }


        // POST: /Auth/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] User user)
        {
            //Change to implement iterator
            var iterateUsers = await _context.Users.ToListAsync();

            if (ModelState.IsValid)
            {
                foreach (var item in iterateUsers) 
                { 
                    if (user.Email == item.Email || user.Name == item.Name)
                    {
                        ViewData["Error"] = "Ja existe este utilizador";
                        return View();
                    }
                }
                
                user.Password = Encrypt(user.Password);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["Error"] = "Algo correu errado";
            return View();
        }

        public async Task<IActionResult> Logout()
        {

            UsersServices.resetLocalData();


            return Redirect("/");
        }

        private static string Encrypt(string clearText)
        {
            string encryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
         //It is not necessary to decrypt the password.
         //This funtion would only be necessary if the program would implement a 
         //retrieve password or a I forgot my password which we will not be implementing
        private static string Decrypt(string cipherText)
        {
            string encryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
