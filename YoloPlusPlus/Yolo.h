#pragma once
#include <opencv2/opencv.hpp>
#include <opencv2/dnn.hpp>

typedef struct DLLEXPORT YoloResults {

	int count;
	std::vector<int> classIds;
	std::vector<cv::Point> centers;
	std::vector<float> confidences;
	std::vector<cv::Rect2d> boxes;

};

class DLLEXPORT Yolo
{

private:

	float _confThresh;
	float _nmsThresh;
	cv::Size _blob_size;
	std::vector<std::string> _labels;
	std::vector<cv::Scalar> _colors;
	cv::dnn::Net _net;
	void Process(cv::Mat& img, YoloResults& results);
	void DrawPoints(cv::Mat& img, YoloResults& results);
	void DrawRects(cv::Mat& img, YoloResults& results);
	void DrawRectsWithLabels(cv::Mat& img, YoloResults& results);

public:

	enum CUDA { On, Off };
	enum GraphicMode { None, Points, Boxes, BoxesWithLabels };
	void Init(const char* cfg, const char* names, const char* weights, cv::Size size = cv::Size(384, 288), float confThresh = 0.5, float nmsThresh = 0.3, CUDA cuda = Off);
	void Run(cv::Mat& img, YoloResults& results, GraphicMode mode = BoxesWithLabels);

};

