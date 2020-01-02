using UnityEngine;

public class CubeSpinner : MonoBehaviour
{
    public Vector3 spinDistance; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // INCORRECT CODE
        //gameObject.transform.rotation = spinDistance * Time.deltaTime;

        // CORRECT CODE
        transform.Rotate(spinDistance * Time.deltaTime);
        
        
    }
}
