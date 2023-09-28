using UnityEngine;

public class ShowHideAllChildrenOnDistanceToPlayer : MonoBehaviour
{
    public float distance = 200f;

    bool lastActive = true;

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Distance(transform.position, Camera.main.transform.position) < distance) != lastActive)
        {
            lastActive = !lastActive;
            // Activate/Deactive all children of this transform
            foreach (Transform child in transform) {  // That looks .... wierd?
                child.gameObject.SetActive(lastActive);
            }
        }
    }
}
