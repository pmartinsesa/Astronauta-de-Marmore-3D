using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public CharacterController controller;
        public Animator animator;

        public float speed = 20f;
        public float turnSpeed = 250f;
        public float jumpForce = 25f;
        public float jumpLimit = 5f;

        public float gravity = 1f;

        private float _jumpCoeficient;
        private bool _isJumping;
        private float _groundPosition;

        private void Start()
        {
            _isJumping = false;
            _groundPosition = controller.transform.position.y;
        }

        private void Update()
        {
            var inputAxisVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            var inputAxisHorizontal = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
            var speedVector = controller.transform.forward * inputAxisVertical;

            if (controller.isGrounded)
                VerifyStartJump();

            JumpHandler();
            MovementHandler(inputAxisVertical, inputAxisHorizontal, speedVector);
        }

        private void VerifyStartJump()
        {
            _groundPosition = controller.transform.position.y;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isJumping = true;
            }
        }

        private void JumpHandler()
        {
            if (!_isJumping)
                return;

            if (Input.GetKey(KeyCode.Space))
            {
                _jumpCoeficient = jumpForce * Time.deltaTime;
            }

            if (Input.GetKeyUp(KeyCode.Space) || controller.transform.position.y > jumpLimit + _groundPosition)
            {
                _isJumping = false;
                _jumpCoeficient = 0;
            }
        }

        private void MovementHandler(float inputAxisVertical, float inputAxisHorizontal, Vector3 speedVector)
        {
            _jumpCoeficient -= gravity * Time.deltaTime;

            speedVector.y = _jumpCoeficient;

            controller.transform.Rotate(0, inputAxisHorizontal, 0);
            controller.Move(speedVector);

            animator.SetBool("isRunning", inputAxisVertical != 0);
        }
    }
}
