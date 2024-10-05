# VR-Eye-Gaze-Tracking-Study

This project designed and tested an eye tracking system through Unity and C# in a visual kitchen environments with varying object counts. The purpose of this study is to assess the human target-locking behaviour in simple vs. complex environments through gaze tracking.

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


## :thinking: Results

### Gaze Test
<p align='center'>
    <img src="image\gaze test.png" width="600" height="400">
</p>

### Simple Environment

<p align='center'>
    <img src="image\simple.png" width="600" height="400">
</p>

#### Participants' Recording Times in Simple Environment

In this experiment, participants were asked to find specific items (carrot, zucchini, milk, blue package) out of 10 items. 

The recording times for each participant are as follows:

| Participant | Start Recording (s) | End Recording (s) | Duration (s)  |
|-------------|---------------------|-------------------|---------------|
| 1           | 3.178294            | 14.20554          | 11.027246     |
| 2           | 6.47086             | 19.96678          | 13.49592      |
| 3           | 10.17717            | 29.8106           | 19.63343      |
| 4           | 4.547086            | 46.78528          | 42.238194     |
| 5           | 5.215302            | 18.59597          | 13.380668     |


### Complex Envorinment
<p align='center'>
    <img src="image\simple.png" width="600" height="400">
</p>

#### Participants' Recording Times in Complex Environment

In this experiment, participants were asked to find specific items (carrot, zucchini, milk, blue package) out of 20 items. 

The recording times for each participant are as follows:

| Participant | Start Recording (s) | End Recording (s) | Duration (s)  |
|-------------|---------------------|-------------------|---------------|
| 1           | 8.581841            | 19.855            | 11.273159     |
| 2           | 4.603893            | 14.02682          | 9.422927      |
| 3           | 3.12258             | 13.84379          | 10.72121      |
| 4           | 16.07892            | 46.25076          | 30.17184      |
| 5           | 4.79134             | 12.62338          | 7.83204       |


### Duration Comparison

#### Simple Environment

<p align='center'>
    <img src="image\duration_simple.png" width="600" height="400">
</p>

#### Complex Environment

<p align='center'>
    <img src="image\duration_complex.png" width="600" height="400">
</p>

#### Simple vs. Complex

<p align='center'>
    <img src="image\simple_vs_complex.png" width="600" height="400">
</p>