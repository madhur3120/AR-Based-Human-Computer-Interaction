/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub.Types {

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Feature data type.
    /// This follows `numpy` dtypes.
    /// </summary>
    public static class Dtype {

        #region --Client API--
        public const string Int8 = "int8";
        public const string Int16 = "int16";
        public const string Int32 = "int32";
        public const string Int64 = "int64";
        public const string Uint8 = "uint8";
        public const string Uint16 = "uint16";
        public const string Uint32 = "uint32";
        public const string Uint64 = "uint64";
        public const string Float16 = "float16";
        public const string Float32 = "float32";
        public const string Float64 = "float64";
        public const string Bool = "bool";
        public const string String = "string";
        public const string Image = "image";
        public const string Binary = "binary";

        public static string FromType (Type type) => TypeMap.TryGetValue(type, out var value) ? value : null;
        
        public static string FromType<T> () => FromType(typeof(T));
        #endregion


        #region --Operations--

        private static readonly Dictionary<Type, string> TypeMap = new Dictionary<Type, string>{
            [typeof(sbyte)]     = Int8,
            [typeof(short)]     = Int16,
            [typeof(int)]       = Int32,
            [typeof(long)]      = Int64,
            [typeof(byte)]      = Uint8,
            [typeof(ushort)]    = Uint16,
            [typeof(uint)]      = Uint32,
            [typeof(ulong)]     = Uint64,
            [typeof(float)]     = Float32,
            [typeof(double)]    = Float64,
            [typeof(bool)]      = Bool,
            [typeof(string)]    = String,
        };
        #endregion
    }
}