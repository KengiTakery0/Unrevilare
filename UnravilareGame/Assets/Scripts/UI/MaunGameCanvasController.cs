using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MaunGameCanvasController : MonoBehaviour
{
    [SerializeField] Animator _animator;
     PlayerInputActions _playerInput;
     PlayerInputActions.UIActions UIInput;
    bool isPausePanelActive = false;
    private readonly int Close = Animator.StringToHash("CLOSE");
    private readonly int Open = Animator.StringToHash("OPEN");

    private void Awake()
    {
        _playerInput = new PlayerInputActions();
        UIInput = _playerInput.UI;
    }
    private void OnEnable()
    {
       UIInput.Enable();
        
       UIInput.ActivatePausePanel.performed += ctx => ActivatePausePanel();
    }


    private void OnDisable()
    {
        UIInput.Disable(); 
    }
    public void ActivatePausePanel()
    {

        
        if (isPausePanelActive)
        {
            isPausePanelActive = false;
            _animator.SetTrigger(Close);
        }
        else if(!isPausePanelActive)
        {
            isPausePanelActive = true;
            _animator.SetTrigger(Open);
        }
        UIInput.ActivatePausePanel.performed += ctx => ActivatePausePanel();
    }



}
