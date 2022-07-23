# IMPORTANT: README OUTDATED
This repository is under update to support VAT3.0 from sideFX. 
The following readme is outdated and concerns VAT2.1. See the VAT 2.X branch for complete informations.

todo:
* [ ] Add support for Particles and dynamic remeshing (```VATDataStructs.cs``` + inheritance class from ```BindVATToVFX.cs```)
* [ ] Remplace keyword from Rigid body, Particles and dynamic remeshing shaders by bool as BVFX blackboard doesn't support it (shadergraph)
* [ ] Add vfx examples for Rigid body, Particles and dynamic remeshing

* [X] Add support for Rigidbody (```VATDataStructs.cs``` + inheritance class from ```BindVATToVFX.cs```)
* [X] Add vfx examples for Rigid bodyg

# VATUtils
Utils script for using VAT shader form SideFX Labs with VFX Graph Effects
For more information on Vertex Animation Texture (VAT) see the [SideFX Labs repository](https://github.com/sideeffects/SideFXLabs)

![gif](https://i.imgur.com/QvUroaJ.gif)

System requirements
-------------------
- Unity 2021.X
- HDRP 12.1.X

### What's in the package
This package propose a mockup of a Visual Graph Effect using Vertex Animation Textured mesh as an output.
It also propose an helper script to dynamically load an set all the data (textures and variable) from the VAT exported files to the Visual Graph

## How to use the VFX Graph model
![img](https://i.imgur.com/kFFI8xn.png)
Make a copy of the VFX graph inside the package and start put all your VAT data.

## How to use the Helper Script
Place all your VAT Assets inside the Resources folder (everything will be loaded from this folder)
Keep the hierarchy from the Houdini export. You should have three folders per VAT
- **materials**: Containing the material and json data
- **mesh**: Containing the Mesh for the VAT
- **textures**: Containing all the textures. You can also place your albedo, Mask and normal maps.
![img](https://i.imgur.com/Ig3xazw.png)

Create a new scripatble object of type **VATDescriptor** (Asset → Create → Scriptable Object → VATDescriptor) and provide all the attributes for your VFX.
- **FolderPath**: the path of your VAT folder inside the Resources folder
- **VATName**: name of your VAT (Houdini exported params uses *NAME_ELEMENT.extension* for textures, materials and json data such as *Orchide_data.json* or *Orchid_pos.exr* for position map)
- **VFXPrefabModel**: the prefab conatining the VFXGraph
- **Number of instance**: number of elements spawn by the VFX
- **GlobalScale**: value used for rescaling VAT on your scene
- **VFX Materials Params**: Albedo, mask and normal map
![img](https://i.imgur.com/qpuC0X3.png)

Create your own VFX graph by making a copy of the VFXGraph model in the package and place it on your GameObject.
Add the *BindVATParamsToVFXInGame.cs* script on your GameObject and set the **VATDescriptor** attribute using your own.
Click on _Bind VATParams to VFX_ to bind the data to your VFX Graph

Do not hesistate to extend the *VATDescriptor.cs* script to dynamically provide more data to you VFX graph dynamically. 
See the _VATFlowerPistilDescriptor.cs_ for an example for multiple VAT output.

You can also use the _VATDescriptor.cs_ from script by simple calling ```VATDescriptorObject.InitVFX(Tranform parent)``` which will automatically instantiate the VFX prefab with all the data set.

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
"com.bonjour-lab.vatutils": "0.0.2",
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
    "com.bonjour-lab.vatutils": "0.0.2",
    ...
```

