#if CINEMACHINE_TIMELINE

using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Cinemachine.ECS_Hybrid;

//namespace Cinemachine.ECS_Hybrid
//{
    /// <summary>
    /// Internal use only.  Not part of the public API.
    /// </summary>
    public sealed class CM_TimelineShot : PlayableAsset, IPropertyPreview
    {
        public ExposedReference<CM_VcamBase> VirtualCamera;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<CM_TimelineShotPlayable>.Create(graph);
            playable.GetBehaviour().VirtualCamera = VirtualCamera.Resolve(graph.GetResolver());
            return playable;
        }

        // IPropertyPreview implementation
        public void GatherProperties(PlayableDirector director, IPropertyCollector driver)
        {
            driver.AddFromName<Transform>("m_LocalPosition.x");
            driver.AddFromName<Transform>("m_LocalPosition.y");
            driver.AddFromName<Transform>("m_LocalPosition.z");
            driver.AddFromName<Transform>("m_LocalRotation.x");
            driver.AddFromName<Transform>("m_LocalRotation.y");
            driver.AddFromName<Transform>("m_LocalRotation.z");

            driver.AddFromName<Camera>("field of view");
            driver.AddFromName<Camera>("near clip plane");
            driver.AddFromName<Camera>("far clip plane");
        }
    }
//}
#endif
