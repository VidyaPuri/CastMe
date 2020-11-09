﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZenProject.Models;
using ZenProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ZenProject.Controllers
{
    public class TeamMemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            TeamMemberListViewModel teamMembers = new TeamMemberListViewModel();
            //teamMembers.TeamMembers = _teamMemberData.GetAll();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44376/api/teammember"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    teamMembers.TeamMembers = JsonConvert.DeserializeObject<List<TeamMember>>(apiResponse);
                }
            }

            return View(teamMembers);
        }

        public async Task<IActionResult> Details(int id)
        {
            TeamMember teamMember;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:44376/api/teammember/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    teamMember = JsonConvert.DeserializeObject<TeamMember>(apiResponse);
                }
            }
            if (teamMember == null) return NotFound("Could not find this user!");

            return View(teamMember);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            TeamMember teamMember;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:44376/api/teammember/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    teamMember = JsonConvert.DeserializeObject<TeamMember>(apiResponse);
                }
            }
            if (teamMember == null) return NotFound("Could not find this user!");

            return View(teamMember);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    string stringContent = JsonConvert.SerializeObject(teamMember);

                    using var responseMessage = await httpClient.PostAsync("https://localhost:44376/api/teammember/", new StringContent(stringContent, Encoding.UTF8, "application/json"));
                    string apiResponse = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject(apiResponse);
                    Console.WriteLine(response);
                }
                return RedirectToAction("List");
            }

            return View(teamMember);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<ActionResult<TeamMember>> Edit(int? id, TeamMember teamMember)
        {
            if (id == null) return NotFound();

            using (var httpClient = new HttpClient())
            {
                string stringContent = JsonConvert.SerializeObject(teamMember);

                using var responseMessage = await httpClient.PutAsync($"https://localhost:44376/api/teammember/{id}", new StringContent(stringContent, Encoding.UTF8, "application/json"));
                string apiResponse = await responseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject(apiResponse);
                Console.WriteLine(response);
            }
            return RedirectToAction("List");
        }


        public async Task<ActionResult<TeamMember>> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using var responseMessage = await httpClient.DeleteAsync($"https://localhost:44376/api/teammember/{id}");
                string apiResponse = await responseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject(apiResponse);
                Console.WriteLine(response);
            }
            return RedirectToAction("List");
        }

        //[HttpPost, ActionName("Edit")]
        //public async Task<ActionResult<TeamMember>> EditPost(int? id)
        //{
        //    if (id == null) return NotFound();

                
        //}
    }
}