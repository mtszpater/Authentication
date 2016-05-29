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

		static User u;

		public ActionResult Index ()
		{

			ViewData ["info"]  = (string)(Session ["info"]);

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

			if (u.returnIsLogged ()) {
				Session ["isLogged"] = "true";
				Session ["info"] = "Jestes zalogowany";
				Response.Redirect ("Panel");
			} else {
				Session ["info"] = "Logowanie nie udało sie";
			}
			
			Response.Redirect ("~");
		}

		public void Logout()
		{
			Logout logout = new Logout ();
			u = logout.LogoutInit (u);

			Session ["info"] = "Jestes wylogowany";

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


		public ActionResult Panel()
		{

			ViewData ["login"] = u.returnValueOfField (u.returnUserLogin ());
			ViewData ["pass"] = u.returnValueOfField (u.returnUserPass ());
			ViewData ["id"] = u.returnUserId ().ToString();
			ViewData ["perm"] = u.returnUserPermId ().ToString();
			ViewData ["info"]  = (string)(Session ["info"]);

			return View ();

		}

		public void Update ()
		{

			Session ["info"] = " ";

			if (Request.Form ["username"].CompareTo (u.returnValueOfField (u.returnUserLogin ())) != 0) {
				
				if (u.setValueOfField (u.returnUserLogin (), Request.Form ["username"])) {
					Session ["info"] = "Nazwa użytkownika zostala zmieniona\n";
				} else {
					Session ["info"] = "Nie udało się zmienić nazwy użytkownika. Może jest zajęta?\n";
				}
			}


			PasswordHasher hasher = new PasswordHasher ();

			if (Request.Form ["password"].Length > 0) {
				if (!hasher.comparePassword (Request.Form ["password"], u.returnValueOfField (u.returnUserPass ()))) {
					if (u.setValueOfField (u.returnUserPass (), Request.Form ["password"])) {
						Session ["info"] = Session ["info"] + "Haslo zostalo zmienione";
					} else {
						Session ["info"] = Session ["info"] + "Nie zmieniłem hasla, bo nie przeszło weryfikacji :< ";
					}
				}
			}

			Response.Redirect ("Panel");

		}


	}
}

