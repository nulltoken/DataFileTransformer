using System;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyCompany("Project committers, Inc.")]
[assembly: AssemblyProduct("DataFileTransformer")]
[assembly: AssemblyCopyright("Copyright © Project committers, Inc. 2009")]
[assembly: AssemblyTrademark("")]

#if DEBUG

[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyDescription("Flavor=Debug")] // a.k.a. "Comments"
#else
[assembly: AssemblyConfiguration("Retail")]
[assembly: AssemblyDescription("Flavor=Retail")] // a.k.a. "Comments"
#endif

[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("0.1.0.0")]
[assembly: AssemblyInformationalVersion("0.1.0.0")]