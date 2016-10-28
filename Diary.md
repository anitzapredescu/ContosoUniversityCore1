Baza de date
- găsit instanță localdb (sqllocaldb -?)
- creat baze de date ContosoUniversity & ContosoUniversity-Test
- rulat script sql în ambele
- modificat connection string în appsettings.json
- și în ambele proiecte de test, ca să poată rula
- nu se rebuilduiesc proeictele de test dacă modifici appsettings.json,
  așa că trebuie șters bin de mînă
global.json
- zice că avem test și src
F5
- rulat proiect, jucat prin el
Rulat teste
- trebuie adăugat un parametru la metoda din unit test, ca să se inițializeze
  Automapper