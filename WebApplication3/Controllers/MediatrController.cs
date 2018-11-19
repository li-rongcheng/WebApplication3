using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.MediatrExperiment;

namespace WebApplication3.controllers
{
    public class MediatrController : Controller
    {
        IMediator _mediator; 
        public MediatrController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            //await _mediator.Publish(new Ping2());
            var result = await _mediator.Send(new Ping());
            return View(model: result);
        }
    }
}