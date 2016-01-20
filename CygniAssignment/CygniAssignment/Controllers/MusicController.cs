using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CygniAssignment.Services;

namespace CygniAssignment.Controllers
{
    public class MusicController : ApiController
    {
        const string QueryString = "?fmt=json&inc=url-rels+release-groups";
        const string BaseUrl = "http://musicbrainz.org/ws/2/artist/";

        //GET api/music
        public string[] Get()
        {
            return new string[]
            {
             "Hello",
             "World"
            };
        }

        //GET api/music/5b11f4ce-a62d-471e-81fc-a69a8278c7da
        public string[] Get(string id)
        {
            var musicBrainzService = new MusicBrainzService();
            var response  = musicBrainzService.MakeRequest(BaseUrl + id + QueryString);
            return new string[] {"Artist: " + response.Name};
        }
    }
}
