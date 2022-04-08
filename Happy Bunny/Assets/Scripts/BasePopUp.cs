using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePopUp : MonoBehaviour
{
    // Start is called before the first frame update
    virtual public void Open()
    {

        if (!IsActive())
        {
            this.gameObject.SetActive(true);
            // Messenger.Broadcast(GameEvent.POPUP_OPENED);
        }
        else
        {
            Debug.Log(this + ".Open() - trying to open popup that is active!");
        }
    }

    public void Close()
    {
        if (IsActive())
        {
            gameObject.SetActive(false);
            // Messenger.Broadcast(GameEvent.POPUP_CLOSED);
        }
        else
        {
            Debug.Log(this + ".Close() - trying to close a popup that is already closed ");
        }

    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}