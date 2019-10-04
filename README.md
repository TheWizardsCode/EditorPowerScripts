# Editor Power Scripts

A small number of useful Unity Editor Scripts. 

## Playback Profiles

Playback profiles enable the user to create multiple profiles for playback that are optimized for different stages of the workflow. For example, in the "MinimalDev" profile we may turn off all effects and runtime spawned objects except the ones critical to the work we are currently doing. This results in faster startup times and allows us to focus on the most important elements at this stage. Whereas, a "Release" profile will have all assets enabled ready for release packaging.

### Using Playback Profiles

  1. Add `GameObjectProfileManager` components to game objects you want to enable/disable.
  2. Configure the `GameObjectProfileManager` for each profile you are using in the inspector.

Note, in the "Scripts/Profiles" folder there are some more profile manager components. These provide additional configuration options, such as the ability to enable/disable fog in the `LightingProfileManager` component. 

# Installing Via Package Manager

Modify your manifest.json file found at /PROJECTNAME/Packages/manifest.json by including the following line - be sure to replace '[VERSiON NUMBER]' with the released version you want to use. You can see the list of release branches on GitHub.

```
{
	"dependencies": {
		...
		"org.3dtbd.editorpowerscripts": "https://github.com/3dtbd/EditorPowerScripts.git#release/v[VERSION NUMBER]",
		...
  }
}
```
