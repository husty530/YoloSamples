#define DLLEXPORT __declspec(dllimport)

#include <iostream>
#include <opencv2/opencv.hpp>
#include "Yolo.h"

int main()
{
    Yolo detector;
    detector.Init("D:\\YOLOv4\\yolov4.cfg", "D:\\YOLOv4\\coco.names", "D:\\YOLOv4\\yolov4.weights");
    cv::Mat img = cv::imread("D:\\Sample.jpg");

    std::cout << " Image is loaded.\n Press any key." << std::endl;
    getchar();
    std::cout << " Procesing...\n" << std::endl;

    
    YoloResults results;
    detector.Run(img, results);

    int count = 0;
    for (cv::Point center : results.centers)
    {
        std::cout <<"  "<< count << " : confidence = " << (int)(results.confidences[count] * 100)
            << "%  center = (" << center.x << ", " << center.y << ")" << std::endl;
        count++;
    }

    std::cout << " Press 'q' key when you close window.\n" << std::endl;
    bool loop = true;
    while(loop)
    {
        imshow(" Detection Result", img);
        if (cv::waitKey(1) == 113) loop = false;
    }

    std::cout << "\n ... Finish!!" << std::endl;

}

