
using Microsoft.Extensions.Logging;

namespace WebApplication3.Experiments
{
    public interface IDiMultiImpl
    {
        void Foo();
    }

    public class DiMultiImpl1 : IDiMultiImpl
    {
        ILogger _logger;

        public DiMultiImpl1(ILogger<DiMultiImpl1> logger)
        {
            _logger = logger;
        }

        public void Foo()
        {
            _logger.LogInformation("impl1 Foo() called");
        }
    }

    public class DiMultiImpl2 : IDiMultiImpl
    {
        ILogger _logger;

        public DiMultiImpl2(ILogger<DiMultiImpl2> logger)
        {
            _logger = logger;
        }

        public void Foo()
        {
            _logger.LogInformation("impl2 Foo() called");
        }
    }
}