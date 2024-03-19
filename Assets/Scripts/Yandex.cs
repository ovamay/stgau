using System.Runtime.InteropServices;

public class Yandex 
{
    [DllImport("__Internal")]
    private static extern void ShowFullAdv();

    [DllImport("__Internal")]
    private static extern void ShowVideoAdv();

    public void ShowAdv() => ShowFullAdv();

    public void ShowVideo() => ShowVideoAdv();
}
