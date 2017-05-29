# docker-sftp-issue
When doing SFTP into a docker container we ran into a stability issue

# Prerequisites
- Docker
- DotNet Core 1.1.2

# Run it
1. Clone the repo
1. `docker-compose -f docker-compose.yml up`
1. Open a new terminal or ctrl-z
1. `cd client`
1. `dotnet restore`
1. `dotnet run`

# What will happen
The program uploads the files 50MB.zip and 20MB.zip to the dockerized sftp server 20 times. We experienced the upload to stall at random points in time. You can see the stall by the stars suddenly stopping.
