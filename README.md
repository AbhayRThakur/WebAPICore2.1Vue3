# ASP Dot Net Core 2_1 and Vue CLI 3

It is a solution that I was working on for some time. As I faced many issues resolving the dependencies, I felt there was no one stop solution to this. So, why not create one?

This is a simple Web API Core 2.1 project with Vue JS as SPA and front end.
The application is ready to be linked with your Vue JS App and then you may would like to use Axios (for Ajax calls) and call other APIs/Web Services.
Although the project has been developed to run on a single port but since I was doing a POC on a similar kind of project but the Web API and Vue JS were separate projects in a single solution and I was running multiple projects simultaneously so I had to find a way to get these two applications talking while running parallel on different ports.

Hence I implemented Cross-Origin Resource Sharing (CORS) which not only helped the two applications communicate but also straightened the flow. 
I have let the CORS commented code stay in the Startup.cs in case you'd like to test the application with other simultaneously running API/Services.

For the Middleware approach I would like to thank Daniel Jimenez Garcia's solution on dot net curry which led me to a comfortable connection with Vue after many hiccups.
I have also used SpaServices.Extensions and modified the classes to let them serve Vue JS since MS has stopped supporting Vue since Feb 2019.
Have customized the classes and then used them. If you use these classes and would like to modify them further then let the MS license remain.

Hope this solution resolves many issues and may add up to the budding developer community.
