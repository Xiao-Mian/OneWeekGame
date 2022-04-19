using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    InputController _playerInput;
    Movement _movement;
    public GameManger _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<Movement>();
        
        _playerInput = new InputController();
        _playerInput.PlayerMap.Jump.performed += c => _movement.Jump();
        _playerInput.PlayerMap.Pause.performed += c => _gameManager.PauseGame();
        _playerInput.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        _movement.Move(_playerInput.PlayerMap.Move.ReadValue<float>());
    }
}
