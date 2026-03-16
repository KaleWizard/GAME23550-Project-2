using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class HurdleRaceStartedCT : ConditionTask {

		public BBParameter<bool> raceStartedBBP;

		protected override bool OnCheck() {
			return raceStartedBBP.value;
		}
	}
}