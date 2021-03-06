# YoloSamples -- C++ and C# --
  
---
  
# Contents  
  
[CppApp](/CppApp) ... C++で推論実行するアプリ。デバッグ用なので中身はカス。  
[YoloPlusPlus](/YoloPlusPlus) ... C++の推論ライブラリ。  
[YoloLibrary](/YoloLibrary) ... C++のコンパイル済みライブラリ。  
[CsApp](/CsApp) ... C#で推論実行するアプリ。すぐできます。  
[YoloSharp](/YoloSharp) ... C#のYOLO推論ライブラリ。  
[coco.names](/coco.names), [yolov4.cfg](/yolov4.cfg) ... モデルファイル3点セット中の2つ。weightsだけは重たいので各自ダウンロード  
[LabellingTool](/LabellingTool) ... C#で作ったラベリング用のツール  
[Yolov4.ipynb](/Yolov4.ipynb) ... Google Colab用のノートブック  
[process.py](/process.py) ... train-test-split用。Colabで使うと楽です。  
  
---  
  
# Preparation
* Windows10
* VisualStudio2019 -- .NETデスクトップ開発、C++デスクトップ開発
* Googleアカウント(学習時にDriveとColabを使います)  
* 画像(お好みで)  
  
--- 
  
# About "YOLO"  
[本家のサイト](https://pjreddie.com/darknet/)を見ていただくのが最も早いかと。  
あるいは、今回用いるものはほとんど[AlexeyAB氏リポジトリ](https://github.com/AlexeyAB/darknet)から拝借しておりますので、詳しい部分はそちらを参照ください。  
  
すごく雑に言うと、YOLOとは物体検出手法の一種で、もともとdarknetというCで書かれたフレームワークで動くものです。  
それをこの度はC++およびC#からOpenCVのDNNモジュールで動かす、というコンセプトになっております。  
本当にOpenCV様の底力には頭が上がりませぬ。  
ネットの情報ではJupyterNotebookで動かすものがほとんどですが、C系の言語に組み込むのが意外と苦悶するところだと思ったのでこのようなものを公開しました。  
  
いくつかサンプルをつけました。何も設定しなくても動くのはC#のやつなので、すぐに動かして遊びたい方はC#からご利用ください。  
  
---
  
# Demo(C#)   
  
1. [yolov4.weights](https://github.com/AlexeyAB/darknet/releases/download/darknet_yolo_v3_optimal/yolov4.weights)をダウンロード  
2. names, cfg, weightsの3点セットをどこかしらに置いて、VisualStudioにて"CsApp"を"デバッグ"
3. テキストボックスにパスを書き込み、ボタンをポチポチ。チョーカンタン！  
  
動画でやりたい場合は推論をループで呼びだしてください。  
サンプル画像つけてますのでどうぞ。  
  
![Sample](/Sample.jpg)  
  
うまくいけばこんな感じ↓  
  
![csSample](/csSample.png)
  
---  
  
# Demo(C++)  
  
1. [yolov4.weights](https://github.com/AlexeyAB/darknet/releases/download/darknet_yolo_v3_optimal/yolov4.weights)をダウンロード  
2. "[ココ](https://swallow-incubate.com/archives/blog/20200508/)"や"[ココ](https://kamino.hatenablog.com/entry/opencv_contrib_install)"を参考にopencv-contribをビルドする。  
　(CMakeを推奨。しかしこれがダルイ...)  
　(どうやらバージョン依存があるようなので4.4.0を使うようにしてください)  
3. 環境変数の設定、インクルードディレクトリやリンカーの追加も上記のページを参考に行う。
4. VisualStudioにて"YoloPlusPlus"をビルド  
　(コンパイル済みのYoloLibraryを追加しました。これの.dll, .lib, .hの場所さえ指定すればできそう)  
　(.dll → exeと同じ階層、.lib → 追加の依存ライブラリ、.h → 追加のインクルードディレクトリでパスを通す)  
　(動作確認はとれていません。読めない場合は各々の環境で再ビルドを。)  
5. "CppApp"を開く  
6. 画像のパス、モデルファイル(coco.names, yolov4.cfg, yolov4.weights)は必要に応じてコード内で指定する。  
  
呼び出す関数は2つだけですが、それぞれオプションがあります。  
```
void Init(const char* cfg, 
          const char* names, 
          const char* weights, 
          cv::Size size = cv::Size(384, 288), 
          float confThresh = 0.5, 
          float nmsThresh = 0.3, 
          CUDA cuda = Off);
```
第4引数以下はオプションです。BlobSizeは32の倍数ならだいたい何でもいいようです。  
enum型のCUDAはOn or Offです。環境に合わせて変えてください。  
  
```
void Run(cv::Mat& img, YoloResults& results, GraphicMode mode = BoxesWithLabels);
```
GraphicModeはNone, Points, Boxes, BoxesWithLabels の4種類です。画像の出力の仕方を選べるようにしました。  
どれを選んでも中心と矩形の座標、クラスラベルといった数値の情報はすべて返ってきます(構造体YoloResultsに格納)。  
基本的に参照でやりとりするので引数さえ揃えればOKな仕様にしています。
  
動画でやりたい場合は推論をループで呼びだしてください。  
サンプル画像つけてますのでどうぞ。  
  
![cppSample](/cppSample.png)  
  
---  
  
# How To Train  
  
### ラベリング作業  
  
Anaconda環境があれば、"[labelImg](https://github.com/tzutalin/labelImg)"が便利です。  
インストール法および使い方は[コチラ](https://www.miki-ie.com/python/labelimg-annotation-yolo-darknet/)から。  
"pre-defined-class"と"YOLO/PascalVOC"の設定を間違うとめっちゃ後悔します。  
最終的に画像名と同じ.txtファイルが出力されていればOK。  
  
Anaconda環境の設定が面倒なら付属の"[LabellingTool](/LabelingTool)"でもできます。C#で動いています。  
LabellingToolディレクトリ内の"classes.txt"を事前に編集すれば自由にクラスラベルを変えられます。  
キー操作は全部左手におさまるようにしました。(A = Back, D = Next, S = Save, C = Clear, X = Undo)  
本家の機能のミニマムをとった感じで、シンプルな使い勝手なのではないでしょうか(感想)。  
  
![labellingtool](/labellingtool.png)  
  
### GoogleDriveの編集およびGoogleColabの操作  
  
Colabではドライブをマウントしてデータを扱います。  
以下、手順どおりに進めてください。  
  
1. GoogleColabolatoryにて"[Yolov4.ipynb](/Yolov4.ipynb)"を開き、自分のドライブをマウントする
2. 1つ目のセルでドライブにAlexeyAB/darknetのリポジトリをクローンする
3. ここからドライブ内の作業。"darknet/data/"にフォルダを作成し、作成した画像およびラベルデータをすべて入れる
4. "Makefile" ... GPU,CUDNN,CUDNN_HALF,OPENCVの数値を1に変える
5. "cfg/yolov4-custom.cfg" ... subdivisions=32,max_batches=4000, steps=3200,3600などとし、さらに最後の方にある3つのyoloレイヤーでClasses=(クラス数)に、各yoloレイヤーの直前にあるconvolutionalレイヤーにて"filters=(クラス数+5)×3"に変更する。入力サイズは自由に変えてもよいが32の倍数でないとエラーが出る。これを"yolov4-obj.cfg"と名前をつけて保存。次に最初の方の2つのbatch,subdivisionのコメントアウトを入れ替えて"yolov4-obj-test.cfg"で保存する。
6. "data/coco.names" ... 自分が設定したクラスに書き換えて"obj.names"として保存  
  
7. "cfg/coco.data" ... こんな感じ ↓ にして、"obj.data"と名前をつけ"data/"に保存。
```
classes= (クラス数)
train  = data/train.txt
valid  = data/test.txt
names = data/obj.names
backup = backup/
```  
  
8. Demoに書いた公式ページから"darknet/"に”yolov4.conv.137”を入れる
9. "[process.py](/process.py)"内のフォルダ名を自分がデータを入れたドライブのフォルダ名にして、"darknet/data/"に入れる
10. ここからColab。まず"ランタイムの設定変更"から"GPU"を選択しておく
11. コンパイル → "process.py"(train-testの切り分け) → 学習(最初から)をポチポチするだけ。画面がザーッと流れ続けていたらうまくいっている。  
(2回目以降コンパイルがらみのエラーが出る場合はいったん"darknet.exe"を消してコンパイルし直してください)  
12. 学習モデルは随時"backup/"フォルダに保存される。"chart.png"も保存されるので学習経過を見ることもできる。  
  
---
  
# How To Test  
  
Demoと同じです。必要なファイルは"yolov4-obj-test.cfg", "obj.names", "yolov4-obj_final.weights"。  
これらを差し替えてアプリケーションを実行してみましょう。  
  
変更箇所  
* "CppApp" ... コードの中("CppApp.cpp")でモデルのパスおよび"BlobSize"(任意)を編集。
* "CsApp" ... フォーム上ですべて設定。 →　"Init"ボタンでロード。
