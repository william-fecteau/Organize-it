# McHacks2022
## Redo this README during the hackathon

## Project setup

### Website
### `Project requirements : Visual Studio and npm`

For the main app, open the `.sln` with Visual Studio and run the `McHacks2022` project (With IIS). 

In a seperate terminal, navigation to the sub-folder `ClientApp` and run `npm install` then `npm run serve`.

If there is an error, you may need to install VueJs locally using `npm install -g @vue/cli`, then retry

The project should be running on your `localhost:80`.

### Docker image

To build the docker image, open a terminal at the root of the project and run `docker build -f .\mchacks2022\Dockerfile --force-rm -t mchacks2022 .`