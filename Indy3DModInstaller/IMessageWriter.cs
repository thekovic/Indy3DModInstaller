namespace Indy3DModInstaller;

public interface IHasMessageWriter
{
    public IMessageWriter MessageWriter { get; }
}

public interface IMessageWriter
{
    public void WriteLine(string message);
}

public class NullMessageWriter : IMessageWriter
{
    /// <summary>
    /// Print a message to nowhere. Used when no user feedback is needed.
    /// </summary>
    /// <param name="message">Message to be printed.</param>
    public void WriteLine(string message)
    {
        // Do nothing.
    }
}

public class GuiMessageWriter(RichTextBox messageBox) : IMessageWriter
{
    public RichTextBox MessageBox { get; } = messageBox;

    /// <summary>
    /// Print a message to the message box in the GUI. Used as main user-facing feedback mechanism.
    /// </summary>
    /// <param name="message">Message to be printed.</param>
    public void WriteLine(string message)
    {
        // Dispatch action based on what the GUI needs
        if (this.MessageBox.InvokeRequired)
        {
            this.MessageBox.Invoke(() => this.MessageBox.AppendText($"{message}{Environment.NewLine}"));
        }
        else
        {
            this.MessageBox.AppendText($"{message}{Environment.NewLine}");
        }
    }
}
