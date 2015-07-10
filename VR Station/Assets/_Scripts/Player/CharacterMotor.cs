using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Characters.FirstPerson;

public class CharacterMotor : MonoBehaviour {

	public float speed_walk = 1.8f;
	public float speed_run = 3.2f;

	public Head vr_head;
	public Head nor_head;

	Transform head;

	[SerializeField]
	MouseLook m_MouseLook;

	public KeyCode runKey = KeyCode.LeftShift;

	CharacterController cc;
	CollisionFlags m_CollisionFlags;

	// Use this for initialization

	void Awake()
	{
		if (GData.VR_Mode)
		{
			m_MouseLook.YSensitivity = 0.0f;
			vr_head.gameObject.SetActive(true);
			nor_head.gameObject.SetActive(false);
		}
		else
		{
			vr_head.gameObject.SetActive(false);
			nor_head.gameObject.SetActive(true);
		}
	}

	void Start () 
	{
		cc = gameObject.GetComponent<CharacterController>();

		// find the eyes from children
		head = gameObject.GetComponentInChildren<Head>().transform;

		m_MouseLook.Init(transform , head);
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_MouseLook.LookRotation (transform, head);
		GetMove();
	}

	void GetMove()
	{
		float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		float vertical = CrossPlatformInputManager.GetAxis("Vertical");

		float speed = Input.GetKey(runKey) ? speed_run : speed_walk;

		Vector3 desiredDir = (transform.forward*vertical + transform.right*horizontal)
			* Time.deltaTime * speed;

		// apply gtavity
		desiredDir += Physics.gravity * Time.deltaTime;

		m_CollisionFlags = cc.Move(desiredDir);
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Rigidbody body = hit.collider.attachedRigidbody;
		//dont move the rigidbody if the character is on top of it
		if (m_CollisionFlags == CollisionFlags.Below)
		{
			return;
		}
		
		if (body == null || body.isKinematic)
		{
			return;
		}
		body.AddForceAtPosition(cc.velocity*0.1f, hit.point, ForceMode.Impulse);
	}
}
