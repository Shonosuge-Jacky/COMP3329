using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace AnimeCharacter.Manager
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerInput PlayerInput;

        public Vector2 Move { get; private set;}
        public Vector2 Look { get; private set;}
        public bool Run { get; private set;}
        public bool Jump { get; private set;}

        public bool Attack { get; private set; }

        private InputActionMap _currentMap;
        private InputAction _moveAction;
        private InputAction _lookAction;
        private InputAction _runAction;
        private InputAction _JumpAction;
        private InputAction _AttackAction;


        private void Awake()
        {
            //HideCursor();
            _currentMap = PlayerInput.currentActionMap;
            _moveAction = _currentMap.FindAction("Move");
            _runAction = _currentMap.FindAction("Run");
            _JumpAction = _currentMap.FindAction("Jump");
            _AttackAction = _currentMap.FindAction("Attack");

            _moveAction.performed += onMove;
            _runAction.performed  += onRun;
            _JumpAction.performed += onJump;
            _AttackAction.performed += onAttack;

            _moveAction.canceled += onMove;
            _runAction.canceled  += onRun;
            _JumpAction.canceled += onJump;
            _AttackAction.canceled += onAttack;
        }

        private void HideCursor()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }


        private void onMove(InputAction.CallbackContext context)
        {
            Move = context.ReadValue<Vector2>();
        }

        private void onLook(InputAction.CallbackContext context)
        {
            Look = context.ReadValue<Vector2>();
        }

        private void onRun(InputAction.CallbackContext context)
        {
            Run = context.ReadValueAsButton();
        }

        private void onJump(InputAction.CallbackContext context)
        {
            Jump = context.ReadValueAsButton();
            Debug.Log(Jump);
        }

        private void onAttack(InputAction.CallbackContext context)
        {
            Attack = context.ReadValueAsButton();
        }

        private void OnEnable()
        {
            _currentMap.Enable();
        }

        private void OnDisable()
        {
            _currentMap.Disable();
        }
    }
}

