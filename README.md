
# Word to pdf with dotnet core

Created for document conversion using dotnet core and docker support. There are three steps for this approach.
used DocXToPdfConverter nuget package for libreoffice command line operations.

- Create rest api with dotnet core.
- Add docker support to project.
- Use this command "apt-get update && apt-get -y install libreoffice" after container initialized.
