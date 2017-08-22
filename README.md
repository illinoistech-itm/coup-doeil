# Coup d'Oeil
Mixed Reality Application for Autonomous Movement Framework

## HoloLens project

### Load the Unity project

- Install the Hololens Toolkit, Holotoolkit for direct building of Hololens Applications in unity.  It is a Unity Package.
    + [https://holotoolkit.download/](https://holotoolkit.download/ "holokit")
- Download or clone the repository.
- Open Unity, click on Open Project and select the folder that contains the code.

![Unity load project page](https://i.gyazo.com/84cd966a967a3ff5ee1ae3118a35d816.png)

![Open project button](https://i.gyazo.com/102f13375d6c98d41d789ea9ca4a586b.png)

![Project folder](https://i.gyazo.com/f144f6524a1a28745b763baaee40026c.png)

- You have accessed to Unity project.

![Unity project opened](https://i.gyazo.com/66c4fde1466f66be2615b99ae84035cf.png)

### Compile the Unity project
- Open the Unity project.
- On the left-top corner, select the tab called 'HoloToolkit', and click on 'Build Window'.

![Holotoolkit Build tab](https://i.gyazo.com/33c73899cb0daa08a6f71c2db2383296.png)

![Holotoolkit Build window](https://i.gyazo.com/1c1a5e55828974fd9cf441d95834ad52.png)

- Write a folder name on the top field, and click on 'Build Visual Studio SLN'
- When the build is completed, you can click on 'Open SLN'

#### IMPORTANT
If the folder didn't exist before, make sure you have a file called 'Package.appxmanifest' on 'CoupDOeil\<name of the folder>\CoupDOeil'. 

Open it. It should contain this line:

~~~
  <Dependencies>
    <TargetDeviceFamily Name="Windows.Holographic" MinVersion="10.0.10240.0" MaxVersionTested="10.0.14393.0" />
  </Dependencies>
~~~

~~~
  <Capabilities>
    <Capability Name="internetClient" />
    <Capability Name="internetClientServer" />
    <uap2:Capability Name="spatialPerception" />
  </Capabilities>
~~~

If your file doesn't contain these lines, or it misses some of them, please modify that file.

### Open and run Unity Project

- Open the SLN project (Explained in 'Compile the Unity project' section) 

![SLN project](https://i.gyazo.com/2810114a3d97ec3ce0f0500b85885e0b.png) 

- Change the run parameters to 'Debug' and 'x86'.

![Debug params](https://i.gyazo.com/4867f376a08fce982d6d911c73bf7a89.png)

#### Load the project using HoloEmulator (Windows emulator)

- On the select menu, choose Hololens Emulator (latest version). If this option is not shown, check the installation here https://developer.microsoft.com/en-us/windows/mixed-reality/install_the_tools 

![HoloLens emulator](https://i.gyazo.com/f0c64b77f28c8524d4dd2519a4f7b92e.png)

Hololens Emulator runs almost every application, but it has some problems with SpatialPerception and dynamic changes. We recomend test your application using the real device.

#### Load the project using Real Device (Windows Hololens)

- On the select menu, choose Device (If your device is connected using USB), or Remote Device (If your device is connected using Wifi. You should know its IP address).

![HoloLens emulator](https://i.gyazo.com/f97297917a0e205c3c49b565298eb09b.png)




