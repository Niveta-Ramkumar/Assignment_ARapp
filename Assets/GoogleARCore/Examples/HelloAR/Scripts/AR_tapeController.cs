//****************************************************************************************************************************************************************
// 
//This script manages to measure the dimensions of the package
//Attached to the tape button
//Attach three gameobjects to measure - sphere prefab
//Attach the Text - text prefab
//*********************************************************************************************************************************************************

namespace GoogleARCore.Examples.HelloAR
{
    using System.Collections.Generic;
    using GoogleARCore;
    using GoogleARCore.Examples.Common;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

#if UNITY_EDITOR
    // Set up touch input propagation while using Instant Preview in the editor.
    using Input = InstantPreviewInput;
#endif

    /// <summary>
    /// Controls the HelloAR example.
    /// </summary>
    public class AR_tapeController : MonoBehaviour
    {
        /// <summary>
        ///  load the prefab for text
        /// </summary>

        // To save the line renderer
        public GameObject Text;
        /// <summary>
        /// Creating list to save the position of touch to measure the distance between them
        /// </summary>
        public List<GameObject> Points = new List<GameObject>();
        // variable to keep track of the touch points
        public int count = 0;

        /// <summary>
        /// The first-person camera being used to render the passthrough camera image (i.e. AR
        /// background).
        /// </summary>
        public Camera FirstPersonCamera;

        /// <summary>
        /// A prefab to place when a raycast from a user touch hits a vertical plane.
        /// </summary>
        public GameObject GameObjectVerticalPlanePrefab;

        /// <summary>
        /// A prefab to place when a raycast from a user touch hits a horizontal plane.
        /// </summary>
        public GameObject GameObjectHorizontalPlanePrefab;

        /// <summary>
        /// A prefab to place when a raycast from a user touch hits a feature point.
        /// </summary>
        public GameObject GameObjectPointPrefab;

        /// <summary>
        /// The rotation in degrees need to apply to prefab when it is placed.
        /// </summary>
        private const float k_PrefabRotation = 180.0f;

        /// <summary>
        /// True if the app is in the process of quitting due to an ARCore connection error,
        /// otherwise false.
        /// </summary>
        private bool m_IsQuitting = false;

        /// <summary>
        /// The Unity Awake() method.
        /// </summary>
        public void Awake()
        {
            // Enable ARCore to target 60fps camera capture frame rate on supported devices.
            // Note, Application.targetFrameRate is ignored when QualitySettings.vSyncCount != 0.
            Application.targetFrameRate = 60;
        }

        /// <summary>
        /// The Unity Update() method.
        /// </summary>
        public void Update()
        {
            // Checking for "Rest" to reload the screen or start fresh measurement
            if (Track.reset == 1)
            {
                // Reload the scene
                SceneManager.LoadScene("AR_Tape");
                // Rest the touch points to zero
                count = 0;
                // Resetting the measured values to zeros correspondingly
                if (Track.p_w == 1)
                {
                    Track.width = 0f;
                }
                if (Track.p_l == 1)
                {
                    Track.length = 0f;
                }
                if (Track.p_h == 1)
                {
                    Track.height = 0f;
                }

            }
            _UpdateApplicationLifecycle();

            // If the player has not touched the screen, we are done with this update.
            Touch touch;
            if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
            {
                return;
            }

            // Should not handle input if the player is pointing on UI.
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                return;
            }

            // Raycast against the location the player touched to search for planes.
            TrackableHit hit;
            TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
                TrackableHitFlags.FeaturePointWithSurfaceNormal;
            // rest the measurement
            
