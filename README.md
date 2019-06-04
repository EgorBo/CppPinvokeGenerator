# CppPinvokeGenerator
A simple pinvoke generator based on [xoofx/CppAst](https://github.com/xoofx/CppAst) to generate C# for C/C++

Let's say we have a C++ class:
```c++
class Calculator {
public:
     int add(int x, int y);
}
```

Since it's a class and `add` is an instance method, we need to make it DllImport-friendly:

```c++
EXPORTS(Calculator*) Calculator_Calculator() { return new Calculator(); }
EXPORTS(int) Calculator_add(Calculator* target, int x, int y);
```

Now we can easily bind it to C#:

```csharp
public partial class Calculator
{
    public IntPtr Handle { get; private set; }
    
    // API:
    public Calculator() => this.Handle = Calculator_Calculator();
    public int Add(int x, int y) => Calculator_add(Handle, x, y);
    
    // DllImports
    [DllImport("mylib")] private static extern int Calculator_add(IntPtr handle, int x, int y);
    [DllImport("mylib")] private static extern IntPtr Calculator_Calculator();
    
    // Dispose:
    ...
}
```

So the generator is able to generate C# classes (only dllimports at the moment) and the C glue.
As an example - see [samples/SimdJson](https://github.com/EgorBo/CppPinvokeGenerator/tree/master/samples/SimdJson).
