using Presentation.Web.Models;

namespace Presentation.Web.Services
{
    public interface IPythonCaller
    {
        void callPython(string pathToPython, PresentationFile presentation);
    }
}