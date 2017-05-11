using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public GameObject target;
    public float followAhead;

    private Vector3 targetPosition;

    public float smoothing;

    public bool followTarget;

	// Use this for initialization
	void Start () {
        followTarget = true;
	}

    // Update is called once per frame
    void Update()
    {
        if (followTarget)
        {
            targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, -1);

            if (target.transform.localScale.x > 0f)
            {
                targetPosition = new Vector3(targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
            }
            else if (target.transform.localScale.x < 0f)
            {
                targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
            }

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}
