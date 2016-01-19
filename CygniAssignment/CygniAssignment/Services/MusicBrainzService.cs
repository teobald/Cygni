using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Resources;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web;

namespace CygniAssignment.Services
{
    public class MusicBrainzService : IMusicBrainzService
    {
        public Response MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    Response jsonResponse
                    = objResponse as Response;
                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }

    [DataContract]
    public class Response
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        [DataMember(Name = "release-groups")]
        public ReleaseGroup[] ReleaseGroups { get; set; }
    }

    [DataContract]
    public class ReleaseGroup
    {
        [DataMember(Name = "primary-type")]
        public string PrimaryType { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "first-release-date")]
        public string FirstReleaseDate { get; set; }
    }
}