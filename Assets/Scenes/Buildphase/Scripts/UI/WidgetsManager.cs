using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidgetsManager : MonoBehaviour
{

    public BaseWidget defaultWidget;

    public BaseWidget currentlySelected;

    public List<BaseWidget> widgets;

    private void Start()
    {
        
    }

    /*private T ShowWidget<T>() where T : BaseWidget
    {
        T window = null;

        for (int i = 0; i < widgets.Count; i++)
        {
            if (widgets[i].GetType() == typeof(T))
            {
                window = (T)widgets[i];
            }
        }

        //return window;
    }*/
}
