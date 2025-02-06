using UnityEngine;

public class AvatarMuscle : MonoBehaviour
{

    private HumanPoseHandler poseHandler;

    private void Start()
    {
        poseHandler = new HumanPoseHandler(GetComponent<Animator>().avatar, transform);
    }

    private void LateUpdate()
    {
        var t = transform;
        var rootPosition = t.position;
        var rootRotation = t.rotation;
        t.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        var pose = new HumanPose();
        poseHandler.GetHumanPose(ref pose);
        t.SetPositionAndRotation(rootPosition, rootRotation);

        for (var i = 0; i < HumanTrait.MuscleName.Length; i++)
        {
            pose.muscles[i] = Mathf.Clamp(pose.muscles[i], -1f, 1f);
        }
        poseHandler.SetHumanPose(ref pose);
    }
}
