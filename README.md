# 用途
unity1week等のゲームジャムでそこそこ使うだろう簡易機能の寄せ集め<br>
「作ろうと思えばすぐ作れるけど毎回作るのもなぁ…」というときにどうぞ<br>
<br>
あくまで短期間でのゲーム制作に注力するための補助なので<br>
ちゃんと作りこむ場合にはちゃんとしたライブラリやアセットを使用すること<br>
# 導入について
## 必要なPackage
・Addressables<br>
・TextMesh Pro<br>
※UnityPackageを開く前に入れておくことを推奨<br>
<br>
## 導入手順
Assets以下を自プロジェクトのAssets以下にコピー<br>
ないしはUnityPackage以下にあるPackageをImport<br>
<br>
## 導入後に必要なこと
以下のフォルダをAddressables指定<br>
・Assets/SevensDwarfs/Data<br>
・Assets/SevensDwarfs/Prefabs<br>
メニューバーからSevenDwarfs->Prepare Empty Directoriesを実行
<br>
# 機能について
一通り実装終わったらExample作る予定
## CrossingData<br>
ゲーム起動中に一時データの保管<br>
・PermanentData：起動中常に参照するデータ<br>
・TempoaryData：一度切りの受け渡しに使用するデータ<br>
<br>
## ObjectPool
Unity標準ObjectPoolの簡易版Wrapper<br>
使うときはオブジェクトをアクティブにして使わなくなったら非アクティブにする動きを既定の動きにしている<br>
<br>
## Kamishibai
画像をパカパカ切り替えるタイプの簡易版ADV機構<br>
メモリとかロード速度とかは一切気にしていないので気にする場合はちゃんとしたアセットを導入<br>
#### シナリオデータ
&emsp;Assets/SevensDwarfs/Data/Kamishibai/Scenario以下にScenario{適当な数字}.assetの形式でデータを格納<br>
&emsp;ScriptableObjectはCreate->ScriptableObjects->Kamishibai->ScenarioObjectから作成可能<br>
&emsp;ScenarioDataListに1クリックごとのテキストとキャラ指定を記載する<br>
#### 立ち絵データ
&emsp;Assets/SevensDwarfs/Data/Kamishibai/Character以下に{キャラクター名:CharacterName}_{表情名:FacialExpress}.pngの形式でデータを格納<br>
&emsp;シナリオデータのCharacterNameとFacialExpressに対応している<br>
&emsp;あまり大きい画像を置くと重いので程々に<br>
&emsp;立ち絵の表示サイズはMAXで600x700、比率を保ったまま高さでShrinkしている<br>
## Sound
簡易版サウンド再生機構<br>
BGMとSEそれぞれ1枠ずつ再生が可能<br>
再生手順は下記<br>
1. Assets/SevensDwarfs/Data/Sound/BGM（SE）にmp3を配置しておく<br>
2. SoundController.prefabをシーンに配置（SoundUtility.LoadSoundController()から呼んでもOK）
3. ファイル名をstringで指定してPlayBGM()（PlaySE()）を呼び出し

ファイルの拡張子はSoundController.csを書き換えれば変更可能<br>
Singleでシーン管理することはないと思うがシーンアンロード時の非破壊対象にする対応は各自でやること<br>
## Popup
簡単なメッセージ表示用のポップアップダイアログ<br>
Assets/SevensDwarfs/Prefabs/Popup/PopupCanvas.prefabの各ImageにSpriteを設定して使用<br>
&emsp;背景画像は400x200、閉じるボタンは100x100で用意<br>
背景画像はAssets/SevensDwarfs/Data/Popup/以下に置いておけばランタイムでもロード可能<br>
&emsp;閉じるボタンはゲーム中に差し替えるケースが少ないためPrefabからのみ設定可能<br>
## MasterData
ScriptableObject形式のマスターデータ機構<br>
ちゃんとしたマスターデータ機構を導入できる余裕があるならこちらは使わずそちらを優先すべき<br>
作成・利用手順は下記<br>
1. Assets/SevensDwarfs/Scripts/MasterData/RecordClassesにMasterRecordBaseを継承したSerializableクラスを定義<br>
2. Unity上部のメニューバーからSevenDwarfs->Generate MasterData Scriptsを実行して関連クラスを自動生成<br>
3. CreateAssetメニューのSevenDwarfs->MasterDataに追加したSerializableクラスと同名の項目が増えてるので作成<br>
4. 手順3で作成したファイルをAssets/SevensDwarfs/Editor/MasterData/Data/{クラス名}ができているのでその下に配置<br>
5. 1レコードにつき1Scriptableの要領で量産<br>
6. Unity上部のメニューバーからSevenDwarfs->Compress MasterDataを実行して実際に使用するデータを出力<br>
7. MasterDataManagerクラスを使用してマスターデータを取得<br>

Editorからエクセル感覚で触るのは非エンジニアがつらい，<br>
量産したScriptableObjectをランタイムで全部拾ってくるのは処理がつらい，<br>
という思想で元データと出力データの関係性は意図的に切っている<br>
SharrowCopyしてるだけなので参照型を組み込まれるとダメ<br>

## SaveData
インスタンスをjsonにしてbyte列にして暗号化して保存して，<br>
読み込んで復号して元のインスタンスに戻す機構<br>
JsonUtilityで取り扱えないクラスのインスタンスは対応していない<br>
