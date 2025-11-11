# Prosjekt CLI

## Models

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


