﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Automatic9045.DetailManagerNET.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Automatic9045.DetailManagerNET.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   すべてについて、現在のスレッドの CurrentUICulture プロパティをオーバーライドします
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   An error occured while loading ATS plugin &apos;{0}&apos; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string LoadErrorOccured {
            get {
                return ResourceManager.GetString("LoadErrorOccured", resourceCulture);
            }
        }
        
        /// <summary>
        ///   The plugin list &apos;{0}&apos; does not exist. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string PluginListNotFound {
            get {
                return ResourceManager.GetString("PluginListNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   No parameterless constructor defined in &apos;{0}&apos;. The types for ATS plugin require parameterless constructor to create an instance from the wrapper. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string PluginTypeNoParamLessConstructor {
            get {
                return ResourceManager.GetString("PluginTypeNoParamLessConstructor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cannot find a type available as ATS plugin in the target DLL &apos;{0}&apos;, types for ATS plugin must be a public class implementing {1}. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string PluginTypeNotFound {
            get {
                return ResourceManager.GetString("PluginTypeNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Unable to load the target DLL &apos;{0}&apos;. The target framework (3.5, 4.8, etc.) or target platform (x86 / x64) may be wrong, or it may not be developed with .NET Framework. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string TargetDllBadImageFormat {
            get {
                return ResourceManager.GetString("TargetDllBadImageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   The target DLL &apos;{0}&apos; does not exist. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string TargetDllNotFound {
            get {
                return ResourceManager.GetString("TargetDllNotFound", resourceCulture);
            }
        }
    }
}