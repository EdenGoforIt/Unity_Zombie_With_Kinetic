using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;
using Joint = Windows.Kinect.Joint;

public class Detect2 : MonoBehaviour
{
    public BodySourceManager mBodySourceManager;
    public GameObject mJointObject;
    private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();
    private List<JointType> _joints = new List<JointType> {


        JointType.HandTipLeft,JointType.ThumbLeft,JointType.HandLeft,JointType.WristLeft,JointType.ElbowLeft,JointType.ShoulderLeft,JointType.HandTipRight,JointType.ThumbRight,JointType.HandRight,JointType.WristRight,JointType.ElbowRight,JointType.ElbowRight,JointType.ShoulderRight,
    };
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        Body[] data = mBodySourceManager.GetData();
        if (data == null)
        {
            return;
        }
        List<ulong> trackedIds = new List<ulong>();
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                trackedIds.Add(body.TrackingId);
            }
        }



        //delete body
        List<ulong> knownIds = new List<ulong>();

        foreach (var trackingId in knownIds)
        {
            if (!trackedIds.Contains(trackingId))
            {
                Destroy(mBodies[trackingId]);
                mBodies.Remove(trackingId);
            }

        }

        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                if (!mBodies.ContainsKey(body.TrackingId))
                {
                    mBodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                }

                UpdateBodyObject(body, mBodies[body.TrackingId]);
            }
        }
    }

    private GameObject CreateBodyObject(ulong id)
    {
        GameObject body = new GameObject("Body:" + id);

        foreach (JointType joint in _joints)
        {
            GameObject newJoint = Instantiate(mJointObject);
            newJoint.name = joint.ToString();

            newJoint.transform.parent = body.transform;
        }

        return body;
    }

    private void UpdateBodyObject(Body body, GameObject bodyObject)
    {
        foreach (JointType _joint in _joints)
        {
            Windows.Kinect.Joint  sourceJoint = body.Joints[_joint];
            Vector3 targetPosition = GetVector3FromJoint(sourceJoint);
            targetPosition.z = 0;
            Transform jointObject = bodyObject.transform.Find(_joint.ToString());
            jointObject.position = targetPosition;
        }
    }
     
    private static Vector3 GetVector3FromJoint(Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
    }
}
