# Toolbox API Docker image

Swagger docs URL: http://localhost:5172/swagger/index.html

Dev commands:

```sh
docker build -t toolbox-dev --build-arg="configuration=Debug" .
docker run -d -p 5172:5172 -e ASPNETCORE_ENVIRONMENT=Development --name toolbox-dev toolbox-dev
docker stop toolbox-dev && docker rm toolbox-dev && docker rmi toolbox-dev
```

Prod commands:

```sh
docker build -t toolbox .
docker run -d -p 5172:5172 --name toolbox toolbox
docker stop toolbox && docker rm toolbox && docker rmi toolbox
```
