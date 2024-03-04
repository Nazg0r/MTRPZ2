# Markdown-HTML Convertor

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
or
```
dotnet run <Markdown path> --out <destination path>
```
where
- `<Markdown path>` - path of the Markdown file;
- `--out` option to create the final transformed HTML markup file;
- `<destination path>` - destination path of the result file;
  
You also can run the provided build in the following directory using one of the commands:
```
& ".\Markdown display\bin\Debug\net8.0\Markdown display.exe" <Markdown path>
```
or
```
& ".\Markdown display\bin\Debug\net8.0\Markdown display.exe" <Markdown path> --out <destination path>
```


> [!WARNING]  
> The program works correctly only on the Windows operating system.