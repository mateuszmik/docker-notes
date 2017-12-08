using System;

public class NotificationsMesasage
{
    public string Message { get; set; }
    public string MessageType { get; set; }
    public Guid Guid { get; set; }
    public DateTime GeneratedOn { get; set; }

    public NotificationsMesasage()
    {
        Guid = Guid.NewGuid();
        GeneratedOn = DateTime.Now;
    }

}