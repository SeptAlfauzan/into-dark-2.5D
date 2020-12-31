using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    Camera camera;
    public Vector3 offSet; 
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = playerTransform.position + offSet;
    }

    public IEnumerator Shake(float duration, float magnitude){
        Vector3 originalPos = transform.localPosition;
        float elapse = 0.5f;

        while (elapse <duration)
        {
            float x = Random.Range(-1,1) * magnitude;
            float y = Random.Range(-1,1) * magnitude;

            transform.localPosition = new Vector3(x,y, originalPos.z);
            elapse += Time.deltaTime;//increment sec time
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
