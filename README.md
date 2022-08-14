# VATUtils
Utils script for using VAT3.0 shaders form SideFX Labs with VFX Graph Effects.
For more information on Vertex Animation Texture (VAT) see the [SideFX Labs repository](https://github.com/sideeffects/SideFXLabs) or the [FAQ and Links thread on their forum](https://www.sidefx.com/forum/topic/81422/?page=1)

![gif](https://i.imgur.com/RjQancz.gif)
![gif](https://i.imgur.com/xd0P9Fj.gif)
![gif](https://i.imgur.com/7JL7xAJ.gif)
![gif](https://i.imgur.com/7JualnR.gif)
![gif](https://i.imgur.com/rpskAqx.gif)

System requirements/Tested with
-------------------
- Unity 2021.X
- HDRP 12.1.X

### What's in the package
This package proposes multiple examples of Visual Graph Effect using Vertex Animation Textured mesh as an output (one per VAT type).
It supports the following VAT types:

* **Rigid body**
* **Soft body**
* **Dynamic Remeshing**
* **Particles sprites**

It includes updated **VAT Shaders** from SideFX Labs to work with VFX Graph.

It also proposes **helper scripts** to dynamically load an set all the data (textures and variable) from the VAT exported material to the VFX Graph
See more infos on how to use it on te dedicated section.

### Why not use the shader from SideFX Labs ?
The SideFX Labs shaders for VAT3.0 are really amazing and full of new options and optimization since the VAT 2.1.
Unfortunately, they are not compatible with VFX graph for the moment. This due to the fact that these shaders are using boolean keyword for shader variant, which is not compatible with the VFX Graph blackboard.
This package proposes an updated version of the shaders without the keywords (replaced by uniform bool) in order to work with VFX Graph.

Using bool instead of keyword might impact the optimization as the shader. This is only a patch.
Hopefully Unity will support keywords on the VFX blackboard which will make this retake obsolete.

### Install Package
This package uses the scoped registry feature to import dependent packages.
Please add the following sections to the package manifest file (Packages/manifest.json).

To the scopedRegistries section:
```
{
    "name": "Bonjour-lab",
    "url": "https://registry.npmjs.com",
    "scopes": [
        "com.bonjour-lab"
    ]
}
```

To the dependencies section:

```
"com.bonjour-lab.vatutils": "0.0.5",
```

After changes, the manifest file should look like below:
```
{
  "scopedRegistries": [
    {
      "name": "Bonjour-lab",
      "url": "https://registry.npmjs.com",
      "scopes": [
        "com.bonjour-lab"
      ]
    }
  ],
  "dependencies": {
    "com.bonjour-lab.vatutils": "0.0.5",
    ...
```

## How to use this package
First, create and export your VAT file using the VAT 3.0 format for Unity from SideFX Labs.
See more on the SideFX forum [FAQ and Links](https://www.sidefx.com/forum/topic/81422/?page=1) to learn more about VAT and how to export them for Unity.

Duplicate one VAT shader template from the ```Editor/Shader``` folder. Choose the one adapted to your VAT file.
Apply this shader to your VAT material and update its design (Albedo, normal map... anything you want) using shader graph.
Apply all the VAT texture to the material. **This is important as the script will read the material to grab all the data and bind it to your VFX Graph**
Using this you can check if your VAT works fine before creating your VFX Graph.
![img](https://i.imgur.com/VWmpymq.jpg)

Duplicate one of the VFXGrap templates from the  VFX Template  folder. 
Choose the one adapted to your VAT and create your own VFX simulation. 
Replace the Shadergraph asset from the ```Output Particle Lit Mesh``` with your own shader and link the new uniform variable if you have created some (like Color, Albedo, Normal map...)

Add your VFX Graph to the scene and add the corresponding binding script. There is one script per VAT type
* ```BindVATDynamicRemeshingToVFX.cs```
* ```BindVATParticleSpritesToVFX.cs```
* ```BindVATRigidBodyToVFX.cs```
* ```BindVATSoftBodyToVFX.cs```
Add your VAT mesh and material to the ```VAT Mesh Reference``` and ```VAT Material Reference``` variables.
Click on **Bind VAT Params to VFX** to bind your VAT data to your VFX Graph

![img](https://i.imgur.com/Trcuwdk.jpg)

## Extend the Bind VAT Params script
If you want you, can extend any ```BindVAT...ToVFX``` script to add more variable to bind to your VFX graph.
You can simply create a new script which will inherit from the target type and override the ```BindCustomDataToVFX``` function.

```
 protected virtual void BindCustomDataToVFX(ref VisualEffect vfx){
    //Extend this function to bind your own custom data to the VFX Graph (eg: Albedo, Roughness, Metallic...)
 }
```

This repository includes an example of extended system where a VFX graph output two mesh (a flower and its pistil) using two VAT meshes and shaders.
See the ```VFXxVAT_SoftBody_Multiple``` graph for the VFX parts and the ```BindVATMultiSoftBodyToVFX.cs``` script for extending the binding script.

![img](https://i.imgur.com/eXcygVl.jpg)

## Content property
This project is an open source tool intended to provide helps using VAT shader from SideFX Labs with VFX Graph.
The VAT files (FBX/Textures) shared in this project are shared and intended to use as example only.
They are the property of their author and should not be used without specific prior permission