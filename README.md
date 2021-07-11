
# Word to pdf with dotnet core

Created for document conversion using dotnet core and docker support. 
Used a [resource](https://github.com/smartinmedia/Net-Core-DocX-HTML-To-PDF-Converter.git) to achive that.

## Requirements
 - To use as docker container, you need to install Docker desktop from [here](https://www.docker.com/products/docker-desktop)

## Installation

 - Clone this repository to local 
 - Navigate your terminal to `src\RestApiExample` folder and run `docker build -t docxconvertor .` command to create docker image.
 - In terminal, use `docker run -d -p 8080:80 --name=docxconvertorcontainer docxconvertor`command to run container from image that just created.
 - In terminal, connect to the running container interactive mode by `docker exec -it docxconvertorcontainer bash`.
 - In interactive mode install libre office using `apt-get update && apt-get -y install libreoffice`
 - Now, you are ready to go. From a client (eg: Postman), you can make post request to `http://localhost:8080/Document/ConvertToPdf` with this body:
```
  {
    "wordBase64": "base64 string of file"
  }
```
 
## Contributors

 - [Abidin Doğan](https://github.com/AbidinDogan)
 - [Said Yeter](https://github.com/kordiseps)

## Licence

MIT License

Copyright (c) 2021 dotnet-core-wordToPdf-converter

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.