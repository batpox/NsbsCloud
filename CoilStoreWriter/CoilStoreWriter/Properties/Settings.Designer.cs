﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoilStore.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("d:\\logs")]
        public string LogFolder {
            get {
                return ((string)(this["LogFolder"]));
            }
            set {
                this["LogFolder"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CoilStore")]
        public string ProcessName {
            get {
                return ((string)(this["ProcessName"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("c:\\(data)\\CoilImport")]
        public string CoilImportFolder {
            get {
                return ((string)(this["CoilImportFolder"]));
            }
            set {
                this["CoilImportFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("c:\\(data)\\CoilImport\\Success")]
        public string CoilSuccessFolder {
            get {
                return ((string)(this["CoilSuccessFolder"]));
            }
            set {
                this["CoilSuccessFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("c:\\(data)\\CoilImport\\Failure")]
        public string CoilFailureFolder {
            get {
                return ((string)(this["CoilFailureFolder"]));
            }
            set {
                this["CoilFailureFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15")]
        public int FilePollSeconds {
            get {
                return ((int)(this["FilePollSeconds"]));
            }
            set {
                this["FilePollSeconds"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("50")]
        public int ThrottleMilliseconds {
            get {
                return ((int)(this["ThrottleMilliseconds"]));
            }
            set {
                this["ThrottleMilliseconds"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("c:\\(data)\\CoilImport\\Processing")]
        public string CoilProcessingFolder {
            get {
                return ((string)(this["CoilProcessingFolder"]));
            }
            set {
                this["CoilProcessingFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("c:\\(data)\\CoilImport\\Test")]
        public string TestFolder {
            get {
                return ((string)(this["TestFolder"]));
            }
            set {
                this["TestFolder"] = value;
            }
        }
    }
}
