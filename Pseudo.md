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
