using System;
using System.Collections.Generic;
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
    public class TalentController : Controller
    {
        // GET: Talent
        public async Task<IActionResult> Index()
        {
            TalentListViewModel talentMembers = new TalentListViewModel();

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync("https://localhost:44376/api/talent");
                string apiResponse = await response.Content.ReadAsStringAsync();
                talentMembers.TalentList = JsonConvert.DeserializeObject<List<Talent>>(apiResponse);
            }

            return View("List",talentMembers);
        }

        // GET: Talent/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Talent talentMember;

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync($"https://localhost:44376/api/talent/{id}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                talentMember = JsonConvert.DeserializeObject<Talent>(apiResponse);
            }
            if (talentMember == null) return NotFound("Could not find this user!");

            return View(talentMember);
        }

        // GET: Talent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Talent/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Talent talentMember)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    string stringContent = JsonConvert.SerializeObject(talentMember);

                    using var responseMessage = await httpClient.PostAsync("https://localhost:44376/api/talent/", new StringContent(stringContent, Encoding.UTF8, "application/json"));
                    string apiResponse = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject(apiResponse);
                    Console.WriteLine(response);
                }
                return RedirectToAction("Index");
            }

            return View(talentMember);
        }

        // GET: Talent/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                Talent talentMember;

                using (var httpClient = new HttpClient())
                {
                    using var response = await httpClient.GetAsync($"https://localhost:44376/api/talent/{id}");
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    talentMember = JsonConvert.DeserializeObject<Talent>(apiResponse);
                }
                if (talentMember == null) return NotFound("Could not find this user!");

                return View(talentMember);
            }
            catch
            {
                return View();
            }
        }

        // POST: Talent/Edit/5
        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit(int? id, Talent talentMember)
        {
            if (id == null) return NotFound();

            using (var httpClient = new HttpClient())
            {
                string stringContent = JsonConvert.SerializeObject(talentMember);

                using var responseMessage = await httpClient.PutAsync($"https://localhost:44376/api/talent/{id}", new StringContent(stringContent, Encoding.UTF8, "application/json"));
                string apiResponse = await responseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject(apiResponse);
                Console.WriteLine(response);
            }
            return RedirectToAction("Index");
        }

        // GET: Talent/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Talent talentMember;

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync($"https://localhost:44376/api/talent/{id}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                talentMember = JsonConvert.DeserializeObject<Talent>(apiResponse);
            }
            if (talentMember == null) return NotFound("Could not find this user!");

            return View(talentMember);
        }

        // POST: Talent/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            using (var httpClient = new HttpClient())
            {
                using var responseMessage = await httpClient.DeleteAsync($"https://localhost:44376/api/talent/{id}");
                string apiResponse = await responseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject(apiResponse);
            }

            return RedirectToAction("Index");
        }
    }
}