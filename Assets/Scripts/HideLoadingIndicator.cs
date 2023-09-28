using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLoadingIndicator : MonoBehaviour
{
    public float delay = 3.0f;
    // Start is called before the first frame update
    public IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

}
