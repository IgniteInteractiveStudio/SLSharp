SL#: Runtime IL -> Shader Translator
====================================

Introduction
------------

SL# is a runtime IL-to-GLSL/HLSL translation engine, written in pure C#. It
takes the compiled IL of a shader definition written in a managed language 
(usually C#), and generates GLSL or HLSL shader code from it. The shader code
is automatically  uploaded to the GPU, and you can use the shader object as any
other object in .NET. Shaders can have properties that map directly to uniform
and varying variables in the GLSL/HLSL code, allowing you to easily interact
with your GPU code from the CPU.

Please note that SL# is currently a very experimental library. The syntax and
usage may be subject to change at any time, as we further research what design
is the most sane for the project.

Rationale
---------

There are quite a few advantages to this approach:

* Developers can use existing development tools (Visual Studio, MonoDevelop,
  SharpDevelop, etc.) to develop shaders. This means code completion, syntax
  checking, and so on.
* Shaders are validated at compile time. Any syntactical or semantical errors
  are caught by the C# compiler, rather than at runtime when interacting with
  the GPU.
* No more storing shaders as huge strings in source code, or storing them as
  resources. They're compiled directly to IL.

Dependencies
------------

SL# currently depends on Mono.Cecil, ICSharpCode.NRefactory,
ICSharpCode.Decompiler, as well as additional dependencies for the bindings.

Issues
------

Please report any issues on the GitHub issue tracker.

Known problems:

* Geometry shaders are currently not supported.
* Support for other .NET languages (such as F#) is currently up in the air. We
  haven't had time to test SL# with F# yet, but we would definitely like to add
  support for it in the future (perhaps using quotations).
* HLSL support is currently at a bare minimum.
* Resource management is not very flexible; it relies heavily on static state.
  This currently limits how well SL# can use multiple rendering contexts. We will
  definitely fix this in the future.
