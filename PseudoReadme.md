# Prosjekt CLI

## Models:

### PWD 
Skriver tilbake current directory du er i. Så mappen du holder på i
```csharp
Console.WriteLine(Directory.GetCurrentDirectory());
```
### Echo
Skriver tilbake det du skriver etter Echo (args). Hvis ikke feilmelding
```csharp
if (!string.IsNullOrEmpty(text))
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine("No argument was included");
            }
```
I program:
```csharp
Echo.Repeat(args);
                break;
```

### Touch
Oppretter en ny fil, med feilmelding ved opprettelse uten filnavn
```csharp
public static void Run(string path)
            {

                if (string.IsNullOrEmpty(path)) { Console.WriteLine("Touch mangler filnavn"); return; }
                File.Create(path).Close();
            
            }
```

### cat 
Skriver ut innholdet i en fil. Tar input du skriver inn, matcher det mot en path (filvei) og skriver tilbake filen
```csharp
foreach (var file in args)
                {
                    if (File.Exists(file))
                    {
                        string content = File.ReadAllText(file);
                        Console.Write(content);
                    }
                }
```
### ls
Lister ut alle filer og mapper i arbeidskatalogen, som vi har satt til myDocuments
```csharp
 path ??= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Console.WriteLine($"Listing contents of: {path}");
```
Lister ut undermapper:
```csharp
var folders = directory.GetDirectories();
            foreach (var folder in folders)
```

### mv
Flytting eller nytt navn til fil. 
Flytte til samme disk:
```csharp
if (Path.GetPathRoot(source) == Path.GetPathRoot(destPath))
```
Med direkte move og copy and delete:
```csharp
File.Move(source, destPath, true);

using (FileStream input = new FileStream(source, FileMode.Open, FileAccess.Read))
                    using (FileStream output = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                    {
                        input.CopyTo(output);
                    }
                    File.Delete(source);
```

### cp
Kopiere en fil til ett nytt sted eller navn
```csharp
string source = args[0];
        string destination = args[1];

        if (!File.Exists(source))
```
Bruk av filestream, etterligne cp kommandoen:
```csharp
using (FileStream input = new FileStream(source, FileMode.Open, FileAccess.Read))
            using (FileStream output = new FileStream(destination, FileMode.Create, FileAccess.Write))
```

### head
Viser ett gitt antall linjer fra starten av en fil, her 10.
```csharp
string path = args[0];
            int linesToRead = 10; 
```
Eller legge til flere linjer, feks head 20:
```csharp
 if (args.Length > 1 && int.TryParse(args[1], out int n))
                linesToRead = n;
```

### tail
Gjør det samme som head, men leser baklengs.
```csharp
 string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (lastLines.Count == linesToRead)
                        lastLines.Dequeue(); //fjerner gamleste linje
```

# READme

Vi laget ett enkelt CLI verktøy med en minimalistisk kommandolinje. Med kommandoene:
- cat = Skriv ut innholdet i en fil
- cp = kopier en fil til nytt sted eller navn
- echo = ekkoer det du skriver i tillegg til echo
- head = leser ett antall av de første linjene i en fil
- tail = leser ett antall av de siste linjene i en fil
- mv = flytt eller gi en fil ett nytt nav
- pwd = viser hvordan "katalog" (mappe) man er i
- ls = list ut alle filer og mapper i en katalog (mappe).
- touch = opprett en ny fil
- "exit" avslutte

Man bruker programmet ved å kjøre "dotnet run" og deretter kommandoen man vil kjøre.
For eksempel:
> dotnet run

> echo hello 

> hello


# Refleksjoner:
#### Hva er likhetene og forskjellene mellom de ulike verktøyene?
- Mange kommandoer tar utgangspunkt i filstrukturen og spesielt Cat har store likheter med head/tail.
Flere verktøy kalles med forskjellige argumenter.

#### Hvilke deler av koden kunne dere gjenbrukt på tvers?
- Vi skilte ut path til å være i main program så denne kunne gjenbrukes for de relevante kommandoene.
Dersom vi hadde planlagt bedre kunne vi brukt det samme formatet for innhenting av argumenter og dermed gjenbrukt dette i større grad. 

#### Hvorfor tror dere disse verktøyene fortsatt er så mye brukt i utvikling, til tross for at vi har moderne IDE-er og GUI-er?
- De er lite ressurskrevende og kan i høy grad fungere på tvers av operativsystemer. 
De er enkle og effektive å bruke spesielt for å kunne teste programfunksjonalitet underveis. 
Man får gjort mange forskjellige operasjoner fra ett sted.
Moderne GUI 

# Hva vi ville gjort videre:
- Lagt til hjelpe kommando med info om de forskjellige kommandoene ved dictionary og switch. F.eks cp help
- Utvidet verktøyene med mulighet for tilleggsargumenter
- Lagt til flere CLI verktøy
- Skilt ut menyen i en egen klasse
- Finpusset det visuelle med styling av tekst eller implementasjon av Spectre.console 😁

- Ansatt John Kristian som SCRUM-Master 🤓
