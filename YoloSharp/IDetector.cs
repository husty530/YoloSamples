using System.Collections.Generic;
using OpenCvSharp;

namespace YoloSharp
{
    public enum Status { Initialized, NotInitialized }
    public interface IDetector
    {
        void InitializeDetector(string names, string cfg, string model, Size blobSize, float confThresh, float nmsThresh);
        (Mat OutputImg, List<Point> Centers, int[] Indices, List<float> Confidences, List<Rect2d> Boxes) Run(Mat inputImg);
    }
}
