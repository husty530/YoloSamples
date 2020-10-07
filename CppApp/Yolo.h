#include <opencv2/opencv.hpp>
#include <opencv2/dnn.hpp>

typedef struct YoloResults {

	cv::Mat outputImg;
	std::vector<cv::Point> centers;
	std::vector<float> confidences;
	std::vector<cv::Rect2d> boxes;

};

class Yolo{

private:

	float _confThresh;
	float _nmsThresh;
	cv::Size _blob_size;
	std::vector<std::string> _labels;
	std::vector<cv::Scalar> _colors;
	cv::dnn::Net _net;

public:

	void Init(const char* cfg, const char* names, const char* weights, cv::Size size, float confThresh, float nmsThresh);
	YoloResults Run(cv::Mat img);

};


