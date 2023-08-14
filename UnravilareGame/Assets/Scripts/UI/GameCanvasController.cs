using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameCanvasController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Button _playButton;
    [SerializeField] Button _optionsButton;
    [SerializeField] Button _exitButton;

    PlayerInputActions _playerInput;
    InputAction UIInput;
    bool isPaused = false;

    private readonly int Close = Animator.StringToHash("CLOSE");
    private readonly int Open = Animator.StringToHash("OPEN");

    private void Awake()
    {
        _playerInput = new PlayerInputActions();
    }
    private void OnEnable()
    {
        UIInput = _playerInput.UI.ActivatePausePanel;
        UIInput.Enable();
        UIInput.performed += ctx => ActivatePause();
        _playButton.onClick?.AddListener(() => ActivatePause());
    }


    private void OnDisable()
    {
        UIInput.Disable();
        _playButton.onClick?.RemoveListener(() => ActivatePause());   
    }
    private void ActivatePause()
    {

        if (!isPaused)
        {
            isPaused = true;
            _animator.SetTrigger(Open);
        }
        else
        {
            isPaused = false;
              _animator.SetTrigger(Close);
        }

    }

    public void PauseGame()
    {
        AudioListener.pause = true;
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        AudioListener.pause = false;
        Time.timeScale = 1;
    }



}
