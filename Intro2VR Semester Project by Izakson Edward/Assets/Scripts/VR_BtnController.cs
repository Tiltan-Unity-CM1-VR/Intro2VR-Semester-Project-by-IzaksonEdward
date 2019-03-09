using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_BtnController : LookAtTarget
{
    public delegate void ButtonAction();
    public event ButtonAction OnButtonSelected;

    private void OnEnable()
    {
        InputManager.im_Instance.OnLongTouchEvent += CheckSelection;
    }

    private void OnDisable()
    {
        if (InputManager.im_Instance!=null)
        {
            InputManager.im_Instance.OnLongTouchEvent -= CheckSelection; 
        }
    }

    void CheckSelection()
    {
        if (_isLookingAtMe)
        {
            if (OnButtonSelected!=null)
            {
                OnButtonSelected();
            }
        }
    }
}
