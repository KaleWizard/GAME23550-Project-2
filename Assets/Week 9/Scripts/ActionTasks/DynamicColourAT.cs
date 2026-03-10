using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.Mathematics;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DynamicColourAT : ActionTask {

		public BBParameter<Renderer> rendererBBP;
		public BBParameter<Transform> targetBBP;

		public Color fromColor = Color.white;
		public Color toColor = Color.red;

		public float minDistance = 2f;

		protected override void OnExecute() {
		}

		protected override void OnUpdate() 
		{
			float dist = Vector3.Distance(targetBBP.value.position, agent.transform.position);

			dist = Mathf.Clamp(dist, 0, minDistance);

			float ratio = math.remap(0, minDistance, 0, 1, dist);

			rendererBBP.value.material.color = Color.Lerp(fromColor, toColor, ratio);
		}
	}
}