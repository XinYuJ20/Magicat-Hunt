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

We found a plug-in for Unity titled unity-webxr-export by De-Panther that allows us to use WebXR in Unity. We looked at different tutorials for this plug-in and began implementation. We discovered that WebXR was not supported through Apple’s Safari browser, so we had to download an application … (still writing)

### Zapworks

(explain how zapworks works, the script that was written, how objects are connected in unity)

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

![Octocat](https://github.githubassets.com/images/icons/emoji/octocat.png)

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