using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Button : MonoBehaviour
{
    [SerializeField] Spring _spring;
    [SerializeField] Hatch _hatch;
    [SerializeField] float buttonResetTime = 2;
    [SerializeField] bool hatchOpen = false;
    [SerializeField] bool spring = false;
    float currentResetTime;
    bool buttonResetting = false;
 
    DOTweenAnimation _animation;
   
    
    // Start is called before the first frame update
    void Start()
    {
        _animation = GetComponent<DOTweenAnimation>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (buttonResetting) { return; }
        if (spring)
        {
            _spring.SpringLoose();
            buttonResetting = true;
            _animation.DOPlay();
        }
        
        if (hatchOpen)
        {
            _hatch.OpenHatch();
        }

    }

    private void Update()
    {
        if (buttonResetting)
        {
            currentResetTime += Time.deltaTime;
            float deltaDReset = currentResetTime / buttonResetTime;
            if(deltaDReset > buttonResetTime)
            {
                buttonResetting = false;
                currentResetTime = 0;
            }
        }
    }

}
