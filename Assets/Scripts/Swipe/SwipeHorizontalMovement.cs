using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeHorizontalMovement : MonoBehaviour
{
    public Swipe swipeControls;
    private Vector3 _desiredPosition;

    [SerializeField] private HorizontalMovement _horizontalMovement;
    
    private void Update()
    {
        if (swipeControls.SwipeLeft) 
            _horizontalMovement.HorizontalButtons(-1);
        if (swipeControls.SwipeRight) 
            _horizontalMovement.HorizontalButtons(+1);
        if (swipeControls.SwipeUp) 
            GameMenejer.instance.MuvePlayerOff();
    }
}
