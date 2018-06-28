using System;

namespace CheckoutKata.Builders
{
    public abstract class Builder<TBuilder, TBuildType>
    {
        public static TBuilder Build => Activator.CreateInstance<TBuilder>();

        public abstract TBuildType AnInstance();
    }
}
