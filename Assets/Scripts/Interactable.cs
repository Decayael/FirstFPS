using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InterActable : MonoBehaviour
{
    //message that is displayed when player looks at a interactable
    public string promptMessage;
    
    //this function will be called from player
    public void BaseInteract() 
    {
        Interact();
    }
    protected virtual void Interact() 
    {
    //we won't have any code written in this function
    //it'll be overwritten by our subclasses
    }
}
