# Reptilian CLI

Playground for starting to learn my way around C#/.NET :tada:

Built largely following the [`mahi` article series on Medium](https://medium.com/swlh/building-a-dev-container-for-net-core-e43a2236504f) by [@ManfredLange](https://github.com/ManfredLange)

## Setup

You will need:
- A stable version of Visual Studio Code, with the `Remote Development` and `Docker` extensions installed
- Docker Desktop (MacOS and Windows) or Docker Engine (Linux)

In a terminal, run:
```sh
git clone git@github.com:lache-melvin/reptilian.git
# OR
git clone https://github.com/lache-melvin/reptilian.git

cd reptilian

# Copy the .env.example file to an .env file
cp .env{.example,}

# Open the repository in VSCode
code .
```

- In VSCode, when the prompt appears, select `Reopen in Container` and wait for everything to install
    - This may take a while the first time as the docker images will likely need to be pulled from DockerHub

