using ReadingNote.Models;
using System.Globalization;

namespace ReadingNote.Converters;

internal class ReadingStatusConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        ReadingStatus status = (ReadingStatus)value;
        return status switch
        {
            ReadingStatus.Unread => "未读",
            ReadingStatus.Reading => "正在阅读",
            ReadingStatus.Finished => "已读完",
            _ => throw new NotImplementedException(),
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string status = (string)value;
        return status switch
        {
            "未读" => ReadingStatus.Unread,
            "正在阅读" => ReadingStatus.Reading,
            "已读完" => ReadingStatus.Finished,
            _ => throw new NotImplementedException(),
        };
    }
}
