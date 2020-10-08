#include <iostream>
#include <opencv2/opencv.hpp>
#include "Yolo.h"


int main()
{
    Yolo detector;
    detector.Init("D:\\YOLOv4\\yolov4.cfg", "D:\\YOLOv4\\coco.names", "D:\\YOLOv4\\yolov4.weights", cv::Size(384, 288), 0.5, 0.3);
    cv::Mat img = cv::imread("D:\\Sample.jpg");

    std::cout << "Image is loaded.\nPress any key." << std::endl;
    getchar();
    std::cout << "Procesing..." << std::endl;

    int count = 0;
    YoloResults results;
    detector.Run(img, &results);
    for (cv::Point center : results.centers)
    {
        std::cout << count << " : conf = " << (int)(results.confidences[count] * 100)
            << " center = (" << center.x << ", " << center.y << ")" << std::endl;
        count++;
    }

    std::cout << "Press 'q' key when you close window." << std::endl;
    bool loop = true;
    while(loop)
    {
        imshow("Detection Result", results.outputImg);
        if (cv::waitKey(1) == 113) loop = false;
    }

    std::cout << "Done!!" << std::endl;

}

