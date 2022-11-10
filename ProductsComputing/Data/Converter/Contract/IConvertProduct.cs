namespace ProductsComputing.Data.Converter.Contract
{
    public interface IConvertProduct<D,O>
    {
        public D Converter(O origin);
    }
}
