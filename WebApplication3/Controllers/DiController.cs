using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Experiments;

namespace WebApplication3.controllers
{
    public class DiController : Controller
    {
        readonly IEnumerable<IDiMultiImpl> _impls;
        public DiController(IEnumerable<IDiMultiImpl> impls)
        {
            _impls = impls;
        }

        public IActionResult Index()
        {
            //await _mediator.Publish(new Ping2());
            foreach(var impl in _impls)
                impl.Foo();

            throw new MyValidationException();
            //return View(model: "ok");
        }
    }
}