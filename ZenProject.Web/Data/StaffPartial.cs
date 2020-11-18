using System.Threading.Tasks;
using ZenProject.Web.Models;

namespace ZenProject.Web.Data
{
    public partial class RestClient
    {
        /// <summary>
        /// Calls GetStaffList method in Staff Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task<T> GetStaffList<T>()
        {
            return GetData<T>(ApiUrl + "/Staff");
        }

        /// <summary>
        /// Calls GetStaffMember method in Staff Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T> GetStaffMember<T>(string id)
        {
            return GetData<T>(ApiUrl + $"/Staff/{id}");
        }

        /// <summary>
        /// Calls PostStaffMember method in Staff Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="project"></param>
        /// <returns></returns>
        public Task<T> PostStaffMember<T>(Staff staffMember)
        {
            return PostData<T>(ApiUrl + "/Staff", bodyData: staffMember);
        }

        /// <summary>
        /// Calls PutStaffMember method in Staff Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        public Task<T> PutStaffMember<T>(string id, Staff staffMember)
        {
            return PutData<T>(ApiUrl + $"/Staff/{id}", bodyData: staffMember);
        }

        /// <summary>
        /// Calls DeleteStaffMember in Staff Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T> DeleteStaffMember<T>(string id)
        {
            return DeleteData<T>(ApiUrl + $"/Staff/{id}");
        }
    }
}
