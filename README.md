**3. Semester Projektopgave - BeboerWeb hjemmeside**\
Teamet: Rasmus Bisgaard, Sune Holmberg og Mikkel Pedersen
\
**Projektbeskrivelse:**
Gruppeprojekt med fokus på at udvikle en webapplikation der kunne tage hånd om forskellige problemstillinger for beboere og boligadministratorer. Projektet udfoldede sig derfor i en form for BeboerWeb platform. Vi afviklede projektet som et Scrum-projekt og vi benyttede Azure DevOps som projektstyringsværktøj.
\
**Struktur og teknologier:**
Vi udviklede en ASP.NET MVC frontend som snakkede sammen med en RESTful API backend via HTTP requests. Vi udarbejdede 
Front-End: HTML (CSHTML), CSS, Bootstrap
Back-End: Microsoft SQL-database, Code-First Entity Framework, LINQ, Restful API
\
**Få en kørbar udgave af programmet med InMemory database via Docker:**
1. Download docker-compose.yml: https://github.com/Builder45/TredjeSemesterProjekt/blob/main/BeboerWeb/docker-compose.yml
2. Åbn CMD og navigér til samme mappe som compose filen
3. Skriv  *docker-compose pull && docker-compose up*  for at hente vores program ned.
4. Hvis det kører, kan det tilgås på http://localhost:5001

**Seedede logins til Docker programmet:**\
\
badmin@beboerweb.dk\
badmin\
lejeren@beboerweb.dk\
lejeren\
bruger@beboerweb.dk\
bruger\
vicevt@beboerweb.dk\
vicevt
