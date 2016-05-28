using System;
using System.Collections.Generic;
using System.IO;

namespace Registering
{
	class MainClass
	{


		public static void Main (string[] args)
		{
			/* Najlepiej wpisać dane uzytkownika, ktory na pewno nie będzie istniał, aby wszystkie kroki poniżej były poprawnie zinterpretowane :) */

			string userName = "test152";
			string userName2 = "test162"; // Login na który zostanie zmieniony
			string userPass = "haslotest";
			string userPass2 = "haslotest2"; // Nowe haslo na ktore zostanie zmienione


			/* TESTUJEMY REJESTRACJĘ */

			Register register = new Register (userName, userPass);

			if (register.RegisterInit ())
				Console.WriteLine ("[1] OK!!");
			else
				Console.WriteLine ("[1] Nie udalo sie, nie przeszlo weryfikacji");


			/* TERAZ PRZETESTUJEMY REJESTRACJE GDY LOGIN JEST ZAJETY */
			register = new Register (userName, userPass);

			if (register.RegisterInit ())
				Console.WriteLine ("[2] OK!!");
			else
				Console.WriteLine ("[2] Nie udalo sie, nie przeszlo weryfikacji (i dobrze, bo nie powinno)");


			/* SPRAWDZIMY TERAZ CO WYSWIETLI DLA NIEZALOGOWANEGO UZYTKOWNIKA */

			Console.WriteLine ("\n\n[3] PRZYKLAD NIEZALOGOWANEGO UŻYTKOWNIKA");
			User u = new User ();
			Console.WriteLine ("[3] " + u);

			/* ZALOGUJMY TERAZ TEGO UŻYTKOWNIKA */
			Login login = new Login ();
			Console.WriteLine ("\n\n[4] PRZYKLAD ZALOGOWANEGO UŻYTKOWNIKA ");
			u = login.LoginInit (userName, userPass);
			Console.WriteLine ("[4] " + u);
			Console.WriteLine ("[4] Aktualne " + u.returnNameOfField( u . returnUserLogin () ) + " = " + u.returnValueOfField ( u.returnUserLogin() ) );
			Console.WriteLine ("[4] Aktualne " + u.returnNameOfField( u . returnUserPass () ) + " = " + u.returnValueOfField ( u.returnUserPass() ) );


			/* SPRÓBUJEMY ZMIENIĆ NAZWĘ UŻYTKOWNIKA */
			if (u.setValueOfField (u.returnUserLogin (), userName2)) {
				Console.WriteLine ("\n\n[5] UDAŁO SIĘ ZMIENIĆ LOGIN, WYPISZMY DANE:");
				Console.WriteLine ("[5] Aktualne " + u.returnNameOfField (u.returnUserLogin ()) + " = " + u.returnValueOfField (u.returnUserLogin ()));
			} else {
				Console.WriteLine ("\n\n[5] Cos sie nie udalo zmienic loginu, moze jest zajety, albo za krotki?");
			}

			/* SPRÓBUJEMY ZMIENIĆ HASLO UŻYTKOWNIKA */
			if (u.setValueOfField (u.returnUserPass (), userPass2)) {
				Console.WriteLine ("\n\n[6] UDAŁO SIĘ ZMIENIĆ HASŁO, WYPISZMY DANE:");
				Console.WriteLine ("[6] Aktualne " + u.returnNameOfField (u.returnUserPass ()) + " = " + u.returnValueOfField (u.returnUserPass ()));
			} else {
				Console.WriteLine ("\n\n[6] Cos sie nie udalo zmienic loginu, moze jest zajety, albo za krotki?");
			}

			/* WYLOGUJMY GO I SPRAWDZMY PONOWNIE */
			Logout Logout = new Logout ();
			Console.WriteLine ("\n\n[7] PRZYKŁAD WYLOGOWANEGO UŻYTKOWNIKA ");
			u = Logout.LogoutInit (u);
			Console.WriteLine ("[7] " + u);

		}
	}
}
