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

		User u;

		public ActionResult Index ()
		{
			Console.WriteLine (" X" + (string)(Session ["isLogged"]));

			ViewBag ["info"] = (string)(Session ["info"]);
			return View ();
		}

		public ActionResult Register ()
		{
			return View ();
		}


		public void Login ()
		{
			Login login = new Login ();
			u = login.LoginInit (Request.Form ["username"], Request.Form ["password"]);

			if (u.returnIsLogged ())
			{
				Session ["isLogged"] = "true";
				Session ["info"] = "Jestes zalogowany";
			}
	
			Console.WriteLine (" Z" + (string)(Session ["isLogged"]));
			
			Response.Redirect ("~");
		}

		public void RegisterSend ()
		{
			Register r = new Register (Request.Form ["username"], Request.Form ["password"]);
			if (r.RegisterInit ())
				Session ["info"] = "Zostałeś zarejestrowany";
			else
				Session ["info"] = "Sprawdz wpisane dane, moze login jest zajety?";
			
			Response.Redirect ("~");
		}

	}
}

