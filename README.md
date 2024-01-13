# 導入について
## 必要なPackage<br>
・Addressables<br>
・TextMesh Pro<br>
※UnityPackageを開く前に入れておくことを推奨<br>
<br>
## 導入手順<br>
Assets以下を自プロジェクトのAssets以下にコピー<br>
ないしはUnityPackage以下にあるPackageをImport<br>
<br>
## 導入後に必要なこと<br>
以下のフォルダをAddressables指定<br>
・Assets/SevensDwarfs/Data<br>
・Assets/SevensDwarfs/Prefabs<br>
<br>
# 機能について
一通り実装終わったらExample作る予定
## CrossingData<br>
ゲーム起動中に一時データの保管<br>
・PermanentData：起動中常に参照するデータ<br>
・TempoaryData：一度切りの受け渡しに使用するデータ<br>
<br>
## ObjectPool<br>
Unity標準ObjectPoolの簡易版Wrapper<br>
使うときはオブジェクトをアクティブにして使わなくなったら非アクティブにする動きを既定の動きにしている<br>
<br>
## Kamishibai<br>
画像をパカパカ切り替えるタイプの簡易版ADV機構<br>
メモリとかロード速度とかは一切気にしていないので気にする場合はちゃんとしたアセットを導入<br>
#### シナリオデータ<br>
&emsp;Assets/SevensDwarfs/Data/Kamishibai/Scenario以下にScenario{適当な数字}.assetの形式でデータを格納<br>
&emsp;ScriptableObjectはCreate->ScriptableObjects->Kamishibai->ScenarioObjectから作成可能<br>
&emsp;ScenarioDataListに1クリックごとのテキストとキャラ指定を記載する<br>
#### 立ち絵データ<br>
&emsp;Assets/SevensDwarfs/Data/Kamishibai/Character以下に{キャラクター名:CharacterName}_{表情名:FacialExpress}.pngの形式でデータを格納<br>
&emsp;シナリオデータのCharacterNameとFacialExpressに対応している<br>
&emsp;あまり大きい画像を置くと重いので程々に<br>
&emsp;立ち絵の表示サイズはMAXで600x700、比率を保ったまま高さでShrinkしている<br>
## Sound<br>
簡易版サウンド再生機構<br>
BGMとSEそれぞれ1枠ずつ再生が可能<br>
再生手順は下記<br>
1. Assets/SevensDwarfs/Data/Sound/BGM（SE）にmp3を配置しておく<br>
2. SoundController.prefabをシーンに配置（SoundUtility.LoadSoundController()から呼んでもOK）
3. ファイル名をstringで指定してPlayBGM()（PlaySE()）を呼び出し
ファイルの拡張子はSoundController.csを書き換えれば変更可能<br>
Singleでシーン管理することはないと思うがシーンアンロード時の非破壊対象にする対応は各自でやること<br>
<br>
## 今後の実装予定<br>
#### MasterData：使いづらいけどScriptableObjectでマスターデータ管理できるよくらいの機構<br>
#### Popup：汎用ポップアップダイアログ2サイズくらい<br>
#### SaveData：Serializableなクラスの内容をセーブデータとしてファイルに保存するためだけの機構<br>
