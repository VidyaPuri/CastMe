using System.Threading.Tasks;
using ZenProject.Web.Models;

namespace ZenProject.Web.Data
{
    public partial class RestClient
    {
        /// <summary>
        /// Calls GetTalentList method in Talent Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task<T> GetTalentList<T>()
        {
            return GetData<T>(ApiUrl + "/Talent");
        }

        /// <summary>
        /// Calls GetTalentMember method in Talent Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T> GetTalentMember<T>(string id)
        {
            return GetData<T>(ApiUrl + $"/Talent/{id}");
        }

        /// <summary>
        /// Calls PostTalentMember method in Talent Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="project"></param>
        /// <returns></returns>
        public Task<T> PostTalentMember<T>(Talent talentMember)
        {
            return PostData<T>(ApiUrl + "/Talent", bodyData: talentMember);
        }

        /// <summary>
        /// Calls PutTalentMember method in Talent Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        public Task<T> PutTalentMember<T>(string id, Talent talentMember)
        {
            return PutData<T>(ApiUrl + $"/Talent/{id}", bodyData: talentMember);
        }

        /// <summary>
        /// Calls DeleteTalentMember in Talent Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T> DeleteTalentMember<T>(string id)
        {
            return DeleteData<T>(ApiUrl + $"/Talent/{id}");
        }
    }
}
