using UnityEngine;

public class FlipControlRight : MonoBehaviour
{
    private SoundController sound;
    public bool isKeyPress = false;
    public bool isTouched = false;
    public float vel = 0f;
    private HingeJoint2D joint;
    private JointMotor2D jointMotor;

    void Start()
    {
        sound = GameObject.Find("SoundObjects").GetComponent<SoundController>();
        joint = GetComponent<HingeJoint2D>();
        jointMotor = joint.motor;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isKeyPress = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isKeyPress = false;
        }
    }

    void FixedUpdate()
    {
        // on press keyboard or touch Screen
        if (isKeyPress == true && isTouched == false || isKeyPress == false && isTouched == true)
        {
            sound.flipRgt.Play();
            jointMotor.motorSpeed = -vel;
            joint.motor = jointMotor;
        }else
        {
            jointMotor.motorSpeed = vel;
            joint.motor = jointMotor;
        }
    }
}
