# C#ATSプラグインラッパー
【BVE5・6】C#でATSプラグインを簡単に開発できるようにするラッパーです。

## 具体的な機能
DllExportなど、アンマネージドコードと連携するための処理を肩代わりします。  
BVEからこのラッパーライブラリ（以下ラッパーDLL）を通じてユーザーが開発したライブラリ（以下ターゲットDLL）を読み込むことで、ユーザーはアンマネージドコードの存在を意識せずに開発できるようになります。

```
BVE本体
　↓
YourAtsPlugin.wrapper.dll（ラッパーDLL＝このライブラリ）
　↓
YourAtsPlugin.dll（ターゲットDLL）
```

一方、関数については従来のATSプラグインの仕様とほとんど変えていません。  
これは、従来のATSプラグインとほとんど同じ仕様とすることで、従来のATSプラグインのために書かれたネット上の記事をそのまま参考にでき、初心者にとってのハードルが低くなること、
また従来のATSプラグインのコードを容易に移植できるようにするためです。

なお、クラス設計のC#への最適化については、別プロジェクトにて行う予定があります。

## 利用方法
準備中……

## ライセンス
[The MIT License](LICENSE)

## 使用ライブラリ
### [DllExport](https://github.com/3F/DllExport) (MIT)
Copyright (c) 2009-2015  Robert Giesecke  
Copyright (c) 2016-2021  Denis Kuzmin <x-3F@outlook.com> github/3F

### [DXDynamicTexture for BVE Trainsim 5/6](https://github.com/zbx1425/DXDynamicTexture) (MIT)
Copyright (c) 2021 zbx1425

CSharpAtsPluginWrapper本体では使用していませんが、付属のテンプレート「PluginTemplate.DynamicTexture」、サンプル「SamplePlugin.DynamicTexture」に含まれます。
