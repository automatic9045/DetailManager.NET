# リポジトリ詳説
プラグインの開発方法は[リリース詳説](Release.md)をご覧ください。

## フォルダ構成

```
├ DetailManagerNET
├ DetailManagerNET.PluginHost
│
├ Plugins
│ ├ _DummyTrain
│ │
│ ├ Libraries
│ │ ├ x64
│ │ └ x86
│ │
│ ├ PluginTemplates
│ │ ├ Basic
│ │ └ DynamicTexture
│ │
│ └ SamplePlugins
│   ├ Alert
│   ├ DynamicTexture
│   └ SimpleAts
│
├ DetailManagerNET.sln
└ Readme.md
```

### DetailManagerNET

メインのプロジェクトです。  
ビルド時に`Plugins/Libraries/(x64 or x86)/DetailManagerNET.dll`へ自動配置します。

### DetailManagerNET.PluginHost

プラグインに公開するクラス・構造体や、プラグインの基底となるインターフェースを提供するプロジェクトです。  
ビルド時に`Plugins/Libraries/DetailManagerNET.PluginHost.dll`へ自動配置します。

**プラグイン開発時は、このプロジェクトではなく`Plugins/Libraries/DetailManagerNET.PluginHost.dll`を参照に追加してください。**

### Plugins/_DummyTrain

サンプルプラグインの動作を簡単に試せるダミー車両です。リポジトリをクローンしたら、まずは`Plugins/_DummyTrain/Vehicle.txt`を絶対パスで適当なシナリオへ指定して、動作を確認してみてください。

#### 初期状態での機能

- SamplePlugin.Alert - シナリオを開始した時（Initializeメソッド呼出時）、シナリオ開始から10秒経過した時にダイアログを表示します。
- SamplePlugin.DynamicTexture - [DXDynamicTexture](https://github.com/zbx1425/DXDynamicTexture)のサンプルです。`Plugins/_DummyTrain/Panel/Raindow.tex.png`を置き換え、ランダムな色の背景に「SamplePlugin.DynamicTexture」の白い文字を描画します。
- SamplePlugin.SimpleAts - 100km/hを超過すると95km/hまで常用最大ブレーキで減速します。作動中はATS0の音を鳴らし、ATS255のパネルを表示します。

#### 注意

- **ダミー車両のみを別フォルダに移動しないでください。サンプルプラグインのビルド時、出力されたDLLを`Plugins/_DummyTrain/Ats`へ自動配置しています。** 詳細は各サンプルプラグインプロジェクトの[プロパティ]→[ビルド イベント]をご確認ください。
- **初期状態ではATSプラグインが配置されていません。** 2回ほどリビルドすると、ATSプラグインが`Plugins/_DummyTrain/Ats`へ自動で配置されます。

### Plugins/Libraries

DetailManagerNET、DetailManagerNET.PluginHostのビルドがこのフォルダ以下に自動で配置されます。  
出力先は以下の通りです。

- DetailManagerNET- `Plugins/Libraries/(x64 or x86)/DetailManagerNET.dll`
- DetailManagerNET.PluginHost - `Plugins/Libraries/DetailManagerNET.PluginHost.dll`

**※初期状態では配置されていません。一度リビルドしてください。**

#### コンテンツ一覧

- `Libraries/(x64 or x86)/DetailManagerNET.dll` - DetailManager.NETのメインDLL。読み込みたいDLLと同じフォルダにコピーしてください。なお、プラグインからこのDLLを参照する必要はありません（循環参照になります）。
- `Libraries/DetailManagerNET.PluginHost.dll` - プラグインに公開するクラス・構造体や、プラグインの基底となるインターフェースを提供するプラグインホストDLL。読み込みたいDLLと同じフォルダにコピーしてください。また、プラグイン開発時はこのDLLを参照に追加してください。

#### 注意

- **このフォルダやフォルダ内のコンテンツを削除・移動しないでください。サンプルプラグインのビルド時、このフォルダ内のDLLを自動でコピーしています。** 詳細は各サンプルプラグインプロジェクトの[プロパティ]→[ビルド イベント]をご確認ください。
- サンプルプラグインはこれらのDLLを自動でコピー・改名するため、特別な作業は必要ありません。

### Plugins/PluginTemplates

プラグインのテンプレートがこのフォルダ内に格納されています。  
プラグインテンプレートはVisual Studio テンプレートプロジェクト形式になっており、Visual Studioの「新しいプロジェクトの作成」から生成することができます。

#### Plugins/PluginTemplates/PluginTemplatePack

プラグインテンプレートをVisual StudioにインストールするためのVSIXインストーラーです。

#### Plugins/PluginTemplates/Basic

最もベーシックなテンプレートです。必要最低限なコードのみが記述されています。

#### Plugins/PluginTemplates/DynamicTexture

[DXDynamicTexture](https://github.com/zbx1425/DXDynamicTexture)を使用するプラグインのテンプレートです。Basicと同一のコードの他、DXDynamicTextureの動作に必要なコード、テクスチャを編集しやすくするためのクラス（初期クラス名：`YourHN.YourPluginName.DynamicTexture`）が定義されています。また、ビルド時のターゲットプラットフォームの設定によってターゲットフレームワークが自動で変更されるようになっています。

### Plugins/SamplePlugins

プラグインのサンプルがこのフォルダ内に格納されています。

以下のサンプルは初めからダミー車両で参照するように設定されており、動作を確認することができます。  
また、各プロジェクトはビルド後に`Plugins/_DummyTrain/Ats`へ自動配置するように設定されています。詳細は各サンプルの[プロパティ]→[ビルド イベント]をご確認ください。

#### Plugins/SamplePlugins/Alert

シナリオを開始した時（Initializeメソッド呼出時）、シナリオ開始から10秒経過した時にダイアログを表示します。

#### Plugins/SamplePlugins/DynamicTexture

[DXDynamicTexture](https://github.com/zbx1425/DXDynamicTexture)のサンプルです。`Plugins/_DummyTrain/Panel/Raindow.tex.png`を置き換え、ランダムな色の背景に「SamplePlugin.DynamicTexture」の白い文字を描画します。

#### Plugins/SamplePlugins/SimpleAts

100km/hを超過すると95km/hまで常用最大ブレーキで減速します。作動中はATS0の音を鳴らし、ATS255のパネルを表示します。
