# ASP.NET Core PDF Generation using Node Services
Generating a PDF file using a node plugin from ASP.NET Core.

<img 
  src="https://user-images.githubusercontent.com/10794213/40712638-cbd3e994-641b-11e8-8266-391a48249b30.png" 
  alt="Screenshot" 
  width="50%">

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

---

The generated PDF's HTML source is borrowed from the [`marcbachmann/node-html-pdf`](https://github.com/marcbachmann/node-html-pdf) repo.
