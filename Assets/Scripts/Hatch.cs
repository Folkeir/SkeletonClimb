using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hatch : MonoBehaviour
{
    [SerializeField]DOTweenAnimation openAnimation;
    [SerializeField]DOTweenAnimation closeAnimation;
    // Start is called before the first frame update
    
    public void OpenHatch()
    {
        openAnimation.DOPlay();
    }
    public void CloseHatch()
    {
       closeAnimation.DOPlay();
    }
}

