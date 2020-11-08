using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CastMe.Models;
using CastMe.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CastMe.Controllers
{
    public class TeamMemberController : Controller
    {

        public TeamMemberController()
        {
        }

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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTeamMember(TeamMember teamMember)
        {

            using(var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44376/api/teammember/");

                var request = new HttpRequestMessage(HttpMethod.Post, httpClient.BaseAddress);
                string stringContent = JsonConvert.SerializeObject(teamMember);

                using (var responseMessage = await httpClient.PostAsync("https://localhost:44376/api/teammember/", new StringContent(stringContent, Encoding.UTF8, "application/json")))
                {
                    string apiResponse = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject(apiResponse);
                    Console.WriteLine(response);
                }
            }
            

            return RedirectToAction("List");
        }
    }
}