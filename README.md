# Inventory System



## Deploying with docker

Generate the compiled package for linux.

``` asp
dotnet publish -r linux-x64 --output ./publish
```

You can quickly run a container with:

```dockerfile
docker build -t webapi .
docker run -p 80:80 webapi
```

## Routes



## Autor/Author ✒️

* **Gabriel Alexander Barrientos** - [galexbh](https://github.com/galexbh)

## Necesario/Necessary 📄

- [Asp Net Core](https://dotnet.microsoft.com/download)

