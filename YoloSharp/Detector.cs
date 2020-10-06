using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using OpenCvSharp;
using OpenCvSharp.Dnn;

namespace YoloSharp
{
    public class Detector : IDetector
    {
        //Field
        private Net _net;
        private float _threshold;
        private float _nmsThreshold;
        private static string[] _labels;
        private static Status _status = Status.NotInitialized;

        //Property
        private static readonly Scalar[] Colors = Enumerable.Repeat(false, 80).Select(x => Scalar.RandomColor()).ToArray();
        private static Size BlobSize { set; get; }

        //Method
        public void InitializeDetector(string cfg, string names, string weights, Size blobSize, float confThresh, float nmsThresh)
        {
            BlobSize = blobSize;
            _threshold = confThresh;
            _nmsThreshold = nmsThresh;
            _labels = File.ReadAllLines(names).ToArray();
            _net = CvDnn.ReadNetFromDarknet(cfg, weights);
            _net.SetPreferableBackend(Net.Backend.OPENCV);
            _net.SetPreferableTarget(Net.Target.CPU);
            _status = Status.Initialized;
        }

        public (Mat OutputImg, List<Point> Centers, int[] Indices, List<float> Confidences, List<Rect2d> Boxes) Run(Mat inputImg)
        {
            if (_status == Status.NotInitialized) throw new ApplicationException("Detector is not Initialized yet!");
            var blob = CvDnn.BlobFromImage(inputImg, 1.0 / 255, BlobSize, new Scalar(), true, false);
            _net.SetInput(blob);
            var outNames = _net.GetUnconnectedOutLayersNames();
            var outs = outNames.Select(_ => new Mat()).ToArray();
            _net.Forward(outs, outNames);
            return GetResult(outs, inputImg, _threshold, _nmsThreshold);
        }

        private static (Mat, List<Point>, int[], List<float>, List<Rect2d>) GetResult(IEnumerable<Mat> output, Mat image, float threshold, float nmsThreshold)
        {
            var centers = new List<Point>();
            var classIds = new List<int>();
            var confidences = new List<float>();
            var probabilities = new List<float>();
            var boxes = new List<Rect2d>();
            var selectedBoxes = new List<Rect2d>();
            var w = image.Width;
            var h = image.Height;
            foreach (var prob in output)
            {
                for (var i = 0; i < prob.Rows; i++)
                {
                    var confidence = prob.At<float>(i, 4);
                    if (confidence > threshold)
                    {
                        Cv2.MinMaxLoc(prob.Row(i).ColRange(5, prob.Cols), out _, out Point max);
                        var classes = max.X;
                        var probability = prob.At<float>(i, classes + 5);

                        if (probability > threshold)
                        {
                            var centerX = prob.At<float>(i, 0) * w;
                            var centerY = prob.At<float>(i, 1) * h;
                            var width = prob.At<float>(i, 2) * w;
                            var height = prob.At<float>(i, 3) * h;
                            classIds.Add(classes);
                            confidences.Add(confidence);
                            probabilities.Add(probability);
                            boxes.Add(new Rect2d(centerX, centerY, width, height));
                        }
                    }
                }
            }

            CvDnn.NMSBoxes(boxes, confidences, threshold, nmsThreshold, out int[] indices);
            foreach (var i in indices)
            {
                var box = boxes[i];
                selectedBoxes.Add(box);
                centers.Add(new Point(box.X, box.Y));
                Draw(image, classIds[i], confidences[i], probabilities[i], box.X, box.Y, box.Width, box.Height);
            }
            return (image, centers, indices, confidences, selectedBoxes);
        }

        private static void Draw(Mat image, int classes, float confidence, float probability, double centerX, double centerY, double width, double height)
        {
            var label = $" {_labels[classes]} {probability * 100:0.00}%";
            Console.WriteLine($"confidence {confidence * 100:0.00}% , {label}");
            var x1 = (centerX - width / 2) < 0 ? 0 : centerX - width / 2;
            image.Rectangle(new Point(x1, centerY - height / 2), new Point(centerX + width / 2, centerY + height / 2), Colors[classes], 1);
            var textSize = Cv2.GetTextSize(label, HersheyFonts.HersheyTriplex, 0.3, 0, out var baseline);
            Cv2.Rectangle(image, new Rect(new Point(x1, centerY - height / 2 - textSize.Height - baseline),
                new Size(textSize.Width, textSize.Height + baseline)), Colors[classes], Cv2.FILLED);
            var textColor = Cv2.Mean(Colors[classes]).Val0 < 70 ? Scalar.White : Scalar.Black;
            Cv2.PutText(image, label, new Point(x1, centerY - height / 2 - baseline), HersheyFonts.HersheyTriplex, 0.3, textColor);
        }
    }
}
