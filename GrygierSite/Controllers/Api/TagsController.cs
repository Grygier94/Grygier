using GrygierSite.Core;
using System;
using System.Linq;
using System.Web.Http;

namespace GrygierSite.Controllers.Api
{
    public class TagsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IHttpActionResult GetTags(string query = null)
        {
            var tags = String.IsNullOrWhiteSpace(query)
                ? _unitOfWork.Tags.GetTags()
                : _unitOfWork.Tags.GetTags().Where(t => t.Name.ToLower().Contains(query.ToLower()));

            return Ok(tags);
        }
    }
}
