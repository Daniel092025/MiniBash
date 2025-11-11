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
```