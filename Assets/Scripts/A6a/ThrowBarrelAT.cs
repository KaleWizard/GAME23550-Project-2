using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ThrowBarrelAT : ActionTask {

        public BBParameter<float> radiusBBP;
        public BBParameter<float> travelTimeBBP;
        public BBParameter<float> heightIncreaseBBP;

		static TestThrownBarrel barrelPrefab = null;

		protected override string OnInit() {
			
			if (barrelPrefab == null)
			{
                try
                {
                    barrelPrefab = Resources.Load<TestThrownBarrel>("Prefabs/Barrel");
                }
                catch 
				{ 
					return "No prefab with TestThrownBarrel was found in a Resources folder at Prefabs/Barrel"; 
				}
			}
			return null;
		}

		protected override void OnExecute() {
            Object.Instantiate(barrelPrefab, agent.transform.position, Quaternion.identity)
			.Init(
				ThrowableArea.GetRandomPoint(),
				radiusBBP.value,
				heightIncreaseBBP.value,
				travelTimeBBP.value);

			EndAction(true);
		}
	}
}