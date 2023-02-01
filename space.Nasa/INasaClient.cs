namespace space.Nasa
{
    public interface INasaClient<in TIn, out TOut>
    {
        // by default method is public in interface
        TOut GetAsync(TIn input);
    }
}