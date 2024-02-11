# Overview

This is a very simple demo of using health checks in a C# app.

The app was created using:

```shell
dotnet new web
```

And then I added in a couple of health checks. For testing, I called using curl:

```shell
curl -v localhost:5086/health
```
