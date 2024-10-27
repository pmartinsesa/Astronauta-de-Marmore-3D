using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerManager : MonoBehaviour
    {
        [Header("States")]
        public CharacterController controller;
        public Animator animator;

        public float speed;
        public float turnSpeed;
        public float jumpForce;
        public float jumpLimit;

        public float gravity;

        private float jumpCoeficient;
        private bool isJumping;
        private float groundPosition;
        private void Start()
        {
            isJumping = false;
            groundPosition = controller.transform.position.y;
        }

        private void Update()
        {
            var inputAxisVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            var inputAxisHorizontal = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

            var speedVector = controller.transform.forward * inputAxisVertical;


            if (controller.isGrounded)
            {
                groundPosition = controller.transform.position.y;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isJumping = true;
                }
            }

            if (isJumping)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    jumpCoeficient = jumpForce * Time.deltaTime;
                }

                if (Input.GetKeyUp(KeyCode.Space) || controller.transform.position.y > jumpLimit + groundPosition)
                {
                    isJumping = false;
                    jumpCoeficient = 0;
                }
            }

            jumpCoeficient -= gravity * Time.deltaTime;

            speedVector.y = jumpCoeficient;

            controller.transform.Rotate(0, inputAxisHorizontal, 0);
            controller.Move(speedVector);

            animator.SetBool("isRunning", inputAxisVertical != 0);
        }
    }
}
