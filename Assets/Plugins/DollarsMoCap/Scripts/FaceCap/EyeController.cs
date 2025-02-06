using UnityEngine;

namespace Dollars
{
    public class EyeController : MonoBehaviour
    {
        public GameObject src;
        public Transform leftEye;
        public Transform rightEye;

        public axis HorizontalRotationAxis = new axis();
        public axis VerticalRotationAxis = new axis();

        public float LeftEyeOutMax;
        public float LeftEyeUpMax;
        public float RightEyeOutMax;
        public float RightEyeUpMax;

        FaceCapResult fcr;
        float filteredlookInRight, filteredlookOutRight, filteredlookUpRight, filteredlookDownRight;
        float filteredlookInLeft, filteredlookOutLeft, filteredlookUpLeft, filteredlookDownLeft;
        public enum axis // your custom enumeration
        {
            X,
            Y,
            Z
        };

        void Start()
        {
            fcr = src.GetComponent<FaceCapResult>();
        }

        // Update is called once per frame
        void Update()
        {
            filteredlookOutRight = fcr.values["EyeLookOutRight"];
            filteredlookInRight = fcr.values["EyeLookInRight"];
            filteredlookUpRight = fcr.values["EyeLookUpRight"];
            filteredlookDownRight = fcr.values["EyeLookDownRight"];
            filteredlookOutLeft = fcr.values["EyeLookOutLeft"];
            filteredlookInLeft = fcr.values["EyeLookInLeft"];
            filteredlookUpLeft = fcr.values["EyeLookUpLeft"];
            filteredlookDownLeft = fcr.values["EyeLookDownLeft"];

            float v_left, h_left, v_right, h_right;

            h_left = LeftEyeOutMax * (filteredlookOutLeft - filteredlookInLeft);
            v_left = LeftEyeUpMax * (filteredlookUpLeft - filteredlookDownLeft);

            h_right = RightEyeOutMax * (filteredlookOutRight - filteredlookInRight);
            v_right = RightEyeUpMax * (filteredlookUpRight - filteredlookDownRight);

            float rx_left, ry_left, rz_left, rx_right, ry_right, rz_right;
            if (HorizontalRotationAxis == axis.X)
            {
                rx_left = h_left;
                rx_right = h_right;
            }
            else if (VerticalRotationAxis == axis.X)
            {
                rx_left = v_left;
                rx_right = v_right;
            }
            else
            {
                rx_left = 0;
                rx_right = 0;
            }
            if (HorizontalRotationAxis == axis.Y)
            {
                ry_left = h_left;
                ry_right = h_right;
            }
            else if (VerticalRotationAxis == axis.Y)
            {
                ry_left = v_left;
                ry_right = v_right;
            }
            else
            {
                ry_left = 0;
                ry_right = 0;
            }
            if (HorizontalRotationAxis == axis.Z)
            {
                rz_left = h_left;
                rz_right = h_right;
            }
            else if (VerticalRotationAxis == axis.Z)
            {
                rz_left = v_left;
                rz_right = v_right;
            }
            else
            {
                rz_left = 0;
                rz_right = 0;
            }

            leftEye.localRotation = Quaternion.Euler(rx_left, ry_left, rz_left);
            rightEye.localRotation = Quaternion.Euler(rx_right, ry_right, rz_right);
        }
    }
}
