# VR-Eye-Gaze-Tracking-Study

## :stuck_out_tongue_winking_eye: GazeTest

GazeTest is a Unity script designed to implement eye gaze tracking for a character in a VR environment using the Oculus VR SDK. It captures eye movement data from the VR headset and applies it to the character's eyes in real-time, enhancing immersion and allowing for gaze-based interactions within the scene.

- Initializes eye tracking for a character in Unity.
- Captures eye gaze data from the Oculus VR headset.
- Updates the character's eye transforms based on the user's eye movements.
- Visualizes the gaze direction using a LineRenderer.
- Potentially allows for interactions with objects in the scene based on where the user is looking.

### Features

Real-time eye tracking using Oculus VR hardware.
Visualization of the user's gaze direction with a LineRenderer.
Framework for interacting with objects based on gaze.

### Methods

Initialization (Start Method)
- Initializes references to essential GameObjects and components.
- Calls AddEyeGaze() to set up eye gaze tracking.


Eye Gaze Tracking (AddEyeGaze Method)
- Finds and assigns the head and eye transforms.
- (Commented out) Adds OVREyeGaze components to the eyes.

Update()
- Updates the eyes' rotations based on eye gaze data.
- Constructs the gaze ray and updates the LineRenderer.

## :smirk: Highlight

The Highlight script is designed to manage the visual highlighting effect on GameObjects within your Unity scene. When attached to a GameObject, it allows that object to be highlighted or de-highlighted programmatically, typically in response to user interactions like gaze or selection.

### Methods

Initialization (Awake Method):
- On startup, the script gathers all materials from the assigned renderers.
- Sets the alpha transparency of the highlight color.

Highlight Toggling (ToggleHighlight Method):
- When enabled (ToggleHighlight(true)), it activates the emission keyword on the materials and sets the emission color to the specified highlight color.
- When disabled (ToggleHighlight(false)), it deactivates the emission, removing the highlight effect.

## :zany_face: HighlightOnRaycast

The HighlightOnRaycast script is responsible for detecting which objects are being targeted by a raycast and applying the highlighting effect to them. It simulates the effect of an object being highlighted when the user looks at it or points at it.

### Methods

Raycast Execution (Update Method):
- Every frame, the script casts a ray from the sourceObject in its forward direction.
- Checks if the ray hits an object and retrieves its main parent using FindPrefabParent.
- If the parent has a Highlight component, it toggles the highlight on.
- De-highlights the last highlighted object if it's different from the current one.
- Logs relevant data into csvData.

Data Saving:
- When the 'Escape' key is pressed, it writes the logged data to a CSV file using WriteCsvToFile.

## :hugs: ChangeColorOnRaycast

The ChangeColorOnRaycast script provides a simpler example of how to change the appearance of objects when they are targeted by a raycast. Instead of using the emission property, it directly changes the material color of the object.

### Methods

Raycast Execution (Update Method):
- On each frame, a ray is cast from the main camera to the mouse position.
- If the ray hits an object with the Highlight script, it toggles the highlight on.
- If no object is hit, it ensures all objects with the Highlight script have their highlights turned off.

## Results

<p align='center'>
    <img src="image\gaze test.png" width="600" height="400">
</p>

