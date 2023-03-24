using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeHorizontalMovement : MonoBehaviour
{
    [SerializeField] private Swipe _swipeControls;
    private Vector3 _desiredPosition;

    [SerializeField] private HorizontalMovement _horizontalMovement;
    [SerializeField] private MovementButtons _movementButtons;
    
    private void Update()
    {
        if (_swipeControls.SwipeLeft) 
            _horizontalMovement.HorizontalButtons(-1);
        if (_swipeControls.SwipeRight) 
            _horizontalMovement.HorizontalButtons(+1);
        if (_swipeControls.SwipeUp)
        {
            gameObject.SetActive(false);
            _movementButtons.ButtonsMovement();
            GameMenejer.instance.MuvePlayer();
        }
    }
}
