/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All Rights Reserved.
*/

using System.Reflection;
using System.Runtime.CompilerServices;
using NatML.Hub.Internal;

// Metadata
[assembly: AssemblyCompany("NatML Inc.")]
[assembly: AssemblyTitle("NatML Hub")]
[assembly: AssemblyVersionAttribute(HubSettings.Version)]
[assembly: AssemblyCopyright("Copyright © 2023 NatML Inc. All Rights Reserved.")]

// Friends
[assembly: InternalsVisibleTo(@"NatML.Hub.Editor")]
[assembly: InternalsVisibleTo(@"NatML.Hub.Tests")]