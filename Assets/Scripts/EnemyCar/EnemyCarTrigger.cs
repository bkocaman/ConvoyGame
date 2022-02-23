using UnityEngine;
public class EnemyCarTrigger : MonoBehaviour
{
    public BoxCollider box;

    UIManagerScript UIManagerScript;
    void Start()
    {
        UIManagerScript = GameObject.Find("Canvas").GetComponent<UIManagerScript>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Guard"))
        {
            box.isTrigger = false;
            other.transform.parent = null;
            other.GetComponent<BoxCollider>().enabled = false;

            other.transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);

            Destroy(gameObject, 5f);
            Destroy(other.gameObject, 5f);
        }
        if (other.gameObject.CompareTag("Limo") )
        {
            box.isTrigger = false;
            other.transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
    
                UIManagerScript.playerHealth -= 1;
                

            Destroy(gameObject, 5f);
        }
    }
}