using UnityEngine;

public class FlipControlLeft : MonoBehaviour
{
    public bool isKeyPress = false;
    public bool isTouched = false;
    private SoundController sound;
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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isKeyPress = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isKeyPress = false;
        }
    }

    void FixedUpdate()
    {
        // on press keyboard or touch Screen
        if (isKeyPress == true && isTouched == false || isKeyPress == false && isTouched == true)
        {
            sound.flipLeft.Play();
            // coloca a velocidade do motor como maxima
            jointMotor.motorSpeed = vel;
            joint.motor = jointMotor;

        }else
        {
            jointMotor.motorSpeed = -vel;
            joint.motor = jointMotor;
        }

    }
}
