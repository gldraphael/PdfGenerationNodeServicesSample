# ASP.NET Core PDF Generation using Node Services
Generating a PDF file using a node plugin from ASP.NET Core.

## Run the sample using Docker

**Requires:** `Docker`

```bash
docker build -t aspnetpdf .
docker run -d -p 8080:80 aspnetpdf
```

Now browse to `localhost:8080`.   
You may stop the container using `docker stop {imageid}`.

## Run the sample manually

**Requires:** `.NET Core SDK 2.1.4`, `node` / `npm`.   


```bash
npm install html-pdf --save
dotnet run
```

Now browse to `localhost:5000`.
