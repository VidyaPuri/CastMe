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
using ZenProject.Web.Data;

namespace ZenProject.Controllers
{
    public class StaffController : Controller
    {
        public async Task<IActionResult> Index()
        {
            StaffListViewModel staffList = new StaffListViewModel
            {
                StaffMembers = await RestClient.Instance.GetStaffList<List<Staff>>()
            };

            return View("List", staffList);
        }

        public async Task<IActionResult> Details(int id)
        {
            Staff staffMember = await RestClient.Instance.GetStaffMember<Staff>(id.ToString());
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
            try
            {
                if (ModelState.IsValid)
                {
                    Staff newStaffMember = await RestClient.Instance.PostStaffMember<Staff>(staffMember);
                    return RedirectToAction("Index");
                }

                return View(staffMember);
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                Staff staffMember = await RestClient.Instance.GetStaffMember<Staff>(id.ToString());
                if (staffMember == null) return NotFound("Could not find this user!");

                return View(staffMember);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost, ActionName("Edit")]
        public async Task<ActionResult<Staff>> Edit(int? id, Staff staffMember)
        {
            try
            {
                if (id == null) return NotFound();

                Staff updatedStaffMember = await RestClient.Instance.PutStaffMember<Staff>(id.ToString(), staffMember);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            Staff staffMember = await RestClient.Instance.GetStaffMember<Staff>(id.ToString());
            if (staffMember == null) return NotFound("Could not find this user!");

            return View(staffMember);
        }

        [HttpPost]
        public async Task<ActionResult<Staff>> Delete(int id, IFormCollection collections)
        {
            try
            {
                Staff staffMember = await RestClient.Instance.DeleteStaffMember<Staff>(id.ToString());
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

        }
    }
}