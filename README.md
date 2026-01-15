# Personnummerkontroll - Konsolapplikation

Den här applikationen är en C#-konsolapplikation som verifierar svenska personnummer och kontrollerar att de är korrekta enligt svenska regler. Projektet finns också som Docker-container, vilket gör det enkelt att köra utan att installera .NET lokalt.

## Svenska regler för personnummer

Ett svenskt personnummer har formatet `YYYYMMDD-XXXX` eller `YYMMDD-XXXX` där:

- De första 6 (eller 8) siffrorna representerar födelsedatum.
- De 4 sista siffrorna är ett löpnummer där:
  - Den tredje siffran i löpnumret indikerar kön (ojämn = man, jämn = kvinna).
- Den sista siffran är en kontrollsiffra som beräknas med **Luhn-algoritmen**.

Applikationen kontrollerar:

1. Att datumet är giltigt (ex. inga 31:e februari).
2. Att längden och formatet är korrekt.
3. Att kontrollsiffran stämmer enligt Luhn-algoritmen.

---

## Köra applikationen lokalt

### Förutsättningar

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) installerat
- Terminal / Git Bash

### Steg

1. Klona repot:
   ```bash
   git clone https://github.com/chobacka/personnummer-checker.git
   cd personnummer-checker

    Bygg projektet:

    dotnet build

    Kör programmet:

    dotnet run --project ConsoleApp-CICD-gruppuppgift.csproj

    Ange ett personnummer när du uppmanas, t.ex.:

    Skriv in personnummer: 900101-2386

    Programmet kommer svara om personnumret är giltigt eller ogiltigt.

Köra applikationen med Docker
Förutsättningar

    Docker Desktop
    installerat

Steg

    Dra ner Docker-imagen från Docker Hub:

    docker pull chobacka/personnummer-checker:latest

    Kör containern:

    docker run -it chobacka/personnummer-checker:latest

    Ange personnummer när programmet frågar efter det. Programmet returnerar giltighet.

Enhetstester

Projektet använder xUnit för testning. För att köra tester lokalt:

dotnet test

Testerna kontrollerar olika delar av personnummerlogiken, inklusive datumvalidering

Det finns en GitHub Actions workflow som:

    Bygger projektet.

    Kör enhetstester.

    Bygger Docker-imagen.

    Puschar Docker-imagen till Docker Hub (om push sker på main-branchen).

För att detta ska fungera behöver GitHub Secrets sättas upp:

    DOCKER_USERNAME – Docker Hub användarnamn

    DOCKER_PASSWORD – Docker Hub access token eller lösenord

När workflowen körs automatiskt vid push till main kommer Docker-imagen uppdateras på Docker Hub.
Länk till projektet

https://github.com/chobacka/personnummer-checker


---
