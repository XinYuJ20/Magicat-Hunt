---
layout: default
---

MagiCat was intended to be a little XR scavengar hunt around the exhibition, accompanied by a little Magical Cat. At each location, the cat would have specific animations and interact with the given environment. However, our project eventually shifted to more of a marker based animation, where the cat would play animations once the specific marker was detected.

# Implementation 

## Unity

Before this project, none of us had any experience in XR development. We decided to use Unity for development since it was recommended to us as beginner-friendly and had many resources on how to implement what we wanted to create. This choice led to some difficulties later on. 

We created all of our assets and sprites as 2D game-objects within Unity, using scripts to connect them to interactions and animations (as described in a later section). 

One of our main priorities for this project was accessibility of the experience. We decided we wanted people to be able to experience the project within a browser. To do this, we need to switch Unity's platform to WebGL, an API for rendering graphics in a browser. Switching to this platform in Unity translates the project into the correct format so that WebGL can process and render it. This was our initial build setting for this project. To implement augmented reality (AR), we found WebXR to be the standard for browser AR, but unfortunately, Unity’s built-in AR Foundation framework did not include an AR SDK for WebXR. We had to do research on how we could use WebXR with our Unity assets.


## XR Implementation

### Abdandoned AR Implementation

We discovered that WebXR was not supported through Apple’s Safari browser, so we had to download an application WebXR Viewer by Mozilla. We had assumed we would need to use this app for the rest of the project. 

We found a plug-in for Unity titled unity-webxr-export by De-Panther that allows us to use WebXR in Unity. We looked at different tutorials for this plug-in and began implementation. The plug-in did not have tutorials on the marker-based AR experience we wanted to create, so we couldn’t move forward with this procedure.

We then looked to AR.js to combine with Unity to create marker-based AR content. Ar.js is a library based on A-Frame, a high-level framework designed for creating XR projects with HTML-like syntax. AR.js has the capability to fully implement markers and AR in a browser using three.js for rendering. The problem was that we already had done our animations through Unity, so we need to continue to use Unity in our project. We attempted to edit the index.html created when building the unity  project on the WebGL platform to include AR.js tools to implement markers. The goal was to implement a camera in Ar.js that would tell a C# Unity script when the marker was detected so it could start the animation. The communication between the two failed and we ended up with two separate scenes. Normally, the Unity scene would open in the browser and the user would hit the AR mode button to see the experience. With Ar.js, the camera and scene were somehow implemented before going into AR mode, and then would break when the mode was activated. This was a long process that we believe has genuine potential in working if given more time. 

Because of our struggles with marker-based AR, we considered location-based AR instead. Unity has the ability to use location data within scripts to enact animations. Sadly, the WebXR Viewer app was not allowing location data. This was difficult to decipher since there is no information on whether location services can be enabled for the app and there isn’t a built-in inspect or log feature within the app to check for accuracy. For these reasons, we did not proceed with location-based AR. 

We eventually looked further to find Zapworks Universal AR SDK. This is the processes we ultimated used in the project since it gave us full control of AR markers using our Unity game-objects and animations. 

### Zapworks

ZapWorks hosts our project on its servers, enabling it to run as a WebAR experience in a browser. Thus, we no longer need the WebXR Viewer app. 

By default, ZapWorks displays both the marker and the animation content associated with the marker simultaneously. This is not ideal for immersive AR experiences. We added a script to hide the marker while keeping only the animation visible once the marker is detected. This provides a cleaner and more immersive user experience.

Additionally, ZapWorks supports a single marker mode by default, where only one marker can trigger its associated animation at a time. We added a script to enable multi-marker support, allowing multiple markers to be detected and display their associated animations simultaneously.

Lastly, we replaced the original scene camera with the ZapWorks Camera to ensure accurate rendering of AR content and synchronization with the real-world perspective.


## Animations

Animations were hand drawn using Procreate and each frame was placed together to make the final sprite sheets. They were then imported into Unity where they were spliced to make animations.

#### Example Animations and Sprite Sheet
![Idle Animation](https://raw.githubusercontent.com/XinYuJ20/Magicat-Hunt/73cda30f36e5cf3278a04cb436d0595f8210c0b4/idle.gif )
![Flower Sprite Sheet](https://github.com/XinYuJ20/Magicat-Hunt/blob/master/Flowers.png?raw=true)

Marker images were done through Procreate as well. 

#### Example Markers
![Flower Marker](https://raw.githubusercontent.com/XinYuJ20/Magicat-Hunt/73cda30f36e5cf3278a04cb436d0595f8210c0b4/flower_marker.png )
![Potion Marker](https://raw.githubusercontent.com/XinYuJ20/Magicat-Hunt/73cda30f36e5cf3278a04cb436d0595f8210c0b4/portal.png )

# Final Results!

Here is the link to the video of our project: https://drive.google.com/file/d/1N4IwtwneuICzY_JhE0kPp5masxBQNEEA/view?usp=drive_link 

[//]: # (above is the format for pictures, [hover title](image link) )
[//]: # ( https://medium.com/@ciaranbench/how-to-add-a-video-file-on-github-pages-github-io-website-html-a2e9dd81618a -> how to upload videos)

# What We Learned

- WebXR is still new!
  - WebXR is still relatively new in the field of XR. A lot of people are still working and improving it.
- How to work with Unity:
  - We had low to no experience working with Unity for the first time
    - Some of us also had no experience working in C#
  - This was the first time experimenting with making and implementing animations as well

# Next Steps

*   Next time, we would like to incorporate a more cohesive storyline. We's consider having the cat follow the user while markers are not detected so the user developes a stronger relationship with the cat. More animations would be included along with the ability to interact with the cat through touchscreen. 
