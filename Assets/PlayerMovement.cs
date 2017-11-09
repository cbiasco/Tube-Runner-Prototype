using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 45f;
    [SerializeField]
    private string leftControl = "a";
    [SerializeField]
    private string rightControl = "s";

    private float movement;
    private Vector3 previousPosition;
	private float fallVelocity = 0f;

    public float Movement
    {
        get { return movement; }
    }

	public void Move(float move, bool returnToPreviousPosition = false)
	{
		if (returnToPreviousPosition)
		{
			transform.position = previousPosition;
		}

		movement = move;
		previousPosition = transform.position;
		transform.RotateAround(Vector3.zero, Vector3.up, movement * Time.deltaTime);
	}

	private void Start()
    {
        if (leftControl.Length > 1 || leftControl.Length < 1)
        {
            Debug.Log("[PlayerMovement] leftControl of " + " must be a length of 1.");
        }
        if (rightControl.Length > 1 || rightControl.Length < 1)
        {
            Debug.Log("[PlayerMovement] rightControl of " + " must be a length of 1.");
        }
    }

    private void FixedUpdate()
    {
		// Correct distance from camera
		transform.position = new Vector3(transform.position.x, 0f, transform.position.z);

		// Add "gravity"
		fallVelocity += 2.81f * Time.smoothDeltaTime;
		transform.position += transform.position.normalized * fallVelocity;

		// Take input
		movement = 0f;
		if (Input.GetKey(leftControl))
        {
            movement += 1f;
        }
        if (Input.GetKey(rightControl))
        {
            movement += -1f;
        }

		// Apply input
        if (movement != 0f)
        {
			movement *= speed;
            previousPosition = transform.position;
            transform.RotateAround(Vector3.zero, Vector3.up, movement * Time.smoothDeltaTime);
        }

		// Clamp to ground
		if (transform.position.sqrMagnitude > 11 * 11)
		{
			transform.position = transform.position.normalized * 11f;
			fallVelocity = 0f;
		}

		// Adjust rotation toward forward (temporarily up while we're using capsules)
		Quaternion desiredRotation = Quaternion.LookRotation(-transform.position, Vector3.up + Vector3.Cross(Vector3.up, -transform.position)*(movement / speed)/20f);
		transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, .05f);
    }
}
