using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class TestNavigateToObjectAT : ActionTask {

		public BBParameter<CharacterControllerInput> controllerBBP;
		public BBParameter<NavMeshAgent> navAgentBBP;
		public BBParameter<GameObject> targetBBP;

		Vector3[] corners;
		int cornerCount;
		float tolerance = 0.25f;

		int targetCorner;

        protected override string OnInit()
        {
			corners = new Vector3[10];

            return null;
        }

		protected override void OnExecute() {
			if (targetBBP.value == null) EndAction(false);

			navAgentBBP.value.SetDestination(targetBBP.value.transform.position);

			cornerCount = navAgentBBP.value.path.GetCornersNonAlloc(corners);

			targetCorner = 0;
		}

		protected override void OnUpdate() {
			if (Vector3.Distance(agent.transform.position, corners[targetCorner]) < tolerance)
			{
				targetCorner++;
                if (targetCorner >= cornerCount)
                {
                    EndAction(true);
                    return;
                }
            }

			Vector3 direction = corners[targetCorner] - agent.transform.position;
			Vector2 input = (new Vector2(direction.x, direction.z)).normalized;
			controllerBBP.value.input = input;
		}
	}
}