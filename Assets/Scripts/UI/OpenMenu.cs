using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject openMenu;
    public GameObject closeMenu;

    public void OpenMenuButton()
    {
        openMenu.SetActive(true);
        closeMenu.SetActive(false);
    }
}
