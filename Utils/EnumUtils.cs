namespace AltV.Atlas.Boilerplate.Server.Utils;


public static class EnumUtils
{
    public static T? RandomEnumValue<T>( )
    {
        var v = Enum.GetValues( typeof( T ) );
        return ( T ) v.GetValue( new Random( ).Next( v.Length ) )!;
    }
}