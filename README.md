# YoloSamples

---

## Contents
[CsApp](/CsApp)...C#で推論実行するアプリ  
[YoloSharp](/YoloSharp)...C#のYOLO推論ライブラリ  
[LabelingTool](/LabelingTool)...C#で作ったラベリング用のツールです  
[Yolov4.ipynb](/Yolov4.ipynb)...Google Colab用のノートブック  
[process.py](/process.py)...train-test-split用。Colabで使うと楽です。  

---
## Demo
1. [公式ページ](https://github.com/AlexeyAB/darknet)から"yolov4.cfg", "coco.names", "yolov4.weights"をダウンロード
2. CsAppをビルド
3. ダウンロードしたモデルのパスを書き込み、ボタンをポチポチ  
サンプル画像つけてますのでどうぞ。

---

## Training
#### ラベリング作業
Anaconda環境があれば、[labelImg](https://github.com/tzutalin/labelImg)が便利です。  
インストール法および使い方は[コチラ](https://www.miki-ie.com/python/labelimg-annotation-yolo-darknet/)から。  
pre-defined-classとYOLO/PascalVOCの設定を間違うとめっちゃ後悔します。  
最終的に画像名と同じだけ.txtファイルが出力されていればOK  
  
Anaconda環境の設定が面倒なら付属の[LabelingTool](/LabelingTool)でもできます(たぶん)。  

#### GoogleDriveの編集
Colabではドライブをマウントしてデータを扱います。  
以下、手順どおりに進めてください  
1. Yolov4.ipynbを開き、ドライブをマウントする
2. 1つ目のセルでドライブにYoloのリポジトリをクローンする
3. ここからドライブ内の作業。darknet/data/にフォルダを作成し、作成した画像およびラベルデータをすべて入れる
4. Makefile...GPU,CUDNN,CUDNN_HALF,OPENCVの数値を1に変える
5. cfg/yolov4-custom.cfg...subdivisions=32,max_batches=4000, steps=3200,3600などとし、さらに最後の方にある3つのyoloレイヤーでClasses=(クラス数)に、各yoloレイヤーの直前にあるconvolutionalレイヤーにてfilters=(クラス数+5)×3に変更する。入力サイズは自由に変えてもよいが32の倍数でないとエラーが出る。これを"yolov4-obj.cfgと名前をつけて保存。次に最初の方の2つのbatch,subdivisionのコメントアウトを入れ替えて"yolov4-obj-test.cfg"で保存する。
6. data/coco.names...自分が設定したクラスに書き換えてobj.namesとして保存
7. cfg/coco.data...こんな感じに↓ して、obj.dataと名前をつけdata/に保存。
```
classes= (クラス数)
train  = data/train.txt
valid  = data/test.txt
names = data/obj.names
backup = backup/
```
8. DEMOに書いた公式ページからdarknet/に”yolov4.conv.137”を入れる
9. [process.py](/process.py)内のフォルダ名を自分がデータを入れたドライブのフォルダ名にして、darknet/data/に入れる
10. ここからColab。まず"ランタイムの設定変更"からGPUを選択しておく
11. コンパイル → process.py(train-testの切り分け) → 学習(最初から)をポチポチするだけ。画面がザーッと流れ続けていたらうまくいっている。  
(2回目以降コンパイルがらみのエラーが出る場合はいったんdarknet.exeを消してコンパイルし直してください)  
12. 学習モデルは随時backup/フォルダに保存される。chart.pngも保存されるので学習経過を見ることもできる。  

---

## Testing
Demoと同じです。必要なファイルはyolov4-obj-test.cfg, obj.names, yolov4-obj_final.weights。  
これらを差し替えてCsAppから実行してみましょう。
