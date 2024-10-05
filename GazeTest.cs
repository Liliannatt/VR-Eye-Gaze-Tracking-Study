
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using NaturalPoint.NatNetLib;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.Linq;
using UnityEngine.PlayerLoop;


/// <summary>
/// Represents the initialization of a character in the game.
/// </summary>
public class GazeTest : MonoBehaviour
{


    private readonly ExperimentUtils experimentUtils = new();
	
    GameObject originObject;
    /// <summary> The eye anchor on the character - needed for gaze tracking


    private Transform eyeAnchor;
    /// <summary> The transform of the character.
    private Transform characterTransform;


    private Transform rightEye;
    private Transform leftEye;
	
    /// <summary> following is needed to access the oculus gaze and face variables from tracking
    private OVRFaceExpressions vrFaceExpressions;
    private OVREyeGaze vrEyeGazeRight;
    private OVREyeGaze vrEyeGazeLeft;
    private OVRPlugin.EyeGazesState _currentEyeGazesState;
    private Transform characterHead;
    Vector3 eyeposL,eyeposR;


    private Ray gazeray;             // The gaze ray


    private RaycastHit hit;          // Information about the hit (gaze collides with object)


    public LineRenderer lineRenderer;


    public LayerMask layerMask = ~0;


    private const string FaceName = "head_ply";


    private OVRPlugin.FaceState _currentFaceState;


    public bool ValidExpressions { get; private set; }




    private float GetCharEyeAnchorPos(Transform characterTransform)
    {
        GameObject characterObject = GameObject.Find("AuraFirstPerson");
   
        characterHead = characterObject.transform.Find("Root/Hips/SpineLower/SpineMiddle/SpineUpper/Chest/Neck/Head");
        eyeAnchor = characterHead.Find("Viewpoint");
        rightEye = characterHead.Find("RightEye");
        leftEye = characterHead.Find("LeftEye");


        // GameObject duplicatedLeftEye = Instantiate(leftEye.gameObject, leftEye.position, leftEye.rotation, originObject.transform);
        // duplicatedLeftEye.name = "DuplicatedLeftEye";




        return eyeAnchor.position.y;


    }






    void Start()
    {
           /// you have to create Origin at 0,0,0 for further steps
        originObject = GameObject.Find("Origin");
        if (originObject==null)
        {
            Debug.Log("Origin not found");
        }
        else
        {
            Debug.Log("Origin found");
            GameObject characterObject = GameObject.Find("AuraFirstPerson");
            if (characterObject==null)
            {
                Debug.Log("Character not found");
            }
            else
            {
                Debug.Log("Character found");
			
                AddEyeGaze(characterObject.transform);
            }
           


        }
        // Debug.Log("Eye gaze added");


       
    }






    public void AddEyeGaze(Transform characterTransform)
    {        
            Transform armature = characterTransform.Find("Armature");  
            Transform characterHead = armature.transform.Find("Hips/Spine/Spine1/Spine2/Neck/Head");
            Transform leftEye = characterHead.Find("LeftEye");
            Transform rightEye = characterHead.Find("RightEye");
            Transform viewAnchor = characterHead.Find("EyeAnchor");


            // Debug.Log("Adding eye gaze");
            // vrEyeGazeRight = rightEye.gameObject.AddComponent<OVREyeGaze>();
            // vrEyeGazeRight.Eye = OVREyeGaze.EyeId.Right;
            // vrEyeGazeRight.TrackingMode = OVREyeGaze.EyeTrackingMode.TrackingSpace;
            // vrEyeGazeRight.ReferenceFrame = viewAnchor;
            // vrEyeGazeRight.ApplyPosition = false;
            // vrEyeGazeRight.ApplyRotation = true;
           
            // vrEyeGazeRight.CalculateEyeRotation(vrEyeGazeRight.transform.rotation);


            // vrEyeGazeLeft = leftEye.gameObject.AddComponent<OVREyeGaze>();
            // vrEyeGazeLeft.Eye = OVREyeGaze.EyeId.Left;
            // vrEyeGazeLeft.TrackingMode = OVREyeGaze.EyeTrackingMode.TrackingSpace;
            // vrEyeGazeLeft.ReferenceFrame = viewAnchor;
            // vrEyeGazeLeft.ApplyPosition = false;
            // vrEyeGazeLeft.ApplyRotation = true;
    }


