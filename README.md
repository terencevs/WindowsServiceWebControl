# Windows Service Web Control

A self hosted Windows service which provides an API to query the state, start, stop, restart Windows services. The idea came from wanting a way to allow HUBOT (https://hubot.github.com/) to perform actions on Windows Services.

[![Build status](https://ci.appveyor.com/api/projects/status/6lvrn7dk3t22a3lh?svg=true)](https://ci.appveyor.com/project/terencevs/windowsservicewebcontrol)
[![Join the chat at https://gitter.im/terencevs/WindowsServiceWebControl](https://badges.gitter.im/terencevs/WindowsServiceWebControl.svg)](https://gitter.im/terencevs/WindowsServiceWebControl?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
### End Points
#### Get
* http://{servicehost}:8081/service/{host}/{service_name}/status
* http://{servicehost}:8081/health/ping

#### Post
* http://{servicehost}:8081/service/{host}/{service_name}/start
* http://{servicehost}:8081/service/{host}/{service_name}/stop
* http://{servicehost}:8081/service/{host}/{service_name}/restart

### Installing Service
To run the service in command line and not install it simply double click on the executable.
To install the service simple run the following command from cmd: (run as administrator)
```
WindowsServiceWebControl install
```
