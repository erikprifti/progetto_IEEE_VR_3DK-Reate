using UnityEngine;

namespace Mirror.Examples.Benchmark
{
    public class PlayerMovement : NetworkBehaviour
    {
        public float speed = 3;
        public CharacterController controller;
        public float gravity = -9.81f;

        Vector3 velocity;

        private void Start()
        {
            if (!isLocalPlayer) enabled = false;
        }

        void Update()
        {
            if (!isLocalPlayer) return;

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 move = (transform.right * h) + (transform.forward * v);
            

            controller.Move(speed * Time.deltaTime * move);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
