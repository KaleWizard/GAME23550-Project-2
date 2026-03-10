using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    public class DynamicColorChangeAT : ActionTask
    {
        public BBParameter<Transform> target;
        public BBParameter<Renderer> renderer;
        public BBParameter<Color> defaultColor;
        public BBParameter<Color> targetColor;

        protected override void OnUpdate()
        {
            // The hardcoded math is to allow for a stopping distance of 1.25 and still achieve full color change.
            // Ugly, but it's just a demo.
            float interpolant = 1 - (Vector3.Distance(target.value.position, agent.transform.position) - 1.25f) / 7f;

            Color steppedColor = Color.Lerp(defaultColor.value, targetColor.value, interpolant);
            renderer.value.material.color = steppedColor;
        }
    }
}