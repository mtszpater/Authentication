using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Registering;


namespace WWW.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index ()
		{
			var mvcName = typeof(Controller).Assembly.GetName ();
			var isMono = Type.GetType ("Mono.Runtime") != null;

			ViewData ["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			ViewData ["Runtime"] = isMono ? "Mono" : ".NET";


			Registering.User u = new Registering.User ();

			return View ();
		}

		public ActionResult Register ()
		{
			return View ();
		}


		public String Login ()
		{
			Login login = new Login ();
			User u = login.LoginInit (Request.Form ["username"], Request.Form ["password"]);

			return u.ToString ();
		}
	}
}

