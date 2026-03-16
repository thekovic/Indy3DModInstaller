namespace Indy3DModInstaller;

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
        if (MessageBox.InvokeRequired)
        {
            MessageBox.Invoke(() => WriteLineAndScroll(message));
        }
        else
        {
            WriteLineAndScroll(message);
        }
    }

    private void WriteLineAndScroll(string message)
    {
        MessageBox.AppendText($"{message}{Environment.NewLine}");
        // Scroll to end after new message is added.
        MessageBox.SelectionStart = MessageBox.TextLength;
        MessageBox.ScrollToCaret();
    }
}
