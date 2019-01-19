using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidgetsManager : MonoBehaviour
{

    

    private BaseWidget currentlySelected;

    private void Start()
    {
        //DefaultWidget.Activate();
        //currentlySelected = DefaultWidget;
    }

    public void ShowWidget(BaseWidget widget)
    {
        currentlySelected.Deactivate();
        currentlySelected = widget;
        currentlySelected.Activate();
    }
}
