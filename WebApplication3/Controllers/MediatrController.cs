using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Experiments;
using WebApplication3.MediatrExperiment;

namespace WebApplication3.controllers
{
    public class MediatrController : Controller
    {
        IMediator _mediator; 
        IEnumerable<IDiMultiImpl> _impls;
        public MediatrController(IMediator mediator, IEnumerable<IDiMultiImpl> impls)
        {
            _mediator = mediator;
            _impls = impls;
        }

        public async Task<IActionResult> Index()
        {
            //await _mediator.Publish(new Ping2());
            foreach(var impl in _impls)
                impl.Foo();

            var result = await _mediator.Send(new Ping());
            return View(model: result);
        }
    }
}