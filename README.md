# GameBrowser

## History

This utility started off as a basic tool for scanning Quake III Arena servers. It was originally written in VB6 back in 2007 and then migrated to C# in 2010 when I started learning the language before parking it in 2011 when my wife and I stopped playing Quake 3 and had no use for it anymore.

While on furlough during the COVID-19 pandemic, my family and I started playing some older games together, so I've created a game server on my home server for us to use and dug out this project to help with checking when the server was up. HOWEVER... the biggest problem with digging out old code is that you realise how poor it was and then you get the urge to make it better 😄

... and better is hopefully how I've made it :crossedfingers:

## Architecture

The "utility" (if it can still be referred to in this way?) consists of the following:

### Library

The GameBrowser library is located in the `api` directory and is a .NET Standard 2.0 project - my theory being that other people could use it in a Framework project (should they even want to).

### API

The API is a .NET Core 3.1 web api project that consumes the library to expose the necessary functionality via endpoints.

### Web

Repository: https://github.com/jonifen/gamebrowser-web

Written in JavaScript using React, this is a simple web application to query the API based on server data stored in localStorage.

## Known "issues"

* The server querying in the library isn't async (but the pinging *is* since [this commit](https://github.com/jonifen/GameBrowser/commit/1ae8aedcf352dbb6272f38443378b9de1cc68c0b)), so if you query a server which is down but the server hosting it is still up, you will encounter some serious lag... in fact, I don't think it'll ever recover, so you'd quickly end up in a mess with the API not releasing requests etc. I do intend to look into this, but as it's only for querying our local server at the moment, it's not priority. PRs are welcomed if anyone else has the interest in tackling it though.
* The UI is pretty bad - I've not started any of the styling yet. I'm torn between going with vanilla CSS or using SASS for the additional learning opportunity it would offer.
