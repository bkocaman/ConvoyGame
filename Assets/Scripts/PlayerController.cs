using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float carSpeed = 10f;
    float Move;
    public GameObject Canvas;

    UIManagerScript UIManagerScript;
    void Start()
    {
        UIManagerScript = GameObject.Find("Canvas").GetComponent<UIManagerScript>();
    }

    void FixedUpdate()
    {
        if (UIManagerScript.isGameStarting)
        {
            if (Input.touchCount > 0 && transform.position.x < 5.5f && transform.position.x > -5.5f)
            {
                Move = 1.5f * Input.touches[0].deltaPosition.x;
            }
            else if (transform.position.x > 5.5f)
            {
                Move = -1;
            }
            else if (transform.position.x < -5.5f)
            {
                Move = 1;
            }
            else
            {
                Move = 0;
            }

            transform.Translate(new Vector3(Move, 1, carSpeed) * Time.deltaTime);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
        }
    }
}