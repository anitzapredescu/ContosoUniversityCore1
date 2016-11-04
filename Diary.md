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
web.config
- nu mai e mare lucru acolo, doar un handler de aspNetCore și un link la cum se
  configurează acum
appsettings.json
- are un connection string; dacă modifici cum se cheamă, trebuie modificat și în
  Startup.cs, unde zice:
    services.AddScoped(_ => new SchoolContext(
        Configuration["Data:DefaultConnection:ConnectionStringsss"]));
- zice ceva de logging, dar nu e clar unde & cum se loghează anume
    - în Startup.cs, se configurează să scrie la consolă; acolo ai zice dacă
      vrei altceva; vezi și https://docs.asp.net/en/latest/fundamentals/logging.html
Program.cs
- construiește un WebHostBuilder, zice să ruleze Kestrel în spatele IIS,
  părțile interesante par a fi în Startup.cs
Startup.cs:
- pare că lui Jimmy îi plac using-uri în namespace
- încarcă fișiere de configurare din diverse surse
- nu mi-e clară diferența dintre Configure() și ConfigureServices() și de ce e
  nevoie de amîndouă
- în Configure() se setează ruta default (dacă vrei altceva decît Home/Index)
ConfigureServices
- FeatureConvention: adaugă în controller.Properties o cheie `feature` după
  namespace, folosit la a găsi view-ul în același folder (în
  FeatureViewLocationExpander, vezi AddRazorOptions)
- DbContextTransactionFilter creează o tranzacție per request
- ValidatorActionFilter: întoarce eroare (BadRequest sau 400) dacă modelul nu e
  valid
- EntityModelBinder: trimiți id în request, încarcă entitatea din bază, de
  exemplu în lista de cursuri dacă selectezi un departament
- pe urmă adaugă Automapper, Mediatr, HtmlTags și DbContext per request
- nu e clar unde (& dacă) e configurat FluentValidator

# Ziua 4?
CourseController.cs
- Index.Query: are departamentul din care să afișez cursurile
- Details.Query: are id-ul cursului, dar nullable: de ce? La Student nu e nullable.
- Edit.QueryHandler întoarce Edit.Command
- la fel Delete.Query -> Delete.Command

TODO: de înțeles HtmlTags, TagConventions e.g.  EntitySelectElementBuilder care
populează un dropdown
