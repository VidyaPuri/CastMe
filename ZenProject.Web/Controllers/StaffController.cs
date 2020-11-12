using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZenProject.Web.ViewModels;
using ZenProject.Web.Models;
using Microsoft.AspNetCore.Http;

namespace ZenProject.Controllers
{
    public class StaffController : Controller
    {
        public async Task<IActionResult> Index()
        {
            StaffListViewModel staffList = new StaffListViewModel();

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync("https://localhost:44376/api/staff");
                string apiResponse = await response.Content.ReadAsStringAsync();
                staffList.StaffMembers = JsonConvert.DeserializeObject<List<Staff>>(apiResponse);
            }

            return View("List", staffList);
        }

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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

        public async Task<IActionResult> Edit(int id)
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

        [HttpPost, ActionName("Edit")]
        public async Task<ActionResult<Staff>> Edit(int? id, Staff staffMember)
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

        [HttpPost]
        public async Task<ActionResult<Staff>> Delete(int id, IFormCollection collections)
        {
            try
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
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

        }

        //[HttpPost, ActionName("Edit")]
        //public async Task<ActionResult<Staff>> EditPost(int? id)
        //{
        //    if (id == null) return NotFound();

                
        //}
    }
}