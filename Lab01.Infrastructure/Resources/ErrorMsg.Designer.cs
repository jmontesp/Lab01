﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab01.Infrastructure.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ErrorMsg {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMsg() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Lab01.Infrastructure.Resources.ErrorMsg", typeof(ErrorMsg).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot create task.
        /// </summary>
        public static string CannotCreateItem {
            get {
                return ResourceManager.GetString("CannotCreateItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot delete task.
        /// </summary>
        public static string CannotDeleteItem {
            get {
                return ResourceManager.GetString("CannotDeleteItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot update task.
        /// </summary>
        public static string CannotUpdateItem {
            get {
                return ResourceManager.GetString("CannotUpdateItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Title cannot be empty.
        /// </summary>
        public static string EmptyTitle {
            get {
                return ResourceManager.GetString("EmptyTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to create tasks with expired dates.
        /// </summary>
        public static string ExpiredDate {
            get {
                return ResourceManager.GetString("ExpiredDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to create tasks with negative duration.
        /// </summary>
        public static string NegativeDuration {
            get {
                return ResourceManager.GetString("NegativeDuration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not supported data contex.
        /// </summary>
        public static string NotSupportedDataContext {
            get {
                return ResourceManager.GetString("NotSupportedDataContext", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not valid id {0}.
        /// </summary>
        public static string NotValidId {
            get {
                return ResourceManager.GetString("NotValidId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Null Todo Item.
        /// </summary>
        public static string NullTodoItem {
            get {
                return ResourceManager.GetString("NullTodoItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tasks for {0} exceed 8 hours.
        /// </summary>
        public static string TimeExceeded {
            get {
                return ResourceManager.GetString("TimeExceeded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Task duration is too long.
        /// </summary>
        public static string TooLongDuration {
            get {
                return ResourceManager.GetString("TooLongDuration", resourceCulture);
            }
        }
    }
}
