using UnityEngine;

namespace Mirror.Examples.Benchmark
{
    public class PlayerMovement : NetworkBehaviour
    {
        public float speed = 5;
        public CharacterController controller;

        void Update()
        {
            if (!isLocalPlayer) return;

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 move = (transform.right * h) + (transform.forward * v);
            

            controller.Move(speed * Time.deltaTime * move);  
        }
    }
}
