# Ziua 1

Baza de date
- găsit instanță localdb (sqllocaldb -?)
- creat baze de date ContosoUniversity & ContosoUniversity-Test
- rulat script sql în ambele
- modificat connection string în appsettings.json
- și în ambele proiecte de test, ca să poată rula
- nu se rebuilduiesc proiectele de test dacă modifici appsettings.json,
  așa că trebuie șters bin de mînă
global.json
- zice că avem test și src
F5
- rulat proiect, jucat prin el
Rulat teste
- trebuie adăugat un parametru la metoda din unit test, ca să se inițializeze
  Automapper

# Ziua 2

Cum deployez?
- eroare „No executable found matching command "dotnet-bundle"”: am făcut
  upgrade la BundlerMinifier.Core, l-am mutat din dependencies în tools
- eroare că nu există framework 1.1.0-preview etc. Pare că e din cauza
  upgrade-ului lui BundlerMinifier.Core, că nu am găsit nicăieri 1.1.0 explicit.
  Am instalat https://go.microsoft.com/fwlink/?LinkID=831469 și am trecut de
  asta.
- ceva e suspect la mine în IIS, nu apare Management Service nici după ce
  pornesc WMSvc. Mă dau bătut
