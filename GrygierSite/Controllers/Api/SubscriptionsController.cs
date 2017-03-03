using GrygierSite.Core;
using GrygierSite.Core.Models;
using System;
using System.Web.Http;

namespace GrygierSite.Controllers.Api
{
    public class SubscriptionsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult AddSubscriber(Subscriber subscriber)
        {
            if (_unitOfWork.Subscribers.Contains(subscriber.Email))
                return Conflict();

            _unitOfWork.Subscribers.Add(subscriber);
            _unitOfWork.Complete();

            return Created(new Uri(Request.RequestUri + "/" + subscriber.Id), subscriber);
        }
    }
}
