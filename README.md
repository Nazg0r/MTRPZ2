# Markdown-HTML Convertor

A simple program that transforms Markdown into HTML tag markup. The core functionality utilizes regular expressions to identify relevant markup elements and convert them into the required format.

To use the program, you need to clone this repository to your local machine:
```
git clone https://github.com/Nazg0r/MTRPZ.git
```
Run the provided build in the following directory using one of the commands:
```
".\bin\Debug\net8.0\Markdown display.exe" <Markdown path>
or
".\bin\Debug\net8.0\Markdown display.exe" <Markdown path> --out <destination path>
```
where
- `".\bin\Debug\net8.0\Markdown display.exe"` - relative location of the application;
- `<Markdown path>` - absolute path of the Markdown file;
- `--out` option to create the final transformed HTML markup file;
- `<destination path>` - absolute destination path of the result file;
