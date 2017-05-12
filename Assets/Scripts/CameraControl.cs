using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public GameObject target1;
	public GameObject target2;

    public float followAhead;

    private Vector3 targetPosition;

    public float smoothing;
    public float zoomOut;

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
			targetPosition = new Vector3((target1.transform.position.x + target2.transform.position.x)/2 , (target1.transform.position.y + target2.transform.position.y)/2 , -zoomOut);

			/*
            if (target.transform.localScale.x > 0f)
            {
                targetPosition = new Vector3(targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
            }
            else if (target.transform.localScale.x < 0f)
            {
                targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
            }
			*/

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}
