using System.Text;

namespace ZplPrinter.Library;

public class ZplCommandBuilder
{
    private StringBuilder _stringBuilder = new StringBuilder();

    private ZplCommandBuilder()
    {
        StartFormat();
    }

    public static ZplCommandBuilder CreateLabel()
    {
        return new ZplCommandBuilder();
    }

    private void FieldData(string a)
    {
        _stringBuilder.AppendLine($"^FD{a}");
    }

    private void StartFormat()
    {
        _stringBuilder.AppendLine("^XA");

    }

    private void EndFormat()
    {
        _stringBuilder.Append("^XZ");
    }

    public ZplCommandBuilder SetText(string text)
    {
        FieldData(text); 

        return this;
    }

    public void SetBarcode(string barcode, string format, int x, int y)
    {
        _stringBuilder.Append($"^B{format},{x},{y}\n");
        FieldData(barcode);
    }

    public string Build()
    {
        EndFormat();

        return _stringBuilder.ToString();
    }

}
