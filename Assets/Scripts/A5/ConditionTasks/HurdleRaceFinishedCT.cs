using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class HurdleRaceFinishedCT : ConditionTask {

        public BBParameter<bool> raceFinishedBBP;

		protected override bool OnCheck() {
			return raceFinishedBBP.value;
		}
	}
}