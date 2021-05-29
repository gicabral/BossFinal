using UnityEngine;

public class AnimateController : MonoBehaviour
{
    public Sprite[] spriteSet;
    public float fps;
    public GameObject tree;
    private float turnVel = 30f;

    private void FixedUpdate()
    {
        if (tree != null)
        {
            tree.transform.Rotate(new Vector3(0f, 0f, turnVel * Time.fixedDeltaTime));
        }
    }

}
