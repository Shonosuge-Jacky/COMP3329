using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimeCharacter.Manager;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Realtime;

namespace AnimeCharacter.PlayerControl
{
    public class NewPlayerController : MonoBehaviourPunCallbacks
    {
        [SerializeField] private float AnimeBlendSpeed = 8.9f;
        [SerializeField] private float UpperLimit = -40f;
        [SerializeField] private float bottomLimit = 70f;
        public Rigidbody _PlayerRigidbody;
        public GameObject _PlayerObject;
        private PlayerMovement _playermovement;
        private DestructibleP _destructibleP;
        private InputManager _inputManager;
        private Animator _animator;
        private bool _hasAnimator;
        private bool _grounded;
        private int _xVelHash;
        private int _yVelHash;
        private int _jumpHash;
        private int _groundHash;
        private int _fallingHash;

        private int _AttackHash;
        private int _deadHash; 
        public float sensX;
        public float sensY;
        float xRotation;
        float yRotation;

        private const float _walkSpeed = 2f;
        private const float _runSpeed = 4f;
        private Vector2 _currentVelocity;

        PhotonView PV;


        void Awake()
        {
            PV = GetComponent<PhotonView>();
        }

        private void Start()
        {
            if (!PV.IsMine)
            {

                Destroy(_PlayerRigidbody);
            }
            else
            {

                _PlayerRigidbody = _PlayerObject.GetComponentInParent<Rigidbody>();
                _inputManager = GetComponent<InputManager>();

                _playermovement = GetComponentInParent<PlayerMovement>();
                _destructibleP = GetComponentInParent<DestructibleP>();
                _xVelHash = Animator.StringToHash("X_velocity");
                _yVelHash = Animator.StringToHash("Y_velocity");
                _jumpHash = Animator.StringToHash("Jump");
                _groundHash = Animator.StringToHash("Grounded");
                _fallingHash = Animator.StringToHash("Falling");
                _AttackHash = Animator.StringToHash("IsAttacking");
                _deadHash = Animator.StringToHash("Dead");
            }

            _hasAnimator = TryGetComponent<Animator>(out _animator);

        }

        private void FixedUpdate()
        {
            if (!PV.IsMine)
                return;
            Move();
            HandleJump();
            Attack();
            Deadcheck();
        }

        private void Move()
        {
            if (!_hasAnimator) return;

            float targetSpeed = _inputManager.Run ? _runSpeed : _walkSpeed;
            if (_inputManager.Move == Vector2.zero) targetSpeed = 0f;

            _currentVelocity.x = Mathf.Lerp(_currentVelocity.x, targetSpeed * _inputManager.Move.x, AnimeBlendSpeed * Time.fixedDeltaTime);
            _currentVelocity.y = Mathf.Lerp(_currentVelocity.y, targetSpeed * _inputManager.Move.y, AnimeBlendSpeed * Time.fixedDeltaTime);

            var xVelDifference = _currentVelocity.x - _PlayerRigidbody.velocity.x;
            var zVelDifference = _currentVelocity.y - _PlayerRigidbody.velocity.z;

            //_PlayerRigidbody.AddForce(transform.TransformVector(new Vector3(xVelDifference, 0, zVelDifference)), ForceMode.VelocityChange);

            _animator.SetFloat(_xVelHash, _currentVelocity.x);
            _animator.SetFloat(_yVelHash, _currentVelocity.y);

        }

        private void Look()
        {
            if (!_hasAnimator) return;
            // get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            // rotate cam and orientation
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
            //Debug.Log(xRotation);
            //Debug.Log(yRotation);
        }

        private void HandleJump()
        {
            if (!_hasAnimator) return;
            if (!_inputManager.Jump)
            {
                _animator.ResetTrigger(_jumpHash);
                return;
            }
            _animator.SetTrigger(_jumpHash);
            
            
        }

        private void SampleGround()
        {

            if (!_hasAnimator) return;
            if (_playermovement.grounded)
            {
                _grounded = true;
                SetAnimationGrounding();

                return;
            }
            _grounded = false;
            SetAnimationGrounding();
            return;
        }

        private void SetAnimationGrounding()
        {
            _animator.SetBool(_fallingHash, !_grounded);
            _animator.SetBool(_groundHash, _grounded);
        }

        private void Attack()
        {
            if (!_hasAnimator) return;
            if (!_inputManager.Attack)
            {
                _animator.ResetTrigger(_AttackHash);
                return;
            }
            _animator.SetTrigger(_AttackHash);
            
        }

        private void Deadcheck()
        {
            if (!_hasAnimator) return;
            if (!_destructibleP.doDeadEffect)
            {
                _animator.SetBool(_deadHash, false);
                return;
            }
            _animator.SetBool(_deadHash, true);
        }
    }
}

