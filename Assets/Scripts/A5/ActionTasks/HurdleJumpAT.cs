using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Services;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class HurdleJumpAT : ActionTask {

        public BBParameter<float> jumpVelocityBBP;
        Rigidbody rb;

        protected override string OnInit()
        {
            rb = agent.GetComponent<Rigidbody>();
            if (rb == null)
                return $"{agent.name} needs a RigidBody component!";

            return null;
        }

        protected override void OnExecute() {
            QueueJump();
            EndAction(true);
		}

        // Black magic to make the jump action happen in FixedUpdate
        void QueueJump()
        {
            MonoManager.current.onFixedUpdate += FixedUpdateJump;
        }

        void FixedUpdateJump()
        {
            Vector3 jumpVelocity = jumpVelocityBBP.value * agent.transform.up.normalized;
            rb.AddForce(jumpVelocity, ForceMode.VelocityChange);

            MonoManager.current.onFixedUpdate -= FixedUpdateJump;
        }
	}
}