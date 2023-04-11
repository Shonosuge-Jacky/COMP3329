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
        private InputManager _inputManager;
        private Animator _animator;
        private bool _hasAnimator;
        private int _xVelHash;
        private int _yVelHash;

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

                _xVelHash = Animator.StringToHash("X_velocity");
                _yVelHash = Animator.StringToHash("Y_velocity");
            }

            _hasAnimator = TryGetComponent<Animator>(out _animator);

        }

        private void FixedUpdate()
        {
            if (!PV.IsMine)
                return;
            Move();
            Look();
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
            _PlayerObject.transform.Rotate(xRotation, yRotation, 0);
            Debug.Log(xRotation);
            Debug.Log(yRotation);
        }
        }
    }

