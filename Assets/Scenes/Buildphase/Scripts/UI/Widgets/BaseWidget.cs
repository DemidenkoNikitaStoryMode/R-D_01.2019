using UnityEngine;

public class BaseWidget : MonoBehaviour
{
    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
