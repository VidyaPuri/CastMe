﻿using System.Threading.Tasks;
using ZenProject.Web.Models;

namespace ZenProject.Web.Data
{
    public partial class RestClient
    {
        /// <summary>
        /// Calls GetProjects method in Project Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task<T> GetAllProjects<T>()
        {
            return GetData<T>(ApiUrl + "/Project");
        }

        /// <summary>
        /// Calls GetProject method in Project Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T> GetProject<T>(string id)
        {
            return GetData<T>(ApiUrl + $"/Project/{id}");
        }

        /// <summary>
        /// Calls PostProject method in Project Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="project"></param>
        /// <returns></returns>
        public Task<T> PostProject<T>(Project project)
        {
            return PostData<T>(ApiUrl + "/Project", bodyData: project);
        }

        /// <summary>
        /// Calls PutProject method in Project Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        public Task<T> PutProject<T>(string id, Project project)
        {
            return PutData<T>(ApiUrl + $"/Project/{id}", bodyData: project);
        }

        /// <summary>
        /// Calls DeleteProject in Project Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T> DeleteProject<T>(string id)
        {
            return DeleteData<T>(ApiUrl + $"/Project/{id}");
        }
    }
}
