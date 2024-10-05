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

