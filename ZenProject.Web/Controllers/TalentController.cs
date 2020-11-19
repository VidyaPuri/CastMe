using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZenProject.Web.Data;
using ZenProject.Web.Models;
using ZenProject.Web.ViewModels;

namespace ZenProject.Web.Controllers
{
    public class TalentController : Controller
    {
        // GET: Talent
        public async Task<IActionResult> Index()
        {
            TalentListViewModel talentMembers = new TalentListViewModel
            {
                TalentList = await RestClient.Instance.GetTalentList<List<Talent>>()
            };

            return View("List",talentMembers);
        }

        // GET: Talent/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Talent talentMember = await RestClient.Instance.GetTalentMember<Talent>(id.ToString());
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
            try
            {
                if (ModelState.IsValid)
                {
                    Talent newTalent = await RestClient.Instance.PostTalentMember<Talent>(talentMember);
                    return RedirectToAction("Index");
                }

                return View(talentMember);
            }
            catch
            {
                return View();
            }
           
        }

        // GET: Talent/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                Talent talentMember = await RestClient.Instance.GetTalentMember<Talent>(id.ToString());
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
            try
            {
                if (id == null) return NotFound();

                var response = await RestClient.Instance.PutTalentMember<Talent>(id.ToString(), talentMember);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

        // GET: Talent/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Talent talentMember = await RestClient.Instance.GetTalentMember<Talent>(id.ToString());
            if (talentMember == null) return NotFound("Could not find this user!");

            return View(talentMember);
        }

        // POST: Talent/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var response = await RestClient.Instance.DeleteTalentMember<Talent>(id.ToString());
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}