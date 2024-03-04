using System.Text;

namespace ZplPrinter.Library;

public class ZplCommandBuilder
{
    private StringBuilder _stringBuilder = new StringBuilder();

    public ZplCommandBuilder()
    {
        StartFormat();
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
        _stringBuilder.AppendLine("^XZ");
    }

    public ZplCommandBuilder SetText(string text)
    {
        FieldData(text); 

        return this;
    }

    public string Build()
    {
        EndFormat();

        return _stringBuilder.ToString();
    }

}
