using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using RestSharp;
using System.Configuration;



namespace theMovieDB.Controllers
{
    public class HomeController : Controller
    {
        string endpoint = ConfigurationManager.AppSettings["EndPoint"].ToString();
        string userkey = ConfigurationManager.AppSettings["UserKey"].ToString();

        public ActionResult Index()
        {


          

            string _url = endpoint + "movie/popular?api_key=" + userkey;

            var _client = new RestClient(_url);
            var _request = new RestRequest(Method.GET);
            IRestResponse _response = _client.Execute(_request);
            dynamic _myDB = JsonConvert.DeserializeObject<dynamic>(_response.Content);
            ViewBag.ResultOk = true;
            return View("index", _myDB);
        }

        public ActionResult Search(string txtSearch)
        {



            string _url = endpoint+ "search/movie?api_key=" + userkey +"&query="+txtSearch+"&sort_by = title.asce";

            var _client = new RestClient(_url);
            var _request = new RestRequest(Method.GET);
            IRestResponse _response = _client.Execute(_request);
            dynamic _myDB = JsonConvert.DeserializeObject<dynamic>(_response.Content);

            ViewBag.ResultOk = false;
            if(_response.Content.ToString().Contains("errors")==false)
            {
                ViewBag.ResultOk = true;
            }



            return View("index",_myDB);
        }


        
        public ActionResult About()
        {

            return View();
        }

    }
}