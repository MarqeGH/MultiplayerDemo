using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public UIMenu[] menus;

    private void Awake()
    {
        instance = this;
    }

    public void CloseMenu(UIMenu menu)
    {
        menu.Close();
    }

    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName)
                OpenMenu(menus[i]);
            else if (menus[i].menuName != menuName && menus[i].open)
                CloseMenu(menus[i]);
        }
    }

    public void OpenMenu(UIMenu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName != menu.menuName && menus[i].open)
                CloseMenu(menus[i]);
        }
        menu.Open();
    }
}