# Editor Power Scripts

A small number of useful Unity Editor Scripts, including:

  * Playback Profiles : Configure elements in your scene for different playback configurations. For example, have a dev playback mode that uses a flycam and minimal rendering effects or a Release profile that uses the full configuration ready for release.
  * DocGen : A PropertyAttribute based documentation system that allows documentation to be shown in the code, in the editor inspector and even published as markdown.

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

# Tools

## Playback Profiles

Playback profiles enable the user to create multiple profiles for playback that are optimized for different stages of the workflow. For example, in the "MinimalDev" profile we may turn off all effects and runtime spawned objects except the ones critical to the work we are currently doing. This results in faster startup times and allows us to focus on the most important elements at this stage. Whereas, a "Release" profile will have all assets enabled ready for release packaging.

### Using Playback Profiles

  1. Add `GameObjectProfileManager` components to game objects you want to enable/disable.
  2. Configure the `GameObjectProfileManager` for each profile you are using in the inspector.

Note, in the "Scripts/Profiles" folder there are some more profile manager components. These provide additional configuration options, such as the ability to enable/disable fog in the `LightingProfileManager` component. 

## Editor Documentation generator for Unity

Generate in-editor documentation for MonoBehaviours and ScriptableObjects. This documentation is displayed in the Editor as well as enabling markdown documentation to be generated.

Adds a `[DocGen]` attribute that allows more documentation text to be added to a MonoBehaviour, ScriptableObject or a field. This text will be displayed in the inspector as well as in the generated documentation.

### Markdown Output

The system outputs a markdown file documenting all MonoBehaviours, ScriptableOjects and any fields that are serialized by the Editor. This documentation will contain useful information captured in `[Tooltip]` and other field attributes. Additional detail can be provided using a new `[DocGen]` attribute.

 For example:

```
# WizardsCode.Tools.DocGen.ExampleMonoBehaviour

DocGen adds a DocGen attribute that allows more documentation text to be added to a MonoBehaviour or ScriptableObject. This text will be displayed in the inspector as well as in the generated documentation.


## Public String (String)

This is a public string field with a tooltip (you are reading it now).

### Details

Using the DocGen attribute you can add additional documentation to a field that doesn't fit into a ToolTip. This content will only be visible if the field is expanded. The content will also appear in the generated documentation. 

Default Value     : "This is the default value of this string."


## Float Field (Single)

Field with a range.

Default Value     : 0.5
Range             : 0 and 1.5


## Public But Undocumented String (String)

No tooltip provided.

Default Value     : "This public string does not have a tooltip."


## Private Serialized String (String)

This is a private field, but it has the SerializeField attribute. This text comes from the tooltip for the field.

Default Value     : "This is the default value."

```

### Use

  1. Import the DocGen code into your project

#### In-Editor Documentation

Add `[DocGen("Your documentation text here")]` to your MonoBehaviour and ScriptableObjects and Serilized Fields within them as desired. For example:

```c#
[DocGen("This is a simple example of documenting a MonoBehaviour.")]
public class DocGenExample : MonoBehaviour {
    [DocGen("This is a simple example of documenting a public field.")]
    public string aField;
}
```

The DocGen attribute values for fields will now be displayed in the inspector (expand the field to see them). 

Assuming you are not using a CustomEditor for your MonoBehaviour, the class attribute will be shown at the top of the inspector. If you are using a CustomEditor then you need to add a call to the `DrawDocGenAttributes()` extension method at the beginning of `OnInspectorGUI()` method, for example:

```c#
public override void OnInspectorGUI()
{
    this.DrawDocGenAttributes();

    // Your customer inspector code goes here
}
```

#### Generate Markdown Documentation

  1. `Window -> Wizards Code -> Documentation Generator`
  2. Drag an object from your project that contains one of your MonoBehaviours into 'Object Containing MonoBehavior' field
  3. [OPTIONAL] Add a REGEX to filter the files to be processed
  4. Click `Generate`

Your documentation will generated in the directory set in the editor window (defaults to `Assets/Documentation/Generated`)

Note that the Debug Log will contain warnings for all fields that do not have a tooltip.



