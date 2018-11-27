using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Configuration;
using System.Dynamic;
using theMovieDB.Models;


namespace theMovieDB.Controllers
{
    public class MovieController : Controller
    {
        string endpoint = ConfigurationManager.AppSettings["EndPoint"].ToString();
        string userkey = ConfigurationManager.AppSettings["UserKey"].ToString();
        // GET: Movie
        public ActionResult Details(string id)
        {
            string _url = endpoint+"movie/"+id+"?api_key="+userkey;
            var _client = new RestClient(_url);
            var _request = new RestRequest(Method.GET);
            IRestResponse _response = _client.Execute(_request);
            dynamic _myDetails = JsonConvert.DeserializeObject<dynamic>(_response.Content);

            ViewBag.Cast = getCast(id);

            return View("Details", _myDetails);

        }

        public List<dynamic> getCast(string id)
        {
            List<dynamic> _lstCast = new List<dynamic>();

            string _url = endpoint + "movie/" + id + "/credits?api_key=" + userkey;

            var _client = new RestClient(_url);
            var _request = new RestRequest(Method.GET);
            IRestResponse _response = _client.Execute(_request);
            dynamic _myCast = JsonConvert.DeserializeObject<dynamic>(_response.Content);



            foreach (var db in _myCast.cast)
            {
                Cast _cast = new Cast();
                _cast.name = db["name"].ToString();
                _cast.character = db["character"].ToString();
                _lstCast.Add(_cast);
            }

            return _lstCast;
        }
    }
}