using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;

namespace CygniAssignment.Services
{
    [TestFixture]
    public class MusicBrainzServiceTests
    {
        [Test]
        public void Send_A_Request_To_MusicBrainz_And_Get_A_Response()
        {
            IMusicBrainzService musicBrainzService = new MusicBrainzService();
            var response = musicBrainzService.MakeRequest("http://musicbrainz.org/ws/2/artist/5b11f4ce-a62d-471e-81fc-a69a8278c7da?&fmt=json&inc=url-rels+release-groups");
            Assert.IsNotNull(response);
        }
    }
}