            if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit) && count <=1)
            {
                // Use hit pose and camera pose to check if hittest is from the
                // back of the plane, if it is, no need to create the anchor.
                if ((hit.Trackable is DetectedPlane) &&
                    Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position,
                        hit.Pose.rotation * Vector3.up) < 0)
                {
                    Debug.Log("Hit at back of the current DetectedPlane");
                }
                else
                {
                    // Choose the prefab based on the Trackable that got hit.
                    GameObject prefab;
                    if (hit.Trackable is FeaturePoint)
                    {
                        prefab = GameObjectPointPrefab;
                    }
                    else if (hit.Trackable is DetectedPlane)
                    {
                        DetectedPlane detectedPlane = hit.Trackable as DetectedPlane;
                        if (detectedPlane.PlaneType == DetectedPlaneType.Vertical)
                        {
                            prefab = GameObjectVerticalPlanePrefab;
                        }
                        else
                        {
                            prefab = GameObjectHorizontalPlanePrefab;
                        }
                    }
                    else
                    {
                        prefab = GameObjectHorizontalPlanePrefab;
                    }

                    // Instantiate prefab at the hit pose.
                    // place a sphere at the hit point
                    var gameObject = Instantiate(prefab, hit.Pose.position, hit.Pose.rotation);
                    count += 1;
                    Points.Add(gameObject);
                    if (Points.Count >= 2)
                    {
                        // generating line renderer
                        gameObject.GetComponent<LineRenderer>().positionCount = 2;
                        gameObject.GetComponent<LineRenderer>().SetPosition(0, gameObject.transform.position);
                        gameObject.GetComponent<LineRenderer>().SetPosition(1, Points[Points.Count - 2].transform.position);
                        // adding values using line renderer
                        var temp = Instantiate(Text, (gameObject.transform.position + Points[Points.Count - 2].transform.position) / 2, Quaternion.identity);
                        temp.transform.LookAt(gameObject.transform.position);
                        temp.transform.localEulerAngles = new Vector3(90, temp.transform.localEulerAngles.y + 90, 180);
                        temp.GetComponent<TextMesh>().text = (Vector3.Distance(gameObject.transform.position, Points[Points.Count - 2].transform.position) * 100).ToString("0.00");
                        // storing the measured values
                        if (Track.p_w ==1 && Track.width <=0.1f)
                        {
                            Track.width = (Vector3.Distance(gameObject.transform.position, Points[Points.Count - 2].transform.position) * 100);
                        }
                        if (Track.p_l == 1 && Track.length <= 0.1f)
                        {
                            Track.length = (Vector3.Distance(gameObject.transform.position, Points[Points.Count - 2].transform.position) * 100);
                        }
                        if (Track.p_h == 1 && Track.height <= 0.1f)
                        {
                            Track.height = (Vector3.Distance(gameObject.transform.position, Points[Points.Count - 2].transform.position) * 100);
                        }
                    }
                    // Compensate for the hitPose rotation facing away from the raycast (i.e.
                    // camera).
                    gameObject.transform.Rotate(0, k_PrefabRotation, 0, Space.Self);

                    // Create an anchor to allow ARCore to track the hitpoint as understanding of
                    // the physical world evolves.
                    var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                    // Make game object a child of the anchor.
                    gameObject.transform.parent = anchor.transform;
                }
            }
            else if (count > 1)
            {
                // takes you to the main page
                SceneManager.LoadScene("Measure");
            }
            else
            {

            }
        }

        /// <summary>
        /// Check and update the application lifecycle.
        /// </summary>
        private void _UpdateApplicationLifecycle()
        {
            // Exit the app when the 'back' button is pressed.
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            // Only allow the screen to sleep when not tracking.
            if (Session.Status != SessionStatus.Tracking)
            {
                Screen.sleepTimeout = SleepTimeout.SystemSetting;
            }
            else
            {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }

            if (m_IsQuitting)
            {
                return;
            }

            // Quit if ARCore was unable to connect and give Unity some time for the toast to
            // appear.
            if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
            {
                _ShowAndroidToastMessage("Camera permission is needed to run this application.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
            else if (Session.Status.IsError())
            {
                _ShowAndroidToastMessage(
                    "ARCore encountered a problem connecting.  Please start the app again.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
        }

        /// <summary>
        /// Actually quit the application.
        /// </summary>
        private void _DoQuit()
        {
            Application.Quit();
        }

        /// <summary>
        /// Show an Android toast message.
        /// </summary>
        /// <param name="message">Message string to show in the toast.</param>
        private void _ShowAndroidToastMessage(string message)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity =
                unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            if (unityActivity != null)
            {
                AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
                unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    AndroidJavaObject toastObject =
                        toastClass.CallStatic<AndroidJavaObject>(
                            "makeText", unityActivity, message, 0);
                    toastObject.Call("show");
                }));
            }
        }
    }
}
