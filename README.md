# Markdown-HTML Convertor

> [!WARNING]  
> The program works correctly only on the Windows operating system.

A simple program that transforms Markdown into HTML tag markup. The core functionality utilizes regular expressions to identify relevant markup elements and convert them into the required format.

To use the program, you need to clone this repository to your local machine:
```
git clone https://github.com/Nazg0r/MTRPZ.git
```
To compile and run program, you need to have the latest version of dotnet core, which can be downloaded at the following [link](https://dotnet.microsoft.com/en-us/download).

Then, when you have the latest version of dotnet, in the root folder of the project, you can run the following command:
```
dotnet run <Markdown path>
```
```
dotnet run <Markdown path> --out <destination path>
```
```
dotnet run <Markdown path> --out <destination path> --format=<format>
```
where
- `<Markdown path>` - path of the Markdown file;
- `--out` - option to create the final transformed HTML markup file;
- `<destination path>` - destination path of the result file;
- `<format>` - the format to which your text is converted. Possible options: `HTML` and `ANSI`. For console output, ANSI format is used by default. HTML is used to output to a file.
  
You also can run the provided build in the following directory using one of the commands:
```
& ".\Markdown display\bin\Debug\net8.0\Markdown display.exe" <Markdown path>
```
```
& ".\Markdown display\bin\Debug\net8.0\Markdown display.exe" <Markdown path> --out <destination path>
```
or
```
& ".\Markdown display\bin\Debug\net8.0\Markdown display.exe" <Markdown path> --out <destination path> --format=<format>
```
## Tests
To run the tests, go to ANSIConvertorUnitTests or HTMLConvertorUnitTests folder and run the following command:
```
dotnet test
```
## Revert commit
*[revert commit](https://github.com/Nazg0r/MTRPZ/commit/0bfe6898a6d49f5e5c5253e8484c72bd273c51ed)*
## Commit with failed tests
*[failed tests](https://github.com/Nazg0r/MTRPZ2/commit/48dd17ee1ee29c295c97a3b3297cef3ff49a4f05)*

## Conclusion
В підсумку роботи з unit тестами я можу впевнено сказати, що це дуже потужна річ, яка дозволяє підтримувати постійний стан програмного забезпечення саме у тому вигляді, у якому воно передбачено бути. В ході розробки даного проекту і постійного рефакторингу, я зрозумів, наскільки важливим і корисним є першочергове написання тестів. 

Головною перевагою процедури тестування є швидке відстежування помилок, які з'являються внаслідок зміни якогось компонента. Це значною мірою економить час і дає уявлення у чому саме проблема. 

Написання тестів, як виявилось, є досить простим і не надто затяжним процесом, і те значення та вплив, які вони мають на швидкість написання коду та розробку вцілому, є незрівнянним з тим, щоб ігнорувати цю процедуру. 
