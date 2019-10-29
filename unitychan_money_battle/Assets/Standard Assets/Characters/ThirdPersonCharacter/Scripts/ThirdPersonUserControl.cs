using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using InControl;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

        private float v;
        private float h;
        private bool crouch;
        GameObject cam;
        public InputDevice Device { get; set; }

        private void Start()
        {
            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
        }


        private void Update()
        {

            if (gameObject.name == "UnityChanPlayer0")
            {
                cam = GameObject.Find("MultipurposeCameraRig");
            }
            else if (gameObject.name == "UnityChanPlayer1")
            {
                cam = GameObject.Find("MultipurposeCameraRig2P");
            }
            // get the transform of the main camera
            if (cam != null)
            {
                m_Cam = cam.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }


            if (!m_Jump)
            {
                if (Device == null)
                {
                    if(gameObject.name == "UnityChanPlayer0")
                    {
                        m_Jump = CrossPlatformInputManager.GetButton("Jump");
                    }
                    else if(gameObject.name == "UnityChanPlayer1")
                    {
                        m_Jump = CrossPlatformInputManager.GetButton("Jump_2");
                    }
                }
                else
                {
                    m_Jump = Device.Action4.IsPressed;
                }
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            /*
            // read inputs
            float h = CrossPlatformInputManager.GetAxis("joystick 1 analog 1");
            float v = CrossPlatformInputManager.GetAxis("joystick 1 analog 0");
            bool crouch = CrossPlatformInputManager.GetButton("Crouching");
            */
            if(Device == null)
            {
                if(gameObject.name == "UnityChanPlayer0")
                {
                    h = CrossPlatformInputManager.GetAxis("Horizontal");
                    v = CrossPlatformInputManager.GetAxis("Vertical");
                    crouch = CrossPlatformInputManager.GetButton("Crouching");
                }
                else if(gameObject.name == "UnityChanPlayer1")
                {
                    h = CrossPlatformInputManager.GetAxis("Horizontal_2");
                    v = CrossPlatformInputManager.GetAxis("Vertical_2");
                    crouch = CrossPlatformInputManager.GetButton("Crouching_2");
                }
            }
            else
            {
                h = Device.LeftStickX;
                v = Device.LeftStickY;
                crouch = Device.Action3;
            }
            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v*m_CamForward + h*m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v*Vector3.forward + h*Vector3.right;
            }
//#if !MOBILE_INPUT
			// walk speed multiplier
	        //if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
//#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
            
        }
    }
}
