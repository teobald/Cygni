using System.Net;

namespace CygniAssignment.Services
{
    public interface IMusicBrainzService
    {
        Response MakeRequest(string requestUrl);
    }
}