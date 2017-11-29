using System.Web.Http;

namespace Bangazon.Controllers
{
    [Authorize]
    public class PrivateProductsController : ApiController
    {
        // POST api/values
    public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
