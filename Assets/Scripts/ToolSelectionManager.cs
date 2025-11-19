using UnityEngine;

public class ToolSelectionManager : MonoBehaviour
{
    public GameObject ShieldObj;
    public GameObject GunObj;
    public GameObject ShootButton;

    public void SwapToGun()
    {
        if (!GunObj.activeSelf)
        {
            GunObj.SetActive(true);
            ShootButton.SetActive(true);
            ShieldObj.SetActive(false);
        }
    }

    public void SwapToShield()
    {
        if (!ShieldObj.activeSelf)
        {
            GunObj.SetActive(false);
            ShootButton.SetActive(false);
            ShieldObj.SetActive(true);
        }
    }
}
