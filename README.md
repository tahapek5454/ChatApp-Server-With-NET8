# ChatApp-Server-With-NET8
The aim of this project is create ChatApp server with .NETCore 8.

## How to start with DOCKER
### Setup
+ ```docker volume create chatvolume```
+ ```docker network create chatnetwork```
+ ```docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Secret123" -p 1433:1433 --name chatsqlcontainer -v chatvolume:/var/opt/mssql --network chatnetwork -d mcr.microsoft.com/mssql/server:2019-latest```
+ ```docker container run --name chatappcontainer --network chatnetwork -p 7279:8080 -d tahapek5454/chatappserver:1.0```

### After Setup
+ [Visit client web site](https://chatapp-tp.netlify.app/#/).
+ If you want to see clien's source code you can visit my [client repo](https://github.com/tahapek5454/ChatApp-Client-With-Vue.js).
### Note: 
+ When you enter the site, you must create at least two accounts to use the application. Afterward, you can see others in the sidebar and start a conversation by clicking on them.
+ Since user information like usernames is stored in local storage in the application, to use the application efficiently, you should open the second page in another browser or in the incognito mode of the current browser. Otherwise, active users may get mixed up.
