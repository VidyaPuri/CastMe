using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZenProject.Web.Data;
using ZenProject.Web.Models;
using ZenProject.Web.ViewModels;

namespace ZenProject.Web.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public async Task<IActionResult> Index()
        {
            ProjectListViewModel projects = new ProjectListViewModel
            {
                ProjectList = await RestClient.Instance.GetAllProjects<List<Project>>()
            };

            return View("List", projects);
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Project project = await RestClient.Instance.GetProject<Project>(id.ToString());
            if (project == null) return NotFound("Could not find this project");

            return View(project);
        }

        // GET: Project/Create
        public async Task<IActionResult> Create()
        {
            CreateProjectViewModel projectViewModel = new CreateProjectViewModel
            {
                StaffMembers = await RestClient.Instance.GetStaffList<List<Staff>>()
            };


            return View(projectViewModel);
        }

        // POST: Project/Create
        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Project newProject = await RestClient.Instance.PostProject<Project>(project);
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
                Project project = await RestClient.Instance.GetProject<Project>(id.ToString());
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

                var response = await RestClient.Instance.PutProject<Project>(id.ToString(), project);
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
            Project project = await RestClient.Instance.GetProject<Project>(id.ToString());
            if (project == null) return NotFound("Could not find this project!");

            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var response =  await RestClient.Instance.DeleteProject<Project>(id.ToString());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}