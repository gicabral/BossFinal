using UnityEngine;

public class TouchListener : MonoBehaviour
{
    public LayerMask hotspot;
    // put hotspots you want to detect into this layer
    private GameObject flipRightObj;
    private GameObject flipLeftObj;
    private GameObject launchObj;
    //
    private FlipControlLeft flipLeftScript;
    private FlipControlRight flipRightScript;
    private Launcher launchScript;
    private Vector2 touchPoint;
    private Collider2D hit;
    //
    public bool isTouched = false;

    void Start()
    {
        flipRightObj = GameObject.Find("FlipRgt-hingejoint");
        flipLeftObj = GameObject.Find("FlipLeft-hingejoint");
        launchObj = GameObject.Find("Plunger-springjoint");
        // check objects exists
        if (flipRightObj != null && flipLeftObj != null && launchObj != null)
        {
            flipRightScript = flipRightObj.GetComponent<FlipControlRight>();
            flipLeftScript = flipLeftObj.GetComponent<FlipControlLeft>();
            launchScript = launchObj.GetComponent<Launcher>();
        }
    }

    void Update()
    {
        // check object exists
        if (flipLeftScript == null || flipRightScript == null || launchScript == null)
        {
            return;
        }

        if (Input.touchCount > 0)
        {
            int tapCount = Input.touchCount;

            for (var i = 0; i < tapCount; i++)
            {
                touchPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                hit = Physics2D.OverlapPoint(touchPoint, hotspot);

                if (hit != null)
                {
                    Debug.Log(Input.GetTouch(i).phase);
                    if (Input.GetTouch(i).phase == TouchPhase.Began || Input.GetTouch(i).phase == TouchPhase.Stationary)
                    {
                        switch (hit.name)
                        {
                            case "touchRgt":
                                flipRightScript.isTouched = true;
                                break;
                            case "touchLeft":
                                flipLeftScript.isTouched = true;
                                break;
                            case "touchLaunch":
                                launchScript.isTouched = true;
                                break;
                        }
                    }
                }
            }
        }
        else
        {
            flipRightScript.isTouched = false;
            flipLeftScript.isTouched = false;
            launchScript.isTouched = false;
        }
    }
}
