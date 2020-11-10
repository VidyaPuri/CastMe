using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZenProject.Web.Models;
using ZenProject.Web.ViewModels;

namespace ZenProject.Web.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public async Task<IActionResult> Index()
        {
            StaffListViewModel staffMembers = new StaffListViewModel();

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync("https://localhost:44376/api/staff");
                string apiResponse = await response.Content.ReadAsStringAsync();
                staffMembers.StaffList = JsonConvert.DeserializeObject<List<Staff>>(apiResponse);
            }

            return View("List",staffMembers);
        }

        // GET: Staff/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Staff staffMember;

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync($"https://localhost:44376/api/staff/{id}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                staffMember = JsonConvert.DeserializeObject<Staff>(apiResponse);
            }
            if (staffMember == null) return NotFound("Could not find this user!");

            return View(staffMember);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Staff staffMember)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    string stringContent = JsonConvert.SerializeObject(staffMember);

                    using var responseMessage = await httpClient.PostAsync("https://localhost:44376/api/staff/", new StringContent(stringContent, Encoding.UTF8, "application/json"));
                    string apiResponse = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject(apiResponse);
                    Console.WriteLine(response);
                }
                return RedirectToAction("Index");
            }

            return View(staffMember);
        }

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                Staff staffMember;

                using (var httpClient = new HttpClient())
                {
                    using var response = await httpClient.GetAsync($"https://localhost:44376/api/staff/{id}");
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    staffMember = JsonConvert.DeserializeObject<Staff>(apiResponse);
                }
                if (staffMember == null) return NotFound("Could not find this user!");

                return View(staffMember);
            }
            catch
            {
                return View();
            }
        }

        // POST: Staff/Edit/5
        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit(int? id, Staff staffMember)
        {
            if (id == null) return NotFound();

            using (var httpClient = new HttpClient())
            {
                string stringContent = JsonConvert.SerializeObject(staffMember);

                using var responseMessage = await httpClient.PutAsync($"https://localhost:44376/api/staff/{id}", new StringContent(stringContent, Encoding.UTF8, "application/json"));
                string apiResponse = await responseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject(apiResponse);
                Console.WriteLine(response);
            }
            return RedirectToAction("Index");
        }

        // GET: Staff/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Staff staffMember;

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync($"https://localhost:44376/api/staff/{id}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                staffMember = JsonConvert.DeserializeObject<Staff>(apiResponse);
            }
            if (staffMember == null) return NotFound("Could not find this user!");

            return View(staffMember);
        }

        // POST: Staff/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            using (var httpClient = new HttpClient())
            {
                using var responseMessage = await httpClient.DeleteAsync($"https://localhost:44376/api/staff/{id}");
                string apiResponse = await responseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject(apiResponse);
                Console.WriteLine(response);
            }
            return RedirectToAction("Index");
        }
    }
}