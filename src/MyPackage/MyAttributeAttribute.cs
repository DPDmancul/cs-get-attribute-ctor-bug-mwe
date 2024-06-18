namespace MyPackage;

public class MyAttributeAttribute(
#if VER_1_1
    int param = default
#endif
) : Attribute;