using System;

public class dto_popup_Basic
{
    public string title;
    public string summary;
    public Action action_opening;
    public Action action_opened;
    public Action action_closing;
    public Action action_closed;

    public dto_popup_Basic(string title, string summary)
    {
        this.title = title;
        this.summary = summary;
    }
}