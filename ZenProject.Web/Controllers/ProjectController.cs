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
    public class ProjectController : Controller
    {
        // GET: Project
        public async Task<IActionResult> Index()
        {
            ProjectListViewModel projects = new ProjectListViewModel();

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync("https://localhost:44376/api/project");
                string apiResponse = await response.Content.ReadAsStringAsync();
                projects.ProjectList = JsonConvert.DeserializeObject<List<Project>>(apiResponse);
            }

            return View("List", projects);
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Project project;

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync($"https://localhost:44376/api/project/{id}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                project = JsonConvert.DeserializeObject<Project>(apiResponse);
            }
            if (project == null) return NotFound("Could not find this project");

            return View(project);
        }

        // GET: Project/Create
        public async Task<IActionResult> Create()
        {
            CreateProjectViewModel projectViewModel = new CreateProjectViewModel();

            TalentController ctrl = new TalentController(); // not good practice
            var response = await ctrl.Index();

            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var httpClient = new HttpClient())
                    {
                        string stringContent = JsonConvert.SerializeObject(project);

                        using var responseMessage = await httpClient.PostAsync("https://localhost:44376/api/project/", new StringContent(stringContent, Encoding.UTF8, "application/json"));
                        string apiResponse = await responseMessage.Content.ReadAsStringAsync();
                        var response = JsonConvert.DeserializeObject(apiResponse);
                        Console.WriteLine(response);
                    }
                    return RedirectToAction("Index");
                }

                return View(project);
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                Project project;

                using (var httpClient = new HttpClient())
                {
                    using var response = await httpClient.GetAsync($"https://localhost:44376/api/project/{id}");
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    project = JsonConvert.DeserializeObject<Project>(apiResponse);
                }
                if (project == null) return NotFound("Could not find this project!");

                return View(project);
            }
            catch
            {
                return View();
            }
        }

        // POST: Project/Edit/5
        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit(int? id, Project project)
        {
            try
            {
                if (id == null) return NotFound();

                using (var httpClient = new HttpClient())
                {
                    string stringContent = JsonConvert.SerializeObject(project);

                    using var responseMessage = await httpClient.PutAsync($"https://localhost:44376/api/project/{id}", new StringContent(stringContent, Encoding.UTF8, "application/json"));
                    string apiResponse = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject(apiResponse);
                    Console.WriteLine(response);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Project project;

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync($"https://localhost:44376/api/project/{id}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                project = JsonConvert.DeserializeObject<Project>(apiResponse);
            }
            if (project == null) return NotFound("Could not find this project!");

            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using var responseMessage = await httpClient.DeleteAsync($"https://localhost:44376/api/project/{id}");
                    string apiResponse = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject(apiResponse);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}