    public void GetFaceExpression()
    {
        float a = (float)OVRFaceExpressions.FaceExpression.EyesLookDownL;
        Debug.Log("Face expression: " + a.ToString());
        ValidExpressions = OVRPlugin.GetFaceState(OVRPlugin.Step.Render, -1, ref _currentFaceState) &&
                           _currentFaceState.Status.IsValid;
        // Debug.Log(_currentFaceState.ExpressionWeights[(int)2]);
        // Debug.Log(_currentFaceState.ExpressionWeights[(int)5]);


    }


    public void GetEyeGaze()
    {


        if (rightEye != null && leftEye != null)
        {
            OVRPlugin.GetEyeGazesState(OVRPlugin.Step.Render, -1, ref _currentEyeGazesState);


            var eyeGazeL = _currentEyeGazesState.EyeGazes[(int)OVRPlugin.Eye.Left];
            OVRPose poseL = eyeGazeL.Pose.ToOVRPose();
            leftEye.transform.rotation = poseL.orientation;
            leftEye.forward = characterHead.TransformDirection(leftEye.forward);


            var eyeGazeR = _currentEyeGazesState.EyeGazes[(int)OVRPlugin.Eye.Right];
            OVRPose poseR = eyeGazeR.Pose.ToOVRPose();
            rightEye.transform.rotation = poseR.orientation;
            rightEye.forward = characterHead.TransformDirection(rightEye.forward);


        }
    }
      /// in update function we draw the gaze direction
    public void Update()
    // helpful reference
    // https://communityforums.atmeta.com/t5/Quest-Development/Eye-Tracking-not-working-on-Unity-Pls-help-sad-devs-make-cool/td-p/995059/page/2
    {
        if (rightEye != null && leftEye != null)
        {
            rightEye.transform.rotation = Quaternion.Euler(UnityEngine.Random.rotation.eulerAngles);
            leftEye.transform.rotation = vrEyeGazeLeft.transform.rotation;
            OVRPlugin.GetEyeGazesState(OVRPlugin.Step.Render, -1, ref _currentEyeGazesState);
            // Debug.Log(eyeGazeL.IsValid);
            // Debug.Log(eyeGazeL.Confidence >= 0.5f);
            var eyeGazeL = _currentEyeGazesState.EyeGazes[(int)OVRPlugin.Eye.Left];
            OVRPose poseL = eyeGazeL.Pose.ToOVRPose();
            leftEye.transform.rotation = poseL.orientation;
            leftEye.forward = characterHead.TransformDirection(leftEye.forward);


            var eyeGazeR = _currentEyeGazesState.EyeGazes[(int)OVRPlugin.Eye.Right];
            OVRPose poseR = eyeGazeR.Pose.ToOVRPose();
            rightEye.transform.rotation = poseR.orientation;
            rightEye.forward = characterHead.TransformDirection(rightEye.forward);


            Vector3 globalEyePosL = characterTransform.TransformPoint(eyeposL);
            Vector3 globalEyePosR = characterTransform.TransformPoint(eyeposR);


            // Set the ray's origin to the midpoint between the eyes
            gazeray.origin = globalEyePosL + 0.5f * (globalEyePosR - globalEyePosL);


            // Transform the direction from local to global coordinates
            gazeray.direction = 0.5f * (leftEye.forward + rightEye.forward);


            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, gazeray.origin);


            // Calculate the end position of the ray based on the fixed length
            float rayLength = 100.0f;


            // Transform the ray end from local to global coordinates
            Vector3 rayEnd = gazeray.origin + leftEye.TransformDirection(Vector3.forward) * rayLength;
            lineRenderer.SetPosition(1, rayEnd);


        }
        // GetEyeGaze();
        // GetFaceExpression();
    }


}


