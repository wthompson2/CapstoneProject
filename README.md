# CapstoneProject
As of 4.28.21:

Virtual Tour - PKI

The application is a simulation of the PKI building (parts of the building) and acts as a standin for the on campus Open House in addition to acting as a way for prospective 
students to view the campus and its faculty as well as learning about specific majors and programs offered by the college in an interesting and interactive way.

Deployment/How to use application:
The application is built in Unity and is deployed in a WebGL build for easy access for the most users. In order to run the application it is as simple as executing the application
which will then open the application in a browser (recommend Firefox). This is to prevent users from having to download the game/application and instead allow them to quickly
deploy it via their browser. However, as the application increases in size and intricasy, the deployment may need to be changed to an executable build in which case the users will
have to download the build and execute it from the download.

Features: Below is a list of specific features that the application implements in order to act as a good simulation and college information provider:

- Virtual Recreation of certain areas of PKI (not 1:1 but close approximations)
- Whiteboards playing videos from actual Professors that start and stop via in-room triggers
- Character Selection screen
- Full Menuing
- Multple classrooms with multiple videos
- Fishbowl implementation
- Full modeling of PKI-like items including monitors, mice, and keyboards

If running via the Unity editor, be sure to run in the TitleScene as this is the first screen that players will see when the game opens up.

**Known bugs for initial cloning:**
In the TitleScene may need to change the reference function for the Start button: 
Under Canvas->Start: Change the onClick() second dropdown in the button component section to the option:
RespondToButtonClicks.HandleCharacterButtonOnClickEvent

Player models on the character select screen do not have correct hit detection, so character selected will not be used; instead the default model "Ethan" will be used.
