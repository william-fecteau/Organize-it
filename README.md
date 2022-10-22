# McHacks2022
## Inspiration
Planning a school semester can be a hard task. You need to make your agenda, make your deadlines reminder, make your exam schedule and find a place to put all of your class notes. I have used a lot of tools for those task like Google Agenda, Trello, OneNote, etc. If only there could only be one place where I could do all these tasks...

After track-it, our last hackathon, here is organize-it!

## What it does
Our application was supposed to be a place where you could enter, each semester, your classes, agenda, exams, notes and deadlines. Currently, the application only allows you to enter your semester and your classes, but the backend is fully ready for the deadlines, the agenda and the notes.

## How we built it
We built a Single Page Application (SPA) with an asp.net c# backend and a vue.js frontend. As a database, we used entity framework and identity to setup an in-memory database (To save time!). For the notes storage, we stored it in the cloud using Azure blobs

## Project setup

### Website
### `Project requirements : Visual Studio and npm`

For the main app, open the `.sln` with Visual Studio and run the `McHacks2022` project (With IIS). 

In a seperate terminal, navigation to the sub-folder `ClientApp` and run `npm install` then `npm run serve`.

If there is an error, you may need to install VueJs locally using `npm install -g @vue/cli`, then retry

The project should be running on your `localhost:80`.

### Docker image

To build the docker image, open a terminal at the root of the project and run `docker build -f .\mchacks2022\Dockerfile --force-rm -t mchacks2022 .`
