using UnityEngine;

public class AvatarSelectFullBody : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fullBodyA;

    [SerializeField]
    private GameObject fullBodyD;

    public void FullBodyA()
    {
        foreach (GameObject obj2 in fullBodyA)
        {
            if(fullBodyD == true)
            {
                Transform[] allchildren = this.transform.GetComponentsInChildren<Transform>(false);
            }
            else if(obj2 == false)
            {
                obj2.SetActive(true);
            }
            return;
        }
    }
